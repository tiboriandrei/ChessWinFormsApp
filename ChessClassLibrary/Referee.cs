using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ChessClassLibrary
{
    public static class Referee
    {
        public static PieceColor PlayerTurn { get; set; } = PieceColor.White;

        public static void InitReferee() {
            EventsMediator.PlayerMoved += ChangePlayerTurn;
        }

        private static List<Move> AvailableMoves = new List<Move>();
        public static List<Move> GetAvailableMoves(Tuple<int, int> selectedPieceCoords) {

            AvailableMoves.Clear();
            var Layout = GameState.GetGameState();

            if (Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2] == null)
            {
                return new List<Move>();
            }
            if (Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].PieceColor != PlayerTurn)
            {
                return new List<Move>();
            }

            AvailableMoves = Layout[selectedPieceCoords.Item1][selectedPieceCoords.Item2].GetAvailableMoves(selectedPieceCoords);

            foreach (var move in AvailableMoves)
            {
                //if king is checked in move scenario, delete move from list. +threads
            }

            //if list.count == 0 , invoke check mate event

            return AvailableMoves;
        }

        private static void ChangePlayerTurn(object sender, PlayerEventArgs e)
        {
            if (PlayerTurn == PieceColor.White)
            {
                PlayerTurn = PieceColor.Black;                
            }
            else
            {
                PlayerTurn = PieceColor.White;
            }
        }
    }
}
