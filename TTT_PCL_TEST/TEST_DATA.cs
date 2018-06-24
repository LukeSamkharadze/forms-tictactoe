using System;
using System.Collections.Generic;

using TTT_PCL.Abstractions;
using TTT_PCL.Implementations;

using TTT_PCL.Initializers;

using TTT_PCL.Other;

namespace TTT_PCL_TEST
{
    public static class TEST_Data
    {
        public static S_MinToWin MinToWin { get; } = new S_MinToWin() { MinToWinHorizontally = 3, MinToWinVertically = 3, MinToWinDiagonally = 3 };

        public static C_Player PlayerX { get; } = new C_Player(new C_PlayerInitializer() { Character = 'X' });
        public static C_Player PlayerO { get; } = new C_Player(new C_PlayerInitializer() { Character = 'O' });

        public static C_Board Board = new C_Board(new C_BoardInitializer()
        {
            Board = new char[3,3]
        });
   
        public static C_Game Game { get; } = new C_Game(new C_GameInitializer()
        {
            Players = new List<I_Player> { PlayerX, PlayerO },
            MinToWin = MinToWin,
            Board = Board
        }
        );
    }
}
