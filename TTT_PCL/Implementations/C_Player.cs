using System;

using TTT_PCL.Abstractions.Player;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public class C_Player : I_Player
    {
        public string Name { get; private set; }

        public char Character { get; private set; }

        public C_Player(C_PlayerInitializer playerInitializer)
        {
            Name = playerInitializer.Name;
            Character = playerInitializer.Character;
        }
    }
}
