using System;

namespace TTT_PCL.Abstractions
{ 
    public interface I_Player
    {
        I_Game Game { get; }

        string Name { get; }

        char Character { get; }
    }
}
