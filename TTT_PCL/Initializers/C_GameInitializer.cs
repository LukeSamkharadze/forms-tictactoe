using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Other;

namespace TTT_PCL.Initializers
{
    public class C_GameInitializer
    {
        public IList<I_Player> Players { get; set; }

        public S_BaseGameInfo BaseGameInfo { get; set; }

        public I_Board Board { get; set; }

        public I_Player Winner { get; set; }

        public bool IsGameEnded { get; set; }

        public I_Player WhooseTurn { get; set; }
    }
}
