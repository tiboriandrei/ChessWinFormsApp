using ChessClassLibrary;
using GameRepository.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ChessWinFormsApp
{
    public partial class Form1 : Form
    {
        private Bitmap _Bitmap;

        private Game currentGame = null;
        private int TileWidth { get; set; } = 60;
        private int TileHeight { get; set; } = 60;

        int MouseAtX = 0;
        int MouseAtY = 0;
        int AddSize = 0;

        Thread t1;

        List<Move> availableMoves;        
        Bitmap availableSquare;

        public Dictionary<string, Bitmap> PieceBitmaps { get; set; } = new Dictionary<string, Bitmap>();

        public Form1()
        {
            InitializeComponent();
            GameState.InitGameState();
            Referee.InitReferee();
            EventsMediator.Winner += GameOver;

            //currentGame = GameModeFactory.InitializeGame(GameModeOption.Blitz);                       
            //string fullyQualifiedName = currentGame.GetType().AssemblyQualifiedName;

            availableMoves = new List<Move>();

            t1 = new Thread(RefreshClock);

            LoadImages();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void GameOver(object sender, PlayerEventArgs e) {
            labelWinner.Text = e.pieceColor.ToString() + " lost";
            currentGame._ChessClock._BlacksTimer.StopClock();
            currentGame._ChessClock._WhitesTimer.StopClock();
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

            if (!t1.IsAlive)
            {
                t1.Start();
            }            
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
            
        }

        private void RefreshClock() {
            while (true) {
                MethodInvoker mi = delegate () {
                    labelBlackTime.Text = currentGame._ChessClock._BlacksTimer.GetTimeLeft().ToString(@"hh\:mm\:ss");      // hh\:mm\:ss\:fff
                    labelWhiteTime.Text = currentGame._ChessClock._WhitesTimer.GetTimeLeft().ToString(@"hh\:mm\:ss");
                };
                this.Invoke(mi);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            double ratio = Math.Min(this.Width / 60, this.Height / 60);
            TileWidth = (int)(4 * ratio);
            TileHeight = (int)(4 * ratio);
            if (currentGame != null)
            {
                Draw();
            }            
        }
                
        Tuple<int, int> selectedPieceCoords = Tuple.Create(-1, -1);
        Tuple<int, int> selectedTargetCoords;
        int x, y;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            labelMouseLocation.Text = "Clicked at x: " + coordinates.X / 60 + " y: " + (7 - coordinates.Y / 60);

            x = (coordinates.Y / 60);
            y = (7 - coordinates.X / 60);
            selectedTargetCoords = Coordinate.GetInstance.GetCoord(x, y);
            
            Move attemptedMove = new Move(selectedPieceCoords, selectedTargetCoords);

            if (HelperMaths.ContainsObjectMove(availableMoves, attemptedMove))
            {
                GameState.UpdateLayout(attemptedMove);
                selectedPieceCoords = Tuple.Create(-1, -1);
                availableMoves.Clear();
            }
            else {
                selectedPieceCoords = Coordinate.GetInstance.GetCoord(x, y);
                availableMoves = Referee.GetAvailableMoves(selectedPieceCoords);
            }

            Draw();
        }

        // labelMouseLocation.Text = "Mouse at x: " + (pos.X / 60) + " y: " + (7 - pos.Y / 60);      //for checkmove logic

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mPos = pictureBox1.PointToClient(Cursor.Position);

            //labelMouseLocation.Text = "Mouse at x: " + (7 - mPos.Y / 60) + " y: " + (mPos.X / 60);  

            if (mPos.X / TileHeight >= 0 && mPos.X / TileWidth <= 7 && mPos.Y / TileHeight >= 0 && mPos.Y / TileWidth <= 7)
            {
                MouseAtX = (mPos.Y / TileWidth);
                MouseAtY = (mPos.X / TileHeight);

                //Draw();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t1?.Abort();                       
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperMaths.SaveObj(GameState.GetGameState(), "tempName");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            string file;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                try
                {
                    HelperMaths.LoadSerializedObj<Dictionary<int, Dictionary<int, ChessPiece>>>(file);
                }
                catch (Exception)
                {
                                        
                }
                
            }
            
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            EventsMediator.OnUndo(null, EventArgs.Empty);
            Draw();
        }

        private void blitzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentGame = GameFactory.GetGame(GameModeOption.Blitz);
            Draw();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentGame = GameFactory.GetGame(GameModeOption.Normal);
            Draw();
        }

        private void LoadImages() {
            availableSquare = new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\alphasquare.png");

            PieceBitmaps.Add("WhitePawn", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\whitepawn.png"));
            PieceBitmaps.Add("WhiteRook", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\whiterook.png"));
            PieceBitmaps.Add("WhiteKing", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\whiteking.png"));
            PieceBitmaps.Add("WhiteHorseman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\whitehorseman.png"));
            PieceBitmaps.Add("WhiteMadman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\whitemadman.png"));
            PieceBitmaps.Add("WhiteQueen", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\whitequeen.png"));

            PieceBitmaps.Add("BlackPawn", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\blackpawn.png"));
            PieceBitmaps.Add("BlackKing", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\blackking.png"));
            PieceBitmaps.Add("BlackHorseman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\blackhorseman.png"));
            PieceBitmaps.Add("BlackMadman", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\blackmadman.png"));
            PieceBitmaps.Add("BlackQueen", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\blackqueen.png"));
            PieceBitmaps.Add("BlackRook", new Bitmap("E:\\ChessWinFormsApp\\ChessWinFormsApp\\ChessWinFormsApp\\chessRes\\blackrook.png"));
        }
    }
}
