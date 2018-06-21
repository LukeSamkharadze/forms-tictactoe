using System;

using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Board
{
    public interface I_Board
    {
        I_Item[,] Board { get; }

        bool Place(I_Item item, S_Cordinate2D cordinate2D);
        I_Item Take(S_Cordinate2D cordinate2D);
    }
}
