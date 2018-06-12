using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Xml.Linq;

namespace SimpleSpaceGame
{
    public partial class SaveResult : Form
    {
        private Font PixelFont;
        private XDocument _dox;
        private PlayerRepository _playerRepository;
        private int Score = 0;

        public SaveResult(int points)
        {
            _playerRepository = new PlayerRepository();
            InitializeComponent();
            InitCustomFont();
            Styling();
            this.labelPoints.Text = points.ToString();
            this.Score = points;
            this.textBoxName.Text = "";
        }

        private void Styling()
        {
            this.labelPoints.Font = PixelFont;
            this.labelGet.Font = PixelFont;
            this.labelName.Font = PixelFont;
            this.textBoxName.Font = PixelFont;
            this.buttonSubmit.Font = PixelFont;
        }

        private void InitCustomFont()
        {
            PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(@"..\..\fonts\04B_03__.TTF");
            PixelFont = new Font(privateFonts.Families[0], 16);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _playerRepository.Add(this.textBoxName.Text, this.Score);
            this.Close();
        }
    }
}
