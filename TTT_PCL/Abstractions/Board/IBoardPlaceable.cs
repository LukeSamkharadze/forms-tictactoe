using System;

using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Board
{
    public interface IBoardPlaceable
    {
        IBoard Board { get;}

        SCordinate2D Cordinate2D { get; }
    }
}
