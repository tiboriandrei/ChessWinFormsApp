using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChessClassLibrary
{
    public static class GameState
    {
        private static Dictionary<int, Dictionary<int, ChessPiece>> Layout = new Dictionary<int, Dictionary<int, ChessPiece>>();

        public static void InitGameState() {

            Dictionary<int, ChessPiece> WhitePieces = new Dictionary<int, ChessPiece>
            {
                { 7, PieceFactory.GeneratePiece(PieceType.Rook, PieceColor.White) },
                { 6, PieceFactory.GeneratePiece(PieceType.Horseman, PieceColor.White) },
                { 5, PieceFactory.GeneratePiece(PieceType.Madman, PieceColor.White) },
                { 4, PieceFactory.GeneratePiece(PieceType.Queen, PieceColor.White) },
                { 3, PieceFactory.GeneratePiece(PieceType.King, PieceColor.White) },
                { 2, PieceFactory.GeneratePiece(PieceType.Madman, PieceColor.White) },
                { 1, PieceFactory.GeneratePiece(PieceType.Horseman, PieceColor.White) },
                { 0, PieceFactory.GeneratePiece(PieceType.Rook, PieceColor.White) }
            };
            Layout.Add(7, WhitePieces);

            Dictionary<int, ChessPiece> BlackPieces = new Dictionary<int, ChessPiece>
            {
                { 7, PieceFactory.GeneratePiece(PieceType.Rook, PieceColor.Black) },
                { 6, PieceFactory.GeneratePiece(PieceType.Horseman, PieceColor.Black) },
                { 5, PieceFactory.GeneratePiece(PieceType.Madman, PieceColor.Black) },
                { 4, PieceFactory.GeneratePiece(PieceType.King, PieceColor.Black) },
                { 3, PieceFactory.GeneratePiece(PieceType.Queen, PieceColor.Black) },
                { 2, PieceFactory.GeneratePiece(PieceType.Madman, PieceColor.Black) },
                { 1, PieceFactory.GeneratePiece(PieceType.Horseman, PieceColor.Black) },
                { 0, PieceFactory.GeneratePiece(PieceType.Rook, PieceColor.Black) }
            };

            Layout.Add(0, BlackPieces);

            Dictionary<int, ChessPiece> WhitePawns = new Dictionary<int, ChessPiece>();
            for (int i = 0; i < 8; i++)
            {
                WhitePawns.Add(i, PieceFactory.GeneratePiece(PieceType.Pawn, PieceColor.White));
            }
            Layout.Add(6, WhitePawns);

            Dictionary<int, ChessPiece> BlackPawns = new Dictionary<int, ChessPiece>();
            for (int i = 0; i < 8; i++)
            {
                BlackPawns.Add(i, PieceFactory.GeneratePiece(PieceType.Pawn, PieceColor.Black));
            }
            Layout.Add(1, BlackPawns);
        }

        public static Dictionary<int, Dictionary<int, ChessPiece>> GetGameState() {
            Dictionary<int, Dictionary<int, ChessPiece>> clone = Layout;
            return clone;
        }

        public static void UpdateLayout(Dictionary<int, Dictionary<int, ChessPiece>> updatedLayout) {
            Layout = updatedLayout;
        }

        

    }
}
