using System;
using System.Collections.Generic;
using System.Linq;


using TTT_PCL.Abstractions;
using TTT_PCL.Extentions;
using TTT_PCL.Other;

using TTT_PCL.Initializers;
using System.Security.AccessControl;

namespace TTT_PCL.Implementations
{
    public sealed class C_Game : I_Game
    {
        public IList<I_Player> Players { get; private set; }

        public S_MinToWin MinToWin { get; private set; }

        public I_Board Board { get; private set; }

        public I_Player Winner { get; private set; }

        public bool IsGameEnded { get; private set; }

        public IEnumerator<I_Player> WhoseTurn { get; private set; }

        public event EventHandler onEnd;

        public I_Player Iterate()
        {
            if (WhoseTurn.MoveNext() == false)
            {
                WhoseTurn = Players.GetEnumerator();
                WhoseTurn.MoveNext();
                return WhoseTurn.Current;
            }

            return WhoseTurn.Current;
        }

        public I_Player CheckWinner()
        {
            List<string> PlayerSigns = Players.Select(o => o.Sign).ToList();

            Dictionary<string, int> counter = new Dictionary<string, int>();
            counter.SetupKeys<string, int>(PlayerSigns, 0);

            Dictionary<int, int> minToWin = new Dictionary<int, int>()
            {
                {0, MinToWin.MinToWinHorizontally},
                {1, MinToWin.MinToWinVertically},
                {2, MinToWin.MinToWinDiagonally}
            };

            Dictionary <int, Func<int, int, int>> calculateXCordinate = new Dictionary<int, Func<int, int, int>>()
            {
                {0, (x, dx) => x + dx},
                {1, (x, dx) => x},
                {2, (x, dx) => x + dx}
            };

            Dictionary<int, Func<int, int, int>> calculateYCordinate = new Dictionary<int, Func<int, int, int>>()
            {
                {0, (y, dy) => y},
                {1, (y, dy) => y + dy},
                {2, (y, dy) => y + dy}
            };

            for (int y = 0; y < Board.Board.GetLength(0); y++)
                for(int x = 0; x < Board.Board.GetLength(1); x++)
                    for (int directionID = 0; directionID < 3; directionID++)
                    {
                        counter.SetupValues<string, int>(PlayerSigns, 0);

                        for (int dyx = 0;
                            dyx < minToWin[directionID] &&
                            calculateYCordinate[directionID](y, dyx) < Board.Board.GetLength(0) &&
                            calculateXCordinate[directionID](x, dyx) < Board.Board.GetLength(1);
                            dyx++)
                            if (Board.Board[calculateYCordinate[directionID](y, dyx), calculateXCordinate[directionID](x, dyx)] != null)
                                counter[Board.Board[calculateYCordinate[directionID](y, dyx), calculateXCordinate[directionID](x, dyx)]]++;

                        foreach (var keyValue in counter)
                            if (keyValue.Value >= minToWin[directionID])
                            {
                                IsGameEnded = true;
                                Winner = Players.First(o => o.Sign == keyValue.Key);
                                onEnd?.Invoke(this, new C_GameEndEventArgs() { Winner = Winner });
                                return Winner;
                            }
                    }

            //Checking For Ending Game
            for (int y = 0; y < Board.Board.GetLength(0); y++)
                for (int x = 0; x < Board.Board.GetLength(1); x++)
                    if (Board.Board[y, x] == null)
                        return null;

            //Draw
            IsGameEnded = true;
            onEnd?.Invoke(this, new C_GameEndEventArgs() { Winner = null });
            return null;
        }
       
        public C_Game(C_GameInitializer gameInitializer)
        {
            Players = new List<I_Player>();
            foreach (var playerSign in gameInitializer.PlayerSigns)
                Players.Add(new C_Player(new C_PlayerInitializer() { Sign = playerSign, Game = this }));

            WhoseTurn = Players.GetEnumerator();
            WhoseTurn.MoveNext();

            MinToWin = gameInitializer.MinToWin;

            Board = new C_Board(gameInitializer.boardInitializer);
        }
    }
}
