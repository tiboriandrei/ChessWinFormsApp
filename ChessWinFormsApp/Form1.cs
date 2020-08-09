﻿using ChessClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinFormsApp
{
    public partial class Form1 : Form
    {
        private Bitmap _Bitmap;
        private int TileWidth { get; set; } = 60;
        private int TileHeight { get; set; } = 60;

        int MouseAtX = 0;
        int MouseAtY = 0;
        int AddSize = 0;

        Thread t1;

        List<Move> availableMoves;
        Bitmap availableSquare;

        public Dictionary<string, Bitmap> PieceBitmaps { get; set; } = new Dictionary<string, Bitmap>();

        private Game newGame;
        public Form1()
        {
            InitializeComponent();

            GameState.InitGameState();

            newGame = GameModeFactory.InitializeGame(GameModeOption.Normal);
            availableMoves = new List<Move>();
            availableSquare = new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\alphasquare.png");

            //-----------------------------------------------------------------------

            PieceBitmaps.Add("WhitePawn", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\whitepawn.png"));
            PieceBitmaps.Add("WhiteRook", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\whiterook.png"));
            PieceBitmaps.Add("WhiteKing", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\whiteking.png"));
            PieceBitmaps.Add("WhiteHorseman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\whitehorseman.png"));
            PieceBitmaps.Add("WhiteMadman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\whitemadman.png"));
            PieceBitmaps.Add("WhiteQueen", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\whitequeen.png"));

            PieceBitmaps.Add("BlackPawn", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\blackpawn.png"));
            PieceBitmaps.Add("BlackKing", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\blackking.png"));
            PieceBitmaps.Add("BlackHorseman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\blackhorseman.png"));
            PieceBitmaps.Add("BlackMadman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\blackmadman.png"));
            PieceBitmaps.Add("BlackQueen", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\blackqueen.png"));
            PieceBitmaps.Add("BlackRook", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\blackrook.png"));          
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Draw();                        
        }

        private void Draw() {
            var tileSize = new Size(TileWidth, TileHeight);
            _Bitmap = CreateBoard(tileSize);
            DrawPieces(_Bitmap);
            if (availableMoves.Count > 0)
            {
                DrawAvailableMoves(_Bitmap);
            }            
            pictureBox1.Image = _Bitmap;
        }

        private Bitmap CreateBoard(Size tileSize)
        {
            int tileWidth = tileSize.Width;
            int tileHeight = tileSize.Height;
            var bitmap = new Bitmap(tileWidth * 8, tileHeight * 8);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        Brush brush = (x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0) ? Brushes.Gray : Brushes.White;
                        graphics.FillRectangle(brush, new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight));
                    }
                }
            }
            return bitmap;
        }

        private Bitmap DrawAvailableMoves(Bitmap bitmap) {
            
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                foreach (var move in availableMoves)
                {
                    Bitmap resized = new Bitmap(availableSquare, new Size(TileWidth, TileHeight));
                    graphics.DrawImage(resized, new Point((7 - move.Destination.Item2) * TileWidth ,
                                                          (move.Destination.Item1) * TileHeight));

                    //Bitmap test = PieceBitmaps["BlackPawn"];
                    //Bitmap testPiece = new Bitmap(test, new Size(TileWidth, TileHeight));
                    //graphics.DrawImage(testPiece, new Point((7 - move.Destination.Item2) * TileWidth,
                    //                                      (7 - move.Destination.Item1) * TileHeight));
                }
            }
            return bitmap;
        }
  
        private void DrawPieces(Bitmap bitmap)
        {            
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                var Layout = GameState.GetGameState();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Layout[i][7 - j] != null)
                        {                            
                                ChessPiece piece = Layout[i][7 - j];
                                                                    
                                Bitmap original = PieceBitmaps[piece.ToString()];

                                if (i == MouseAtX && j == MouseAtY)
                                {
                                    AddSize = TileWidth / 4;
                                }
                                Bitmap resized = new Bitmap(original, new Size(TileWidth - (TileWidth / 4) + AddSize, TileHeight - (TileHeight / 4) + AddSize));                                
                                graphics.DrawImage(resized, new Point(j * TileWidth + (TileWidth / 8) - (AddSize / 2), i * TileHeight + (TileHeight / 8) - (AddSize / 2) ));
                                AddSize = 0;                           
                        }  
                    }
                }
            }
        }
                
        private void Form1_Load(object sender, EventArgs e)
        {
            t1 = new Thread(RefreshClock);
            t1.Start();
        }

        private void RefreshClock() {
            while (newGame._BlacksTimer.GetTimeLeft().TotalSeconds > 0 && newGame._WhitesTimer.GetTimeLeft().TotalSeconds > 0) {

                MethodInvoker mi = delegate () { 
                    labelBlackTime.Text = newGame._BlacksTimer.GetTimeLeft().ToString(@"hh\:mm\:ss\:fff");
                    labelWhiteTime.Text = newGame._WhitesTimer.GetTimeLeft().ToString(@"hh\:mm\:ss\:fff");
                };
                this.Invoke(mi);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            double ratio = Math.Min(this.Width / 60, this.Height / 60);
            TileWidth = (int)(4 * ratio);
            TileHeight = (int)(4 * ratio);
            Draw();
        }

        int timer = 0;
        Tuple<int, int> selectedPieceCoords = Tuple.Create(-1, -1);
        Tuple<int, int> selectedTargetCoords;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            labelMouseLocation.Text = "Clicked at x: " + coordinates.X / 60 + " y: " + (7 - coordinates.Y / 60);

            selectedTargetCoords = Coordinate.GetInstance.GetCoord((coordinates.Y / 60), (7 - coordinates.X / 60));

            Move attemptedMove = new Move(selectedPieceCoords, selectedTargetCoords);

            if (availableMoves.Any(coord => coord.Origin.Item2 == attemptedMove.Origin.Item2 && coord.Origin.Item1 == attemptedMove.Origin.Item1 && 
                                            coord.Destination.Item2 == attemptedMove.Destination.Item2 && coord.Destination.Item1 == attemptedMove.Destination.Item1))
            {
                GameState.UpdateLayout(attemptedMove);
                selectedPieceCoords = Tuple.Create(-1, -1);
            }
            else {
                selectedPieceCoords = Coordinate.GetInstance.GetCoord((coordinates.Y / 60), (7 - coordinates.X / 60));
                availableMoves = Referee.GetAvailableMoves(selectedPieceCoords);
            }

            Draw();
        }

        // labelMouseLocation.Text = "Mouse at x: " + (pos.X / 60) + " y: " + (7 - pos.Y / 60);      //for checkmove logic

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mPos = pictureBox1.PointToClient(Cursor.Position);

            //labelMouseLocation.Text = "Mouse at x: " + (7 - pos.Y / 60) + " y: " + (pos.X / 60);  

            if (mPos.X / TileHeight >= 0 && mPos.X / TileWidth <= 7 && mPos.Y / TileHeight >= 0 && mPos.Y / TileWidth <= 7)
            {
                MouseAtX = (mPos.Y / TileWidth);
                MouseAtY = (mPos.X / TileHeight);

                //Draw();
            }
        }

        private void buttonClock_Click(object sender, EventArgs e)
        {
            newGame._BlacksTimer.ResumeClock();
            newGame._WhitesTimer.ResumeClock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newGame._BlacksTimer.StopClock();
            newGame._WhitesTimer.StopClock();
        }
    }
}
