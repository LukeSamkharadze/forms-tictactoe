using System;

using TTT_PCL.Initializers;

namespace TTT_PCL.Other
{
    public struct S_MinToWin
    {
        public int MinToWinHorizontally { get; }

        public int MinToWinVertically { get; }

        public int MinToWinDiagonally { get; }

        public S_MinToWin(S_MinToWinInitializer minToWinInitializer)
        {
            MinToWinHorizontally = minToWinInitializer.MinToWinHorizontally;
            MinToWinVertically = minToWinInitializer.MinToWinVertically;
            MinToWinDiagonally = minToWinInitializer.MinToWinDiagonally;
        }
    }
}
