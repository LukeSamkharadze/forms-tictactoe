using System;

using TTT_PCL.Abstractions;
using TTT_PCL.Abstractions.Board;

using TTT_PCL.Initializers;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

namespace TTT_PCL.Implementations
{
    public class C_Board : I_Board
    {
        public I_Item[,] Board { get; private set; }

        public bool Place(I_Item item, S_Cordinate2D cordinate2D)
        {
            if (Board[cordinate2D.Y, cordinate2D.X] == null)
            {
                Board[cordinate2D.Y, item.Cordinate2D.X] = item;
                item.Place(this, cordinate2D);
                return true;
            }

            return false;
        }

        public I_Item Take(S_Cordinate2D cordinate2D)
        {
            return Board[cordinate2D.Y, cordinate2D.X];
        }

        public C_Board(C_BoardInitializer boardInitializer)
        {
            Board = boardInitializer.Board;
        }
    }
}
