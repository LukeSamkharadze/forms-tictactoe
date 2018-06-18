using System;

namespace TTT_PCL.Abstractions.Player
{
    public interface IPlayer
    {
        string Name { get; }

        char Character { get; }
    }
}
