using System;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions;
using TTT_PCL.Other;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public class CItem : IItem
    {
        public IPlayer Owner { get; }

        public IBoard Board { get; internal set; }

        public SCordinate2D Cordinate2D { get; }

        public CItem(CItemInitializer itemInitializer)
        {
            Owner = itemInitializer.Owner;
        }
    }
}
