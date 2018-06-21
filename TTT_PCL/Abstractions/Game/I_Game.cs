using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions.Player;

namespace TTT_PCL.Abstractions.Game
{
    public interface I_Game
    {
        IList<I_Player> Players { get; }

        I_Player Winner { get; }

        bool IsGameEnded { get; }

        event EventHandler onEnd;

        I_Player CheckWinner();
    }
}
