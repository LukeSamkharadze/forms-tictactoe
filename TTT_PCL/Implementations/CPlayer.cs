using System;

using TTT_PCL.Abstractions;

using TTT_PCL.Initializers;

namespace TTT_PCL.Implementations
{
    public class CPlayer : IPlayer
    {
        public char Character { get; private set; }

        public CPlayer(CPlayerInitializer playerInitializer)
        {
            Character = playerInitializer.Character;
        }
    }
}
