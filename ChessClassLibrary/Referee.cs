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

            if (CheckForAnyMovesLeft(Layout) == 0)
            {
                PlayerEventArgs args = new PlayerEventArgs
                {
                    pieceColor = PlayerTurn
                };
                EventsMediator.OnWinner(null, args);
                return AvailableMoves;
            }

            AvailableMoves = Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].GetAvailableMoves(selectedPieceCoords);
            AvailableMoves = DeleteIllegalMoves(AvailableMoves);

            return AvailableMoves;
        }

        private static int CheckForAnyMovesLeft(Dictionary<int, Dictionary<int, ChessPiece>> Layout) {
            int movesToAvoidMate = 0;
            var test = GameState.GetGameState();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (movesToAvoidMate > 0)
                    {
                        break;
                    }
                    if (test[i][j] != null)
                    {
                        if (test[i][j].PieceColor == PlayerTurn)
                        {
                            List<Move> pieceAvMoves = Layout[i][j].GetAvailableMoves(Coordinate.GetInstance.GetCoord(i, j)); ;
                            DeleteIllegalMoves(pieceAvMoves);
                            movesToAvoidMate += pieceAvMoves.Count;
                        }
                    }
                }
            }
            return movesToAvoidMate;
        }

        private static List<Move> DeleteIllegalMoves(List<Move> availableMoves) {
            for (int i = 0; i < availableMoves.Count; i++)
            {
                var scenario = GameState.GetScenario(availableMoves[i]);

                if (TestKingChecks(scenario))
                {
                    availableMoves.RemoveAt(i);
                    i--;
                }
            }
            return availableMoves;
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
                                HelperMaths.DiagonalThreatCheck(i, j, scenario, enemy) || HelperMaths.VerticalThreatCheck(i, j, scenario, enemy))
                            {
                                KingChecked = true;
                            }
                            break;
                        }
                    }                    
                }
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
