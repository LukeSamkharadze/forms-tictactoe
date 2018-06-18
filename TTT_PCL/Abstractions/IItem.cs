using System;

using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Player;

namespace TTT_PCL.Abstractions
{
    public interface IItem : IBoardPlaceable
    {
        IPlayer Owner { get; }
    }
}
