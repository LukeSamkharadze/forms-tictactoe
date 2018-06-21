using System;

using TTT_PCL.Abstractions.Player;

namespace TTT_PCL.Other
{
    public class C_GameEndEventArgs : EventArgs
    {      
        public I_Player Winner;
    }
}
