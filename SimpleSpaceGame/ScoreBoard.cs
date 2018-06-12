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

namespace SimpleSpaceGame
{
    public partial class ScoreBoard : Form
    {
        private PlayerRepository _playerRepository;
        private Font PixelFont_L;
        private Font PixelFont_M;
        private ListView listView;
        public ScoreBoard()
        {
            _playerRepository = new PlayerRepository();
            InitializeComponent();
            InitCustomFont();
            Styling();
            InitBoard();
            //this.listViewResults.View = View.Details;
            listViewResults.View = View.List;
        }

        private void InitBoard()
        {
            List<Player> players = _playerRepository.GetAll();
            int i = 1;
            foreach(var player in players)
            {
                string[] playerRow = { player.Name, player.Score.ToString() };
                var listViewItem = new ListViewItem(i.ToString() + ". " + playerRow[0] + " -> " + playerRow[1]);
                this.listViewResults.Items.Add(listViewItem);
                i++;
            }

        }

        private void Styling()
        {
            this.listViewResults.Font = PixelFont_M;
            this.label.Font = PixelFont_L;
        }

        private void InitCustomFont()
        {
            PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(@"..\..\fonts\04B_03__.TTF");
            PixelFont_L = new Font(privateFonts.Families[0], 24);
            PixelFont_M = new Font(privateFonts.Families[0], 16);
        }
    }
}
