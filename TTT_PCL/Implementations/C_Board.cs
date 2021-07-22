using TTT_PCL.Abstractions;
using TTT_PCL.Initializers;

using TTT_PCL.Other;

namespace TTT_PCL.Implementations
{
    public sealed class C_Board : I_Board
    {
        public string[,] Board { get; private set; }

        public bool Place(string item, S_Cordinate2D cordinate2D)
        {
            if(Board[cordinate2D.Y, cordinate2D.X] == null)
            {
                Board[cordinate2D.Y, cordinate2D.X] = item;
                return true;
            }

            return false;
        }

        public string Take(S_Cordinate2D cordinate2D)
        {
            string item = Board[cordinate2D.Y, cordinate2D.X];
            Board[cordinate2D.Y, cordinate2D.X] = null;

            return item;
        }

        public C_Board(C_BoardInitializer boardInitializer)
        {
            Board = new string[boardInitializer.Dimensions.Width, boardInitializer.Dimensions.Length];
        }
    }
}