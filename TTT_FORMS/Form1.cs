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
    public sealed partial class Form1 : Form
    {
        List<Button> buttons;

        C_Game game;

        public Form1()
        {
            InitializeComponent();
      
            buttons = new List<Button>();
            AssignEventsOnPlayButtons();
            ResetGame();
            game.onEnd += OnEnd;
        }

        private void ResetGame()
        {
            game = new C_Game(new C_GameInitializer()
            {
                PlayerSigns = new List<string>() { "X" },
                MinToWin = new S_MinToWin(new S_MinToWinInitializer() { MinToWinHorizontally = 3, MinToWinVertically = 3, MinToWinDiagonally = 3 }),
                boardInitializer = new C_BoardInitializer() { Dimensions = new S_Dimensions2D() { Length = 5, Width = 5 } }
            });

        }

        private void ResetTextsOnPlayButtons()
        {
            foreach (var button in buttons)
                button.Text = null;
        }

        private void ButtonClick(object sender, EventArgs eventArgs)
        {
            if (game.IsGameEnded == false)
            {
                Button button = sender as Button;

                S_Cordinate2D cordinate2D = new S_Cordinate2D()
                {
                    Y = Int32.Parse(button.Tag.ToString()[0].ToString()),
                    X = Int32.Parse(button.Tag.ToString()[1].ToString())
                };

                if (game.Board.Place(game.WhooseTurn.Current.Sign, cordinate2D))
                    button.Text = game.WhooseTurn.Current.Sign;

                game.Iterate();
                game.CheckWinner();
            }
        }

        private void OnEnd(object sender, EventArgs eventArgs)
        {
            MessageBox.Show($"{(eventArgs as C_GameEndEventArgs).Winner.Sign} IS THE WINNER");
        }

        private void AssignEventsOnPlayButtons()
        {
            foreach (var button in this.Controls.OfType<Button>().Where(o => o.Name?.ToString().Contains("PlayButton") == true))
            {
                buttons.Add(button);
                button.Click += ButtonClick;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetGame();
            ResetTextsOnPlayButtons();
        }
    }
}
