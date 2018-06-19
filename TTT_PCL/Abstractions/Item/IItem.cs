using System;

using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Player;
using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Item
{
    public interface IItem
    {
        IPlayer Owner { get; }

        IBoard Board { get; }

        SCordinate2D Cordinate2D { get; }

        void Place(IBoard board);
    }
}