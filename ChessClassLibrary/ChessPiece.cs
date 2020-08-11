using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    [Serializable]
    public abstract class ChessPiece
    {
        public PieceColor PieceColor { get; private set; }

        public ChessPiece(PieceColor _color)
        {
            PieceColor = _color;
        }

        public abstract List<Move> GetAvailableMoves(Tuple<int, int> coords); 

        public override string ToString()
        {
            return this.PieceColor.ToString() + this.GetType().Name;
        }        
    }
}
