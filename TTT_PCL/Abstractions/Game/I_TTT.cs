using System;

using TTT_PCL.Other;

namespace TTT_PCL.Abstractions.Game
{
    interface I_TTT : I_BoardGame
    {
        S_TTTMinToWin MinToWin { get; }
    }
}
