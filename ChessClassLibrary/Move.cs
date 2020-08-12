using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public class Move
    {
        public Tuple<int, int> Origin;
        public Tuple<int, int> Destination;

        public ChessPiece capturedPiece;

        public Move(Tuple<int, int> origin, Tuple<int, int> destination)
        {
            Origin = origin;
            Destination = destination;
        }
    }
}
