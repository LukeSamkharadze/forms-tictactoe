using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Game;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Extentions;
using TTT_PCL.Other;

using TTT_PCL.Initializers;
using TTT_PCL.Extensions;

namespace TTT_PCL.Implementations
{
    public class C_Game : I_BoardGame
    {
        public IList<I_Player> Players { get; private set; }

        public S_BaseGameInfo BaseGameInfo { get; private set; }

        public I_Board Board { get; private set; }

        public I_Player Winner { get; private set; }

        public bool IsGameEnded { get; private set; }

        public I_Player WhooseTurn { get; private set; }

        public event EventHandler onEnd;

        public I_Player CheckWinner()
        {
            Dictionary<I_Player, uint> counter;
            counter = new Dictionary<I_Player, uint>();
            counter.SetupKeys<I_Player, uint>(Players, 0);

            //Check Horizontally
            for (int y = 0; y < Board.Board.GetLength(0); y++)
            {
                for (int x = 0; x <= Board.Board.GetLength(1) - BaseGameInfo.MinToWinHorizontally; x++)
                {
                    counter.SetupValues<I_Player, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinHorizontally; i++)
                        counter[Board.Board[y, x + i].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinHorizontally)
                        {
                            onEnd.Invoke(this, new C_GameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            //Check Vertically
            for (int y = 0; y <= Board.Board.GetLength(0) - BaseGameInfo.MinToWinVertically; y++)
            {
                for (int x = 0; x < Board.Board.GetLength(1); x++)
                {
                    counter.SetupValues<I_Player, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinVertically; i++)
                        counter[Board.Board[y + i, x].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinVertically)
                        {
                            onEnd.Invoke(this, new C_GameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            //Check Diagonally
            for (int y = 0; y <= Board.Board.GetLength(0) - BaseGameInfo.MinToWinDiagonally; y++)
            {
                for (int x = 0; x <= Board.Board.GetLength(1) - BaseGameInfo.MinToWinDiagonally; x++)
                {
                    counter.SetupValues<I_Player, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinDiagonally; i++)
                        counter[Board.Board[y + i, x + i].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinDiagonally)
                        {
                            onEnd.Invoke(this, new C_GameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            //Check Diagonally ^
            for (int y = Board.Board.GetLength(0) - 1; y >= BaseGameInfo.MinToWinDiagonally - 1; y--)
            {
                for (int x = 0; x <= Board.Board.GetLength(1) - BaseGameInfo.MinToWinDiagonally; x++)
                {
                    counter.SetupValues<I_Player, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinDiagonally; i++)
                        counter[Board.Board[y - i, x + i].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinDiagonally)
                        {
                            onEnd.Invoke(this, new C_GameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            //Check For Draw
            bool isEverythingTaken = true;
            for (int y = 0; y < Board.Board.GetLength(0); y++)
            {
                for (int x = 0; x < Board.Board.GetLength(1); x++)
                {
                    if (Board.Board[y, x] == null)
                    {
                        isEverythingTaken = false;
                        return null; ;
                    }
                }
            }

            if(isEverythingTaken)
            {
                IsGameEnded = true;
                onEnd.Invoke(this, new C_GameEndEventArgs() { Winner = null });
                return null;
            }

            return null;
        }

        public bool Place(I_Item item, S_Cordinate2D cordinate2D)
        {
            if (Board.Place(item, cordinate2D))
            {
                CheckWinner();
                Players.MoveNextOrFirst(WhooseTurn);
                return true;
            }
            return false;
        }

        public I_Item Take(S_Cordinate2D cordinate2D)
        {
            I_Item item = Board.Take(cordinate2D);
            CheckWinner();
            Players.MoveNextOrFirst(WhooseTurn);
            return item;
        }

        public C_Game(C_GameInitializer gameInitializer)
        {
            Players = gameInitializer.Players;
            BaseGameInfo = gameInitializer.BaseGameInfo;
            Board = gameInitializer.Board;
            Winner = gameInitializer.Winner;
            IsGameEnded = gameInitializer.IsGameEnded;
            WhooseTurn = gameInitializer.WhooseTurn;
        }
    }
}
