using System;

using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Player;
using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Item
{
    public interface I_Item
    {
        I_Player Owner { get; }

        I_Board Board { get; }

        S_Cordinate2D Cordinate2D { get; }

        void Place(I_Board board,S_Cordinate2D cordinate2D);
    }
}