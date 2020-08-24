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
        private static List<Move> AvailableMoves = new List<Move>();

        private static Stack<Move> moveHistory;        

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
                Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].PieceColor != GameState.PlayerTurn)
            {
                return AvailableMoves;
            }            

            if (NrOfMovesLeft(Layout) == 0)
            {
                EventsMediator.OnWinner(null, new PlayerEventArgs { pieceColor = GameState.PlayerTurn });
                return AvailableMoves;
            }

            AvailableMoves = Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].GetAvailableMoves(selectedPieceCoords);
            AvailableMoves = DeleteIllegalMoves(AvailableMoves);

            return AvailableMoves;
        }

        private static int NrOfMovesLeft(Dictionary<int, Dictionary<int, ChessPiece>> layout) {
            int movesToAvoidMate = 0;            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (movesToAvoidMate > 0)
                    {
                        return movesToAvoidMate;
                    }
                    if (layout[i][j] != null)
                    {
                        if (layout[i][j].PieceColor == GameState.PlayerTurn)
                        {
                            List<Move> pieceAvMoves = layout[i][j].GetAvailableMoves(Coordinate.GetInstance.GetCoord(i, j));
                            movesToAvoidMate += DeleteIllegalMoves(pieceAvMoves).Count;                            
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

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                        if (scenario[i][j]?.ToString() == GameState.PlayerTurn.ToString() + "King")
                        {
                            PieceColor enemy = GameState.PlayerTurn == PieceColor.Black ? enemy = PieceColor.White : enemy = PieceColor.Black;
                        
                            if (HelperMaths.EnemyPawnCheck(i, j, scenario, enemy) || HelperMaths.HorizontalThreatCheck(i, j, scenario, enemy) ||
                                HelperMaths.DiagonalThreatCheck(i, j, scenario, enemy) || HelperMaths.VerticalThreatCheck(i, j, scenario, enemy) 
                                || HelperMaths.HorseThreatCheck(i, j, scenario, enemy))
                            {
                                return true;
                            }
                            return false;
                        }                                        
                }
            }
            return false;            
        }

        private static void HandlePlayerMove(object sender, PlayerEventArgs e)
        {
            moveHistory.Push(e.move);                                 
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

            EventsMediator.OnWinner(null, new PlayerEventArgs { pieceColor = GameState.PlayerTurn });            
        }

        public static void ClearReferee()
        {
            EventsMediator.PlayerMoved -= HandlePlayerMove;
            EventsMediator.TimesUp -= EndGame;
            EventsMediator.Undo -= UndoMove;            
        }
    }
}
