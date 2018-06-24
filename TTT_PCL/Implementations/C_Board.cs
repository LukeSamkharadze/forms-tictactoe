using System;

using TTT_PCL.Abstractions;
using TTT_PCL.Initializers;

using TTT_PCL.Other;

namespace TTT_PCL.Implementations
{
    public sealed class C_Board : I_Board
    {
        public char[,] Board { get; private set; }

        public bool Place(char item, S_Cordinate2D cordinate2D)
        {
            if (Board[cordinate2D.Y, cordinate2D.X] == '\0')
            {
                Board[cordinate2D.Y, cordinate2D.X] = item;
                return true;
            }

            return false;
        }

        public char Take(S_Cordinate2D cordinate2D)
        {
            char item = Board[cordinate2D.Y, cordinate2D.X];
            Board[cordinate2D.Y, cordinate2D.X] = '\0';

            return item;
        }

        public C_Board(C_BoardInitializer boardInitializer)
        {
            Board = boardInitializer.Board;
        }
    }
}
