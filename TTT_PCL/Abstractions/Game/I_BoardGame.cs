using System;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions.Item;
using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Game
{
    public interface I_BoardGame : I_Game
    {
        I_Board Board { get; }

        I_Player WhooseTurn { get; }

        bool Place(I_Item item, S_Cordinate2D cordinate2D);

        I_Item Take(S_Cordinate2D cordinate2D);
    }
}
