using System;
using System.Collections.Generic;

using TTT_PCL.Other;

namespace TTT_PCL.Initializers
{
    public class C_GameInitializer
    {
        public IList<string> PlayerSigns { get; set; }

        public C_BoardInitializer boardInitializer { get; set; }

        public S_MinToWin MinToWin { get; set; }
    }
}
