using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public class Referee
    {
        public List<Move> GetAvailableMoves() {
            List<Move> AvailableMoves = new List<Move>();
            return AvailableMoves;
        }

        public bool ValidateMove(Move move, Dictionary<int, Dictionary<int, ChessPiece>> gameState) {
            return false;
        }
    }
}
