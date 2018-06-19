using System;

using TTT_PCL.Abstractions.Player;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public class CPlayer : IPlayer
    {
        public string Name { get; private set; }

        public char Character { get; private set; }

        public CPlayer(CPlayerInitializer playerInitializer)
        {
            Character = playerInitializer.Character;
        }
    }
}
