using ChessClassLibrary;
using PokerClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinFormsApp
{
    public partial class FormPoker : Form
    {
        public FormPoker()
        {
            InitializeComponent();
            Dealer.InitDealer();
            Draw();
        }

        private void Draw() {
            pictureBox1.Image = new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\pokerRes\\pokertable.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            PlayerDataEventArgs args = new PlayerDataEventArgs
            {
                Name = textBoxPlayerName.Text.ToString(),
                Chips = Int32.Parse(textBoxChips.Text.ToString())
            };
            PokerEventsMediator.OnAddPlayer(null, args);
        }
    }
}
