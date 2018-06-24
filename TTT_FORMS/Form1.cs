using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TTT_PCL.Implementations;
using TTT_PCL.Initializers;
using TTT_PCL.Other;

namespace TTT_FORMS
{
    public partial class Form1 : Form
    {
        C_Game game;

        public Form1()
        {
            InitializeComponent();

            game = new C_Game(new C_GameInitializer()
            {
                PlayerSigns = new List<string>() { "XXX", "OOO", "YYY" },
                MinToWin = new S_MinToWin() { MinToWinHorizontally = 3, MinToWinVertically = 3, MinToWinDiagonally = 3 },
                boardInitializer = new C_BoardInitializer() { Dimensions = new S_Dimensions2D() { Length = 5, Width = 5 } }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
