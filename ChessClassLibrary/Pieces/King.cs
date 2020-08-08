using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Pieces
{
    public class King : ChessPiece
    {
        public King(PieceColor _colour) : base(_colour)
        {
        }

        public override List<Move> GetAvailableMoves(Tuple<int, int> coords)
        {
            throw new NotImplementedException();
        }
    }
}
