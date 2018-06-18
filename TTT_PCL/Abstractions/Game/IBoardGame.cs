using System;

using TTT_PCL.Abstractions.Board;
using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Game
{
    interface IBoardGame : IGame
    {
        IBoard Board { get; }

        bool Place(IBoardPlaceable item);
        IBoardPlaceable Take(SCordinate2D cordinate2D);
    }
}
