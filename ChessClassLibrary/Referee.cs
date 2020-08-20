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
        public static PieceColor PlayerTurn { get; private set; } = PieceColor.White;

        private static List<Move> AvailableMoves = new List<Move>();

        private static Stack<Move> moveHistory;
        //private static ConcurrentDictionary<int, Move> myThrSafeDict = new ConcurrentDictionary<int, Move>();

        public static void InitReferee() {
            EventsMediator.PlayerMoved += HandlePlayerMove;
            EventsMediator.TimesUp += EndGame;
            EventsMediator.Undo += UndoMove;
            moveHistory = new Stack<Move>();
        }
               
        public static List<Move> GetAvailableMoves(Tuple<int, int> selectedPieceCoords) {
                        
            AvailableMoves.Clear();
            var Layout = GameState.GetGameState();

            if (Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2] == null || 
                Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].PieceColor != PlayerTurn)
            {
                return AvailableMoves;
            }            

            if (NrOfMovesLeft(Layout) == 0)
            {
                EventsMediator.OnWinner(null, new PlayerEventArgs { pieceColor = PlayerTurn });
                return AvailableMoves;
            }

            AvailableMoves = Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].GetAvailableMoves(selectedPieceCoords);
            AvailableMoves = DeleteIllegalMoves(AvailableMoves);

            return AvailableMoves;
        }

        private static int NrOfMovesLeft(Dictionary<int, Dictionary<int, ChessPiece>> layout) {
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
                            List<Move> pieceAvMoves = layout[i][j].GetAvailableMoves(Coordinate.GetInstance.GetCoord(i, j)); ;
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
                        if (scenario[i][j]?.ToString() == PlayerTurn.ToString() + "King")
                        {
                            KingChecked = false;

                            PieceColor enemy = PlayerTurn == PieceColor.Black ? enemy = PieceColor.White : enemy = PieceColor.Black;
                        
                            if (HelperMaths.EnemyPawnCheck(i, j, scenario, enemy) || HelperMaths.HorizontalThreatCheck(i, j, scenario, enemy) ||
                                HelperMaths.DiagonalThreatCheck(i, j, scenario, enemy) || HelperMaths.VerticalThreatCheck(i, j, scenario, enemy) 
                                || HelperMaths.HorseThreatCheck(i, j, scenario, enemy))
                            {
                                KingChecked = true;
                            }
                            break;
                        }                                        
                }
            }

            return KingChecked;            
        }

        private static void HandlePlayerMove(object sender, PlayerEventArgs e)
        {
            moveHistory.Push(e.move);
            PlayerTurn = PlayerTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;                       
        }

        public static void UndoMove(object sender, EventArgs e)
        {
            try
            {
                GameState.UndoMove(moveHistory.Pop());
            }
            catch (Exception)
            {

            }           
        }

        private static void EndGame(object sender, EventArgs e) {

            EventsMediator.OnWinner(null, new PlayerEventArgs { pieceColor = PlayerTurn });            
        }

        public static void ClearReferee()
        {
            EventsMediator.PlayerMoved -= HandlePlayerMove;
            EventsMediator.TimesUp -= EndGame;
            EventsMediator.Undo -= UndoMove;            
        }
    }
}
