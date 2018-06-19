using System;

using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Game
{
    public interface IBoardGame : IGame
    {
        IBoard Board { get; }

        bool Place(IItem item);
        IItem Take(SCordinate2D cordinate2D);
    }
}
