using ChessClassLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public static class PieceFactory
    {
        public static ChessPiece GeneratePiece(PieceType piece, PieceColor color)
        {
                ChessPiece Piece = null;
                switch (piece.ToString())
                {
                    case "King": return new King(color);
                    case "Pawn": return new Pawn(color);
                    case "Queen": return new Queen(color);
                    case "Horseman": return new Horseman(color);
                    case "Rook": return new Rook(color);
                    case "Madman": return new Madman(color);
                }

                return Piece;   
        }
    }
}
