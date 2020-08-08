using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{    
        public enum PieceType {
            Pawn,
            Rook,
            Madman,
            Horseman,
            Queen,
            King
        }

        public enum PieceColor
        {
            White, 
            Black
        }

        public enum GameModeOption
        {
            Normal = 60 * 60,
            Blitz = 5 * 60,
            Custom
        }

}
