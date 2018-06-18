﻿using System;

using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Board
{
    public interface IBoard
    {
        IBoardPlaceable[,] Board { get; }

        bool Place(IBoardPlaceable item);
        IBoardPlaceable Take(SCordinate2D cordinate2D);
    }
}