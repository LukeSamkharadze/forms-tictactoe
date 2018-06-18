using System;

using TTT_PCL.Abstractions;

namespace TTT_PCL.Other
{
    public class CGameEndEventArgs : EventArgs
    {
        public IPlayer Winner;
    }
}
