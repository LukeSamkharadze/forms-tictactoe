using System;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public class C_Item : I_Item
    {
        public I_Player Owner { get; private set; }

        public I_Board Board { get; private set; }

        public S_Cordinate2D Cordinate2D { get; private set; }

        public void Place(I_Board board,S_Cordinate2D cordinate2D)
        {
            if (board.Board[Cordinate2D.Y, Cordinate2D.X] == this)
                Board = board;
            else
                board.Place(this, cordinate2D);
        }

        public C_Item(C_ItemInitializer itemInitializer)
        {
            Owner = itemInitializer.Owner;
        }
    }
}
