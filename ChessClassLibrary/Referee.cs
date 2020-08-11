using ChessClassLibrary.Clocks;
using ChessClassLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using System.Collections.Concurrent;
using System.Linq;

namespace ChessClassLibrary
{
    public static class Referee
    {
        public static PieceColor PlayerTurn { get; set; } = PieceColor.White;

        private static List<Move> AvailableMoves = new List<Move>();

        //private static ConcurrentDictionary<int, Move> myThrSafeDict = new ConcurrentDictionary<int, Move>();

        public static void InitReferee() {
            EventsMediator.PlayerMoved += ChangePlayerTurn;
            EventsMediator.TimesUp += EndGame; 
        }

        //private static void newThreadFunc(int key, Move testMove) 
        //{
        //    var scenario = GameState.GetScenario(testMove);
        //    if (TestKingChecks(scenario))
        //    {
        //        myThrSafeDict.TryRemove(key, out _);                
        //    }
        //}
       
        public static List<Move> GetAvailableMoves(Tuple<int, int> selectedPieceCoords) {

            
            AvailableMoves.Clear();
            var Layout = GameState.GetGameState();

            if (Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2] == null)
            {
                return new List<Move>();
            }
            if (Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].PieceColor != PlayerTurn)
            {
                return new List<Move>();
            }

            AvailableMoves = Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].GetAvailableMoves(selectedPieceCoords);
                        
            //for (int i = 0; i < AvailableMoves.Count; i++)
            //{
            //    myThrSafeDict.GetOrAdd(i, AvailableMoves[i]);
            //}

            //for (int i = 0; i < myThrSafeDict.Count; i++)
            //{
            //    Move testMove = myThrSafeDict[i];

            //    Thread thr = new Thread(() => newThreadFunc(i, testMove));
            //    thr.Start();
            //}

            //List<Move> list = new List<Move>();
            //Thread.Sleep(1000);
            //foreach (var item in myThrSafeDict)
            //{
            //    list.Add(item.Value);
            //}            

            for (int i = 0; i < AvailableMoves.Count; i++)          
            {
                Move testMove = AvailableMoves[i];
                var scenario = GameState.GetScenario(testMove);

                if (TestKingChecks(scenario))
                {
                    AvailableMoves.RemoveAt(i);
                    i--;
                }
            }

            foreach (Move move in AvailableMoves)
            {      
                //Thread thr = new Thread( () => TestKingChecks(scenario) );
                //if king is checked in move scenario, delete move from list. (use threads maybe)
            }

            //if list.count == 0 , invoke check mate event

            return AvailableMoves;
        }

        private static bool TestKingChecks(Dictionary<int, Dictionary<int, ChessPiece>> scenario) {
            bool KingChecked = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (scenario[i][j] != null)
                    {
                        if (scenario[i][j].ToString() == PlayerTurn.ToString() + "King")
                        {
                            KingChecked = false;

                            PieceColor enemy;
                            if (PlayerTurn == PieceColor.Black)
                            {
                                enemy = PieceColor.White;
                            }
                            else { enemy = PieceColor.Black; }

                            if (HelperMaths.EnemyPawnCheck(i, j, scenario, enemy) || HelperMaths.HorizontalThreatCheck(i, j, scenario, enemy) ||
                                HelperMaths.DiagonalThreatCheck(i, j, scenario, enemy))
                            {
                                KingChecked = true;
                            }

                            //KingChecked = HelperMaths.EnemyPawnCheck(i, j, scenario, enemy);
                            //KingChecked = HelperMaths.HorizontalThreatCheck(i, j, scenario, enemy);
                            //KingChecked = HelperMaths.DiagonalThreatCheck(i, j, scenario, enemy);
                            //KingChecked = HelperMaths.HorseThreatCheck(i, j, scenario, enemy);

                            break;
                        }
                    }                    
                }
            }

            if (KingChecked)
            {

            }

            return KingChecked;            
        }

        private static void ChangePlayerTurn(object sender, PlayerEventArgs e)
        {
            if (PlayerTurn == PieceColor.White)
            {
                PlayerTurn = PieceColor.Black;                
            }
            else
            {
                PlayerTurn = PieceColor.White;
            }
        }

        private static void EndGame(object sender, EventArgs e) {

            PlayerEventArgs args = new PlayerEventArgs
            {
                pieceColor = PlayerTurn
            };

            EventsMediator.OnWinner(null, args);            
        }



    }
}
