using ChessClassLibrary;
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
    public partial class Form1 : Form
    {
        private int TileWidth { get; set; } = 60;
        private int TileHeight { get; set; } = 60;

        public Dictionary<string, Bitmap> PieceBitmaps { get; set; } = new Dictionary<string, Bitmap>();

        public Form1()
        {
            InitializeComponent();

            GameState.InitGameState();

            var newGame = GameModeFactory.InitializeGame(GameModeOption.Normal);

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

        public Bitmap _Bitmap;

        private void Draw() {
            var tileSize = new Size(TileWidth, TileHeight);
            _Bitmap = CreateBoard(tileSize);
            DrawPieces(_Bitmap);
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

        int MouseAtX = 0;
        int MouseAtY = 0;
       
        private void DrawPieces(Bitmap bitmap)
        {
            int AddSize = 0;
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                var Layout = GameState.GetGameState();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Layout.ContainsKey(i))
                        {
                            if (Layout[i].ContainsKey(j))
                            {
                                ChessPiece piece = Layout[i][j];
                                                                    
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            double ratio = Math.Min(this.Width / 60, this.Height / 60);
            TileWidth = (int)(4 * ratio);
            TileHeight = (int)(4 * ratio);
            Draw();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            labelMouseLocation.Text = "Clicked at x: " + coordinates.X / 60 + " y: " + (7 - coordinates.Y / 60);

            var coords = Coordinate.GetInstance.GetCoord(coordinates.X / 60, (7 - coordinates.Y / 60));
            Console.WriteLine();
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
    }
}
