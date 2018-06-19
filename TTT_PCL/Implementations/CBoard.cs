using System;

using TTT_PCL.Abstractions;
using TTT_PCL.Abstractions.Board;

using TTT_PCL.Initializers;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

namespace TTT_PCL.Implementations
{
    public class CBoard : IBoard
    {
        public IItem[,] Board { get; private set; }

        public bool Place(IItem item)
        {
            if (Board[item.Cordinate2D.Y, item.Cordinate2D.X] == null)
            {
                Board[item.Cordinate2D.Y, item.Cordinate2D.X] = item;
                item.Place(this);
                return true;
            }

            return false;
        }

        public IItem Take(SCordinate2D cordinate2D)
        {
            return Board[cordinate2D.Y, cordinate2D.X];
        }

        public CBoard(CBoardInitializer boardInitializer)
        {
            Board = boardInitializer.Board;
        }
    }
}
