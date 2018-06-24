using System;
using System.Collections.Generic;

using TTT_PCL.Other;

namespace TTT_PCL.Abstractions
{
    public interface I_Game
    {
        IList<I_Player> Players { get; }

        I_Board Board { get; }

        IEnumerator<I_Player> WhooseTurn { get; }

        I_Player Winner { get; }

        S_MinToWin MinToWin { get; }

        bool IsGameEnded { get; }

        event EventHandler onEnd;

        I_Player Iterate();

        I_Player CheckWinner();
    }
}
