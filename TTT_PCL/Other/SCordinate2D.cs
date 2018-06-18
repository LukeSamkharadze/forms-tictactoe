using System;

using TTT_PCL.Abstractions;

namespace TTT_PCL.Other
{
    public struct SCordinate2D
    {
        public int Y { get; }
        public int X { get; }

        public SCordinate2D(int y,int x)
        {
            Y = y;
            X = x;
        }
    }
}
