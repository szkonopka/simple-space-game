using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSpaceGame
{
    public partial class Startup : Form
    {
        private Font PixelFont;
        private Label[] Menu;
        private int CurrentLabelIndex = 0;
        public Startup()
        {
            InitCustomFont();
            InitializeComponent();
            Menu = new Label[3] { this.labelNewGame, this.labelScoreBoard, this.labelExitGame };
            Styling();
            this.labelNewGame.ForeColor = Color.Violet;
            
        }

        private void Styling()
        {
            InitCustomFont();
            foreach(var label in Menu)
            {
                label.Font = PixelFont;
            }
            this.labelNewGame.Font = PixelFont;
            this.labelExitGame.Font = PixelFont;
            this.labelScoreBoard.Font = PixelFont;
        }

        /// <summary>
        /// Inicjalizacja customowej czcionki z folderu resources
        /// </summary>
        private void InitCustomFont()
        {
            PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(@"..\..\fonts\04B_03__.TTF");
            PixelFont = new Font(privateFonts.Families[0], 24);
        }

        private void StartGame()
        {
            SpaceWars game = new SpaceWars();
            this.Visible = false;
            game.ShowDialog();
            this.Visible = true;
        }

        private void ExitGame()
        {
            Environment.Exit(0);
        }

        private void ShowScoreBoard()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            this.Visible = false;
            scoreBoard.ShowDialog();
            this.Visible = true;
        }

        private void labelNewGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void labelExitGame_Click(object sender, EventArgs e)
        {
            ExitGame();
        }

        private void Startup_Load(object sender, EventArgs e)
        {

        }

        private void Startup_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var label in Menu)
            {
                label.ForeColor = Color.DeepPink;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                CurrentLabelIndex++;
                Menu[CurrentLabelIndex % Menu.Length].ForeColor = Color.Violet;
            }

            if(e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                CurrentLabelIndex--;
                if (CurrentLabelIndex < 0) CurrentLabelIndex = Menu.Length - 1;
                Menu[CurrentLabelIndex % Menu.Length].ForeColor = Color.Violet;
            }

            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                switch(CurrentLabelIndex)
                {
                    case 0:
                        StartGame();
                        break;
                    case 1:
                        ShowScoreBoard();
                        break;
                    case 2:
                        ExitGame();
                        break;
                    default:
                        StartGame();
                        break;
                }
            }
        }

        private void labelScoreBoard_Click(object sender, EventArgs e)
        {
            ShowScoreBoard();
        }
    }
}
