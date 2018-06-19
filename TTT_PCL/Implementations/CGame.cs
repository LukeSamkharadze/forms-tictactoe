using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Game;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Extentions;
using TTT_PCL.Other;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public class CGame : IBoardGame
    {
        public IList<IPlayer> Players { get; private set; }

        public CBaseGameInfo BaseGameInfo { get; private set; }

        public IBoard Board { get; private set; }

        public IPlayer Winner { get; private set; }

        public event EventHandler onEnd;

        public IPlayer CheckWinner()
        {
            Dictionary<IPlayer, uint> counter;
            counter = new Dictionary<IPlayer, uint>();
            counter.SetupKeys<IPlayer, uint>(Players, 0);

            //Check Horizontally
            for (int y = 0; y < Board.Board.GetLength(0); y++)
            {
                for (int x = 0; x <= Board.Board.GetLength(1) - BaseGameInfo.MinToWinHorizontally; x++)
                {
                    counter.SetupValues<IPlayer, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinHorizontally; i++)
                        counter[Board.Board[y, x + i].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinHorizontally)
                        {
                            onEnd.Invoke(this, new CGameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            //Check Vertically
            for (int y = 0; y <= Board.Board.GetLength(0) - BaseGameInfo.MinToWinVertically; y++)
            {
                for (int x = 0; x < Board.Board.GetLength(1); x++)
                {
                    counter.SetupValues<IPlayer, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinVertically; i++)
                        counter[Board.Board[y + i, x].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinVertically)
                        {
                            onEnd.Invoke(this, new CGameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            //Check Diagonally
            for (int y = 0; y <= Board.Board.GetLength(0) - BaseGameInfo.MinToWinDiagonally; y++)
            {
                for (int x = 0; x <= Board.Board.GetLength(1) - BaseGameInfo.MinToWinDiagonally; x++)
                {
                    counter.SetupValues<IPlayer, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinDiagonally; i++)
                        counter[Board.Board[y + i, x + i].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinDiagonally)
                        {
                            onEnd.Invoke(this, new CGameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            //Check Diagonally ^
            for (int y = Board.Board.GetLength(0) - 1; y >= BaseGameInfo.MinToWinDiagonally - 1; y--)
            {
                for (int x = 0; x <= Board.Board.GetLength(1) - BaseGameInfo.MinToWinDiagonally; x++)
                {
                    counter.SetupValues<IPlayer, uint>(Players, 0);

                    for (int i = 0; i < BaseGameInfo.MinToWinDiagonally; i++)
                        counter[Board.Board[y - i, x + i].Owner]++;

                    foreach (var keyValue in counter)
                        if (keyValue.Value >= BaseGameInfo.MinToWinDiagonally)
                        {
                            onEnd.Invoke(this, new CGameEndEventArgs() { Winner = keyValue.Key });
                            return keyValue.Key;
                        }
                }
            }

            return null;
        }

        public bool Place(IItem item)
        {
            if(Board.Place(item))
            {
                CheckWinner();
                return true;
            }
            return false;
        }
        public IItem Take(SCordinate2D cordinate2D)
        {
            IItem item= Board.Take(cordinate2D);
            CheckWinner();
            return item;
        }

        public CGame(CGameInitializer gameInitializer)
        {
            Players = gameInitializer.Players;
            BaseGameInfo = gameInitializer.BaseGameInfo;
            Board = gameInitializer.Board;
            Winner = gameInitializer.Winner;
        }
    }
}
