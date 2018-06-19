using System;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public class CItem : IItem
    {
        public IPlayer Owner { get; private set; }

        public IBoard Board { get; private set; }

        public SCordinate2D Cordinate2D { get; private set; }

        public void Place(IBoard board)
        {
            if (board.Board[Cordinate2D.Y, Cordinate2D.X] == this)
                Board = board;
            else
                board.Place(this);
        }

        public CItem(CItemInitializer itemInitializer)
        {
            Owner = itemInitializer.Owner;
        }
    }
}
