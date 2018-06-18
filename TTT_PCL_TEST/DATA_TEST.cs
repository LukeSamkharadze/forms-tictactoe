using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions;
using TTT_PCL.Implementations;

using TTT_PCL.Initializers;

using TTT_PCL.Other;

namespace TTT_PCL_TEST
{
    public static class Data_TEST
    {
        public static CBaseGameInfo BaseGameInfo { get; } = new CBaseGameInfo() { MinToWinHorizontally = 3, MinToWinVertically = 3, MinToWinDiagonally = 3 };

        public static CPlayer PlayerX { get; } = new CPlayer(new CPlayerInitializer() { Character = 'X' });
        public static CPlayer PlayerO { get; } = new CPlayer(new CPlayerInitializer() { Character = 'O' });

        public static CItem ItemX { get; } = new CItem(new CItemInitializer() { Owner = PlayerX });
        public static CItem ItemO { get; } = new CItem(new CItemInitializer() { Owner = PlayerO });

        public static CBoard Board = new CBoard(new CBoardInitializer()
        {
            Board = new CItem[,] { { ItemX, ItemX, ItemX }, { ItemO, ItemX, ItemO }, { ItemO, ItemX, ItemO } }
        });

        public static CGame Game { get; } = new CGame(new CGameInitializer()
        {
            Players = new List<IPlayer> { PlayerX, PlayerO },
            BaseGameInfo = BaseGameInfo,
            Board = Board
        }
        );
    }
}
