using ChessClassLibrary;
using PokerClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinFormsApp
{
    public partial class FormPoker : Form
    {
        private Bitmap bitmap = new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\pokerRes\\pokertable.png");
        private Bitmap chips = new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\pokerRes\\chips.png");

        private readonly Dictionary<Tuple<int, CardColor>, Bitmap> CardBitmaps = new Dictionary<Tuple<int, CardColor>, Bitmap>();
        Thread t1;

        public FormPoker()
        {
            InitializeComponent();
            LoadImages();
            PokerEventsMediator.UpdateGraphics += Update;
            PokerEventsMediator.StartBet += UpdateStartBet;

            TrackBar.CheckForIllegalCrossThreadCalls = false;  //temp

            t1 = new Thread(RefreshClock);

            Dealer.InitDealer();
            Clock.InitClock(10);
            Draw();
        }

        private Tuple<Card, Card> HandToDraw;
             
        Tuple<int, int>[] DrawCoords = {
            Tuple.Create(150, 80),
            Tuple.Create(580, 50)
        };

        Tuple<int, int>[] ChipsCoords = {
            Tuple.Create(150, 230),
            Tuple.Create(580, 200)
        };

        private void UpdateStartBet(object sender, PlayerDataEventArgs e) {
            //draw only current player cards
            string text = e.Chips.ToString();
            int max = e.Chips;
            trackBar1.Maximum = max;
            labelMax.Text = text;
        }

        private void Update(object sender, EventArgs e) {           

            int index = 0;
            foreach (var player in Round.Players)
            {
                HandToDraw = player.Hand;
                DrawHand(bitmap, DrawCoords[index].Item1, DrawCoords[index].Item2);
                DrawChips(bitmap, ChipsCoords[index].Item1, ChipsCoords[index].Item2);
                index++;
            }
            t1.Start();            
        }

        private void Draw() {            
            pictureBox1.Image = bitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        int MouseAtX, MouseAtY, AddSize = 0;

        int TileWidth, TileHeight = 60;

        private void DrawChips(Bitmap bitmap, int drawX, int drawY)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Bitmap ch = chips;
                Bitmap chresized = new Bitmap(ch, new Size(100, 100));
                graphics.DrawImage(chresized, new Point(drawX, drawY));
            }
            Draw();
        }

        private void buttonBet_Click(object sender, EventArgs e)
        {
            PlayerActionEventArgs args = new PlayerActionEventArgs {
                BetAmount = trackBar1.Value,
                Action = PlayerAction.Bet
            };
            PokerEventsMediator.OnPlayerAction(null, args);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            PlayerActionEventArgs args = new PlayerActionEventArgs
            {
                Action = PlayerAction.Check
            };
            PokerEventsMediator.OnPlayerAction(null, args);
        }

        private void buttonFold_Click(object sender, EventArgs e)
        {
            PlayerActionEventArgs args = new PlayerActionEventArgs
            {
                Action = PlayerAction.Fold
            };
            PokerEventsMediator.OnPlayerAction(null, args);
        }

        private void DrawHand(Bitmap bitmap, int drawX, int drawY)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Bitmap card1 = CardBitmaps[Tuple.Create(HandToDraw.Item1.Type.Item1, HandToDraw.Item1.Type.Item2)];
                Bitmap c1resized = new Bitmap(card1, new Size(180, 180));
                graphics.DrawImage(c1resized, new Point(drawX, drawY));

                Bitmap card2 = CardBitmaps[Tuple.Create(HandToDraw.Item2.Type.Item1, HandToDraw.Item2.Type.Item2)];
                Bitmap c2resized = new Bitmap(card2, new Size(180, 180));
                graphics.DrawImage(c2resized, new Point(drawX + 50, drawY));
            }
            Draw();
        }

        private void FormPoker_FormClosed(object sender, FormClosedEventArgs e)
        {
            t1?.Abort();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Dealer.StartGame();
            buttonStart.Enabled = false;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (!Clock.Stopped)
            {
                Clock.StopClock();
                buttonPause.Text = "Resume";
            }
            else if (Clock.Stopped)
            {
                Clock.ResumeClock();
                buttonPause.Text = "Pause";
            }
            
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
                
        private void LoadImages()
        {
            string path = "E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\pokerRes\\PNG\\";

            CardBitmaps.Add(Tuple.Create(1, CardColor.BlackHeart), new Bitmap(path + "AS.png"));
            CardBitmaps.Add(Tuple.Create(1, CardColor.RedHeart), new Bitmap(path + "AH.png"));
            CardBitmaps.Add(Tuple.Create(1, CardColor.Clover), new Bitmap(path + "AC.png"));
            CardBitmaps.Add(Tuple.Create(1, CardColor.Diamond), new Bitmap(path + "AD.png"));

            CardBitmaps.Add(Tuple.Create(2, CardColor.BlackHeart), new Bitmap(path + "2S.png"));
            CardBitmaps.Add(Tuple.Create(2, CardColor.RedHeart), new Bitmap(path + "2H.png"));
            CardBitmaps.Add(Tuple.Create(2, CardColor.Clover), new Bitmap(path + "2C.png"));
            CardBitmaps.Add(Tuple.Create(2, CardColor.Diamond), new Bitmap(path + "2D.png"));

            CardBitmaps.Add(Tuple.Create(3, CardColor.BlackHeart), new Bitmap(path + "3S.png"));
            CardBitmaps.Add(Tuple.Create(3, CardColor.RedHeart), new Bitmap(path + "3H.png"));
            CardBitmaps.Add(Tuple.Create(3, CardColor.Clover), new Bitmap(path + "3C.png"));
            CardBitmaps.Add(Tuple.Create(3, CardColor.Diamond), new Bitmap(path + "3D.png"));

            CardBitmaps.Add(Tuple.Create(4, CardColor.BlackHeart), new Bitmap(path + "4S.png"));
            CardBitmaps.Add(Tuple.Create(4, CardColor.RedHeart), new Bitmap(path + "4H.png"));
            CardBitmaps.Add(Tuple.Create(4, CardColor.Clover), new Bitmap(path + "4C.png"));
            CardBitmaps.Add(Tuple.Create(4, CardColor.Diamond), new Bitmap(path + "4D.png"));

            CardBitmaps.Add(Tuple.Create(5, CardColor.BlackHeart), new Bitmap(path + "5S.png"));
            CardBitmaps.Add(Tuple.Create(5, CardColor.RedHeart), new Bitmap(path + "5H.png"));
            CardBitmaps.Add(Tuple.Create(5, CardColor.Clover), new Bitmap(path + "5C.png"));
            CardBitmaps.Add(Tuple.Create(5, CardColor.Diamond), new Bitmap(path + "5D.png"));

            CardBitmaps.Add(Tuple.Create(6, CardColor.BlackHeart), new Bitmap(path + "6S.png"));
            CardBitmaps.Add(Tuple.Create(6, CardColor.RedHeart), new Bitmap(path + "6H.png"));
            CardBitmaps.Add(Tuple.Create(6, CardColor.Clover), new Bitmap(path + "6C.png"));
            CardBitmaps.Add(Tuple.Create(6, CardColor.Diamond), new Bitmap(path + "6D.png"));

            CardBitmaps.Add(Tuple.Create(7, CardColor.BlackHeart), new Bitmap(path + "7S.png"));
            CardBitmaps.Add(Tuple.Create(7, CardColor.RedHeart), new Bitmap(path + "7H.png"));
            CardBitmaps.Add(Tuple.Create(7, CardColor.Clover), new Bitmap(path + "7C.png"));
            CardBitmaps.Add(Tuple.Create(7, CardColor.Diamond), new Bitmap(path + "7D.png"));

            CardBitmaps.Add(Tuple.Create(8, CardColor.BlackHeart), new Bitmap(path + "8S.png"));
            CardBitmaps.Add(Tuple.Create(8, CardColor.RedHeart), new Bitmap(path + "8H.png"));
            CardBitmaps.Add(Tuple.Create(8, CardColor.Clover), new Bitmap(path + "8C.png"));
            CardBitmaps.Add(Tuple.Create(8, CardColor.Diamond), new Bitmap(path + "8D.png"));

            CardBitmaps.Add(Tuple.Create(9, CardColor.BlackHeart), new Bitmap(path + "9S.png"));
            CardBitmaps.Add(Tuple.Create(9, CardColor.RedHeart), new Bitmap(path + "9H.png"));
            CardBitmaps.Add(Tuple.Create(9, CardColor.Clover), new Bitmap(path + "9C.png"));
            CardBitmaps.Add(Tuple.Create(9, CardColor.Diamond), new Bitmap(path + "9D.png"));

            CardBitmaps.Add(Tuple.Create(10, CardColor.BlackHeart), new Bitmap(path + "10S.png"));
            CardBitmaps.Add(Tuple.Create(10, CardColor.RedHeart), new Bitmap(path + "10H.png"));
            CardBitmaps.Add(Tuple.Create(10, CardColor.Clover), new Bitmap(path + "10C.png"));
            CardBitmaps.Add(Tuple.Create(10, CardColor.Diamond), new Bitmap(path + "10D.png"));

            CardBitmaps.Add(Tuple.Create(11, CardColor.BlackHeart), new Bitmap(path + "JS.png"));
            CardBitmaps.Add(Tuple.Create(11, CardColor.RedHeart), new Bitmap(path + "JH.png"));
            CardBitmaps.Add(Tuple.Create(11, CardColor.Clover), new Bitmap(path + "JC.png"));
            CardBitmaps.Add(Tuple.Create(11, CardColor.Diamond), new Bitmap(path + "JD.png"));

            CardBitmaps.Add(Tuple.Create(12, CardColor.BlackHeart), new Bitmap(path + "QS.png"));
            CardBitmaps.Add(Tuple.Create(12, CardColor.RedHeart), new Bitmap(path + "QH.png"));
            CardBitmaps.Add(Tuple.Create(12, CardColor.Clover), new Bitmap(path + "QC.png"));
            CardBitmaps.Add(Tuple.Create(12, CardColor.Diamond), new Bitmap(path + "QD.png"));

            CardBitmaps.Add(Tuple.Create(13, CardColor.BlackHeart), new Bitmap(path + "KS.png"));
            CardBitmaps.Add(Tuple.Create(13, CardColor.RedHeart), new Bitmap(path + "KH.png"));
            CardBitmaps.Add(Tuple.Create(13, CardColor.Clover), new Bitmap(path + "KC.png"));
            CardBitmaps.Add(Tuple.Create(13, CardColor.Diamond), new Bitmap(path + "KD.png"));
        }

        private void RefreshClock()
        {
            while (true)
            {
                MethodInvoker mi = delegate () {
                    double timeleft = Clock.GetTimeLeft().TotalSeconds;
                    if (timeleft <= 0)
                    {
                        Clock.StopClock();
                        PlayerActionEventArgs args = new PlayerActionEventArgs { Action = PlayerAction.Fold };
                        PokerEventsMediator.OnPlayerAction(null, args);
                    }
                    label1.Text = Clock.GetTimeLeft().ToString(@"hh\:mm\:ss");      // hh\:mm\:ss\:fff                    
                };
                this.Invoke(mi);
            }
        }

    }
}
