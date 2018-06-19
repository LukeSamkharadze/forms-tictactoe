using System;

using TTT_PCL.Abstractions.Player;

namespace TTT_PCL.Other
{
    public class CGameEndEventArgs : EventArgs
    {      
        public IPlayer Winner;
    }
}
