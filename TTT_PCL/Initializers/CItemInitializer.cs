using System;

using TTT_PCL.Abstractions;
using TTT_PCL.Other;

namespace TTT_PCL.Initializers
{
    public class CItemInitializer
    {
        public IPlayer Owner { get; set; }

        public SCordinate2D Cordinate2D { get; set; }
    }
}
