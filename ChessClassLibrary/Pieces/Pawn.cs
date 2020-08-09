using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor _colour) : base(_colour)
        {
        }

        public override List<Move> GetAvailableMoves(Tuple<int, int> coords)
        {
            List<Move> availableMoves = new List<Move>();
            var Layout = GameState.GetGameState();

            if (this.PieceColor.ToString() == "White")
            {
                if (HelperMaths.IsInRange(coords.Item1 - 1, 0, 7))
                {
                    if (Layout[coords.Item1 - 1][coords.Item2] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2)));
                    }
                }

                if (HelperMaths.IsInRange(coords.Item1 - 2, 0, 7) && HelperMaths.IsInRange(coords.Item1 - 1, 0, 7))
                {
                    if (Layout[coords.Item1 - 2][coords.Item2] == null && Layout[coords.Item1 - 1][coords.Item2] == null && coords.Item1 == 6)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 2, coords.Item2)));
                    }
                }

                if (HelperMaths.IsInRange(coords.Item1 - 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 - 1, 0, 7))
                {
                    if (Layout[coords.Item1 - 1][coords.Item2 - 1] != null)
                    {
                        if (Layout[coords.Item1 - 1][coords.Item2 - 1].PieceColor != this.PieceColor)
                        {
                            availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2 - 1)));
                        }
                    }
                }

                if (HelperMaths.IsInRange(coords.Item1 - 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 + 1, 0, 7))
                {
                    if (Layout[coords.Item1 - 1][coords.Item2 + 1] != null)
                    {
                        if (Layout[coords.Item1 - 1][coords.Item2 + 1].PieceColor != this.PieceColor)
                        {
                            availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2 + 1)));
                        }
                    }
                }
            }            

            if (this.PieceColor.ToString() == "Black")
            {
                if (HelperMaths.IsInRange(coords.Item1 + 1, 0, 7))
                {
                    if (Layout[coords.Item1 + 1][coords.Item2] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 1, coords.Item2)));
                    }
                }

                if (HelperMaths.IsInRange(coords.Item1 + 2, 0, 7) && HelperMaths.IsInRange(coords.Item1 + 1, 0, 7))
                {
                    if (Layout[coords.Item1 + 2][coords.Item2] == null && Layout[coords.Item1 + 1][coords.Item2] == null && coords.Item1 == 1)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 2, coords.Item2)));
                    }
                }

                if (HelperMaths.IsInRange(coords.Item1 + 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 + 1, 0, 7))
                {
                    if (Layout[coords.Item1 + 1][coords.Item2 + 1] != null)
                    {
                        if (Layout[coords.Item1 + 1][coords.Item2 + 1].PieceColor != this.PieceColor)
                        {
                            availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - 1, coords.Item2 - 1)));
                        }
                    }
                }

                if (HelperMaths.IsInRange(coords.Item1 + 1, 0, 7) && HelperMaths.IsInRange(coords.Item2 - 1, 0, 7))
                {
                    if (Layout[coords.Item1 + 1][coords.Item2 - 1] != null)
                    {
                        if (Layout[coords.Item1 + 1][coords.Item2 - 1].PieceColor != this.PieceColor)
                        {
                            availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + 1, coords.Item2 - 1)));
                        }
                    }
                }

            }

            return availableMoves;
        }
    }
}
