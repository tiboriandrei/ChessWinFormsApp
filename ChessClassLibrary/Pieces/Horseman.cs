using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Pieces
{
    public class Horseman : ChessPiece
    {
        public Horseman(PieceColor _colour) : base(_colour)
        {

        }

        public override List<Move> GetAvailableMoves(Tuple<int, int> coords)
        {
            List<Move> availableMoves = new List<Move>();
            var Layout = GameState.GetGameState();

            if (HelperMaths.IsInRange(coords.Item1 - 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 - 2, 0, 7))
            {
                if (Layout[coords.Item1 - 1][coords.Item2 - 2] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2 - 2)));
                }
                else if (Layout[coords.Item1 - 1][coords.Item2 - 2].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2 - 2)));
                }
            }

            if (HelperMaths.IsInRange(coords.Item1 - 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 + 2, 0, 7))
            {
                if (Layout[coords.Item1 - 1][coords.Item2 + 2] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2 + 2)));
                }
                else if (Layout[coords.Item1 - 1][coords.Item2 + 2].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2 + 2)));
                }
            }

            if (HelperMaths.IsInRange(coords.Item1 + 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 - 2, 0, 7))
            {
                if (Layout[coords.Item1 + 1][coords.Item2 - 2] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 1, coords.Item2 - 2)));
                }
                else if (Layout[coords.Item1 + 1][coords.Item2 - 2].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 1, coords.Item2 - 2)));
                }
            }

            if (HelperMaths.IsInRange(coords.Item1 + 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 + 2, 0, 7))
            {
                if (Layout[coords.Item1 + 1][coords.Item2 + 2] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 1, coords.Item2 + 2)));
                }
                else if (Layout[coords.Item1 + 1][coords.Item2 + 2].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 1, coords.Item2 + 2)));
                }
            }

            //--------------------

            if (HelperMaths.IsInRange(coords.Item1 - 2, 0, 7) && HelperMaths.IsInRange(coords.Item2 - 1, 0, 7))
            {
                if (Layout[coords.Item1 - 2][coords.Item2 - 1] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 2, coords.Item2 - 1)));
                }
                else if (Layout[coords.Item1 - 2][coords.Item2 - 1].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 2, coords.Item2 - 1)));
                }
            }

            if (HelperMaths.IsInRange(coords.Item1 + 2, 0, 7) && HelperMaths.IsInRange(coords.Item2 - 1, 0, 7))
            {
                if (Layout[coords.Item1 + 2][coords.Item2 - 1] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 2, coords.Item2 - 1)));
                }
                else if (Layout[coords.Item1 + 2][coords.Item2 - 1].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 2, coords.Item2 - 1)));
                }
            }

            if (HelperMaths.IsInRange(coords.Item1 - 2, 0, 7) && HelperMaths.IsInRange(coords.Item2 + 1, 0, 7))
            {
                if (Layout[coords.Item1 - 2][coords.Item2 + 1] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 2, coords.Item2 + 1)));
                }
                else if (Layout[coords.Item1 - 2][coords.Item2 + 1].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 2, coords.Item2 + 1)));
                }
            }

            if (HelperMaths.IsInRange(coords.Item1 + 2, 0, 7) && HelperMaths.IsInRange(coords.Item2 + 1, 0, 7))
            {
                if (Layout[coords.Item1 + 2][coords.Item2 + 1] == null)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 2, coords.Item2 + 1)));
                }
                else if (Layout[coords.Item1 + 2][coords.Item2 + 1].PieceColor != this.PieceColor)
                {
                    availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 2, coords.Item2 + 1)));
                }
            }






            return availableMoves;
        }
    }
}
