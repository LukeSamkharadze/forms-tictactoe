using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions.Player;

namespace TTT_PCL.Abstractions.Game
{
    public interface IGame
    {
        IList<IPlayer> Players { get; }
        IPlayer Winner { get; }

        event EventHandler onEnd;

        IPlayer CheckWinner();
    }
}
