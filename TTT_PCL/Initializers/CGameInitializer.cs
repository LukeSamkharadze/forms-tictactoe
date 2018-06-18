using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Abstractions.Board;
using TTT_PCL.Abstractions;

using TTT_PCL.Other;

namespace TTT_PCL.Initializers
{
    public class CGameInitializer
    {
        public IList<IPlayer> Players { get; set; }

        public CBaseGameInfo BaseGameInfo { get; set; }

        public IBoard Board { get; set; }

        public IPlayer Winner { get; set; }
    }
}
