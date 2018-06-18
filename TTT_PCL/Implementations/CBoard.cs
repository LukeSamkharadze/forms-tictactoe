using System;

using TTT_PCL.Abstractions;
using TTT_PCL.Abstractions.Board;

using TTT_PCL.Initializers;
using TTT_PCL.Other;

namespace TTT_PCL.Implementations
{
    public class CBoard : IBoard
    {
        public IBoardPlaceable[,] Board { get; private set; }

        public bool Place(IBoardPlaceable boardPlaceable)
        {
            if (Board[boardPlaceable.Cordinate2D.Y, boardPlaceable.Cordinate2D.X] == null)
            {
                Board[boardPlaceable.Cordinate2D.Y, boardPlaceable.Cordinate2D.X] = boardPlaceable;
                boardPlaceable.Board = this;
                return true;
            }

            return false;
        }

        public IBoardPlaceable Take(SCordinate2D cordinate2D)
        {
            return Board[cordinate2D.Y, cordinate2D.X];
        }

        public CBoard(CBoardInitializer boardInitializer)
        {
            Board = boardInitializer.Board;
        }
    }
}
