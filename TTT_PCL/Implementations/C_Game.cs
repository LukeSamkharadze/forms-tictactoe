using System;
using System.Collections.Generic;
using System.Linq;


using TTT_PCL.Abstractions;
using TTT_PCL.Extentions;
using TTT_PCL.Other;

using TTT_PCL.Initializers;

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

            //Checking Horizontally
            for (int y = 0; y < Board.Board.GetLength(0); y++)
                for (int x = 0; x <= Board.Board.GetLength(1) - MinToWin.MinToWinHorizontally; x++)
                {   
                    counter.SetupValues<string, int>(PlayerSigns, 0);

                    for (int i = 0; i < MinToWin.MinToWinHorizontally; i++)
                        if (Board.Board[y, x + i] != null)
                            counter[Board.Board[y, x + i]]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= MinToWin.MinToWinHorizontally)
                        {
                            IsGameEnded = true;
                            Winner = Players.First(o => o.Sign == keyValue.Key);
                            onEnd?.Invoke(this, new C_GameEndEventArgs() { Winner = Winner });
                            return Winner;
                        }
                }

            //Checking Vertically
            for (int y = 0; y <= Board.Board.GetLength(0) - MinToWin.MinToWinVertically; y++)
                for (int x = 0; x < Board.Board.GetLength(1); x++)
                {
                    counter.SetupValues<string, int>(PlayerSigns, 0);

                    for (int i = 0; i < MinToWin.MinToWinVertically; i++)
                        if (Board.Board[y + i, x] != null)
                            counter[Board.Board[y + i, x]]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= MinToWin.MinToWinVertically)
                        {
                            IsGameEnded = true;
                            Winner = Players.First(o => o.Sign == keyValue.Key);
                            onEnd?.Invoke(this, new C_GameEndEventArgs() { Winner = Winner });
                            return Winner;
                        }
                }

            //Checking Diagonally
            for (int y = 0; y <= Board.Board.GetLength(0) - MinToWin.MinToWinDiagonally; y++)
                for (int x = 0; x <= Board.Board.GetLength(1) - MinToWin.MinToWinDiagonally; x++)
                {
                    counter.SetupValues<string, int>(PlayerSigns, 0);

                    for (int i = 0; i < MinToWin.MinToWinHorizontally; i++)
                        if (Board.Board[y + i, x + i] != null)
                            counter[Board.Board[y + i, x + i]]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= MinToWin.MinToWinDiagonally)
                        {
                            IsGameEnded = true;
                            Winner = Players.First(o => o.Sign == keyValue.Key);
                            onEnd?.Invoke(this, new C_GameEndEventArgs() { Winner = Winner });
                            return Winner;
                        }
                }

            //Checking Diagonally ^
            for (int y = Board.Board.GetLength(0) - 1; y >= MinToWin.MinToWinDiagonally - 1; y--)
                for (int x = 0; x <= Board.Board.GetLength(1) - MinToWin.MinToWinDiagonally; x++)
                {
                    counter.SetupValues<string, int>(PlayerSigns, 0);

                    for (int i = 0; i < MinToWin.MinToWinDiagonally; i++)
                        if (Board.Board[y - i, x + i] != null)
                            counter[Board.Board[y - i, x + i]]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= MinToWin.MinToWinDiagonally)
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
