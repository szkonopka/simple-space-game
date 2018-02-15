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
        public Startup()
        {
            InitCustomFont();
            InitializeComponent();
            Styling();
        }

        private void Styling()
        {
            InitCustomFont();
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
            PixelFont = new Font(privateFonts.Families[0], 12);
        }

        private void labelNewGame_Click(object sender, EventArgs e)
        {
            SpaceWars game = new SpaceWars();
            game.ShowDialog();
        }

        private void labelExitGame_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Startup_Load(object sender, EventArgs e)
        {

        }
    }
}
