using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor _colour) : base(_colour)
        {
        }

        public override List<Move> GetAvailableMoves(Tuple<int, int> coords)
        {
            throw new NotImplementedException();
        }
    }
}
