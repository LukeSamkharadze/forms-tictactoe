using System;

using TTT_PCL.Abstractions.Player;
using TTT_PCL.Other;

namespace TTT_PCL.Initializers
{
    public class C_ItemInitializer
    {
        public I_Player Owner { get; set; }

        public S_Cordinate2D Cordinate2D { get; set; }
    }
}
