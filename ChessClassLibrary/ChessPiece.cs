using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public abstract class ChessPiece
    {
        public PieceColor PieceColor { get; private set; }

        public ChessPiece(PieceColor _color)
        {
            PieceColor = _color;
        }

        //public abstract bool TryMove(Spot[,] Spots, Spot origin, Spot dest, string player);
        //public abstract Spot[,] MarkAttackedSpots(Spot[,] Spots, Spot origin, string player);

        public abstract List<Move> GetAvailableMoves(Tuple<int, int> coords); 

        public override string ToString()
        {
            return this.PieceColor.ToString() + this.GetType().Name;
        }
    }
}
