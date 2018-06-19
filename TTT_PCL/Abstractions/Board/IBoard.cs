using System;

using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Board
{
    public interface IBoard
    {
        IItem[,] Board { get; }

        bool Place(IItem item);
        IItem Take(SCordinate2D cordinate2D);
    }
}
