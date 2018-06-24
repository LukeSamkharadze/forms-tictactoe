using System;

using TTT_PCL.Other;

namespace TTT_PCL.Abstractions
{
    public interface I_Board
    {
        char[,] Board { get; }

        bool Place(char item, S_Cordinate2D cordinate2D);
        char Take(S_Cordinate2D cordinate2D);
    }
}
