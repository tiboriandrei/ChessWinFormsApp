using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ChessClassLibrary
{
    public static class Referee
    {
        public static string PlayerTurn { get; set; } = "White";
        public static List<Move> GetAvailableMoves(Tuple<int, int> selectedPieceCoords) {

            List<Move> AvailableMoves = new List<Move>();
            var Layout = GameState.GetGameState();

            if (Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2] == null)
            {
                return new List<Move>();
            }
            if (Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].PieceColor.ToString() != PlayerTurn)
            {
                return new List<Move>();
            }

            AvailableMoves = Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].GetAvailableMoves(selectedPieceCoords);

            return AvailableMoves;
        }

        public static bool ValidateMove() {
            return false;
        }
    }
}
