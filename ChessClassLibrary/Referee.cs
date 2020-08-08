using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public static class Referee
    {
        public static List<Move> GetAvailableMoves(Tuple<int, int> selectedPieceCoords) {
            //List<Move> AvailableMoves = new List<Move>();
            var Layout = GameState.GetGameState();
            //AvailableMoves = Layout[coord.Item1][coord.Item2].GetAvailableMoves();

            return GameState.GetGameState()[selectedPieceCoords.Item1][selectedPieceCoords.Item2].GetAvailableMoves(selectedPieceCoords);
        }

        public static bool ValidateMove() {
            return false;
        }
    }
}
