using System;

using TTT_PCL.Abstractions;

namespace TTT_PCL.Other
{
    public class C_GameEndEventArgs : EventArgs
    {
        public I_Player Winner;
    }
}