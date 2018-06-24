using System;

using TTT_PCL.Abstractions;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public sealed class C_Player : I_Player
    {
        public I_Game Game { get; private set; }

        public string Sign { get; private set; }

        public C_Player(C_PlayerInitializer playerInitializer)
        {
            Game = playerInitializer.Game;
            Sign = playerInitializer.Sign;
        }
    }
}
