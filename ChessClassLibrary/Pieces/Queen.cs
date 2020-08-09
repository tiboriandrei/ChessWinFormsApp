using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Pieces
{
    public class Queen : ChessPiece
    {
        public Queen(PieceColor _colour) : base(_colour)
        {
        }

        public override List<Move> GetAvailableMoves(Tuple<int, int> coords)
        {
            List<Move> availableMoves = new List<Move>();
            var Layout = GameState.GetGameState();

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item1 - i, 0, 7) && HelperMaths.IsInRange(coords.Item2 - i, 0, 7))
                {
                    if (Layout[coords.Item1 - i][coords.Item2 - i] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2 - i)));
                    }
                    else
                    {
                        if (Layout[coords.Item1 - i][coords.Item2 - i].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2 - i)));

                        if (Layout[coords.Item1 - i][coords.Item2 - i].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }
                }
                else { break; }
            }

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item1 - i, 0, 7) && HelperMaths.IsInRange(coords.Item2 + i, 0, 7))
                {
                    if (Layout[coords.Item1 - i][coords.Item2 + i] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2 + i)));
                    }
                    else
                    {
                        if (Layout[coords.Item1 - i][coords.Item2 + i].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2 + i)));

                        if (Layout[coords.Item1 - i][coords.Item2 + i].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }
                }
                else { break; }
            }

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item1 + i, 0, 7) && HelperMaths.IsInRange(coords.Item2 - i, 0, 7))
                {
                    if (Layout[coords.Item1 + i][coords.Item2 - i] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2 - i)));
                    }
                    else
                    {
                        if (Layout[coords.Item1 + i][coords.Item2 - i].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2 - i)));

                        if (Layout[coords.Item1 + i][coords.Item2 - i].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }
                }
                else { break; }
            }

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item1 + i, 0, 7) && HelperMaths.IsInRange(coords.Item2 + i, 0, 7))
                {
                    if (Layout[coords.Item1 + i][coords.Item2 + i] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2 + i)));
                    }
                    else
                    {
                        if (Layout[coords.Item1 + i][coords.Item2 + i].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2 + i)));

                        if (Layout[coords.Item1 + i][coords.Item2 + i].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }
                }
                else { break; }
            }

            //-----------------------------

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item1 - i, 0, 7))
                {
                    if (Layout[coords.Item1 - i][coords.Item2] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2)));
                    }
                    else
                    {
                        if (Layout[coords.Item1 - i][coords.Item2].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2)));

                        if (Layout[coords.Item1 - i][coords.Item2].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }
                }
                else { break; }
            }

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item1 + i, 0, 7))
                {
                    if (Layout[coords.Item1 + i][coords.Item2] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2)));
                    }
                    else
                    {
                        if (Layout[coords.Item1 + i][coords.Item2].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2)));

                        if (Layout[coords.Item1 + i][coords.Item2].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }
                }
                else { break; }
            }

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item2 - i, 0, 7))
                {
                    if (Layout[coords.Item1][coords.Item2 - i] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1, coords.Item2 - i)));
                    }
                    else
                    {
                        if (Layout[coords.Item1][coords.Item2 - i].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1, coords.Item2 - i)));

                        if (Layout[coords.Item1][coords.Item2 - i].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }

                }
                else { break; }
            }

            for (int i = 1; i < 8; i++)
            {
                if (HelperMaths.IsInRange(coords.Item2 + i, 0, 7))
                {
                    if (Layout[coords.Item1][coords.Item2 + i] == null)
                    {
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1, coords.Item2 + i)));
                    }
                    else
                    {
                        if (Layout[coords.Item1][coords.Item2 + i].PieceColor == this.PieceColor)
                        {
                            break;
                        }
                        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1, coords.Item2 + i)));

                        if (Layout[coords.Item1][coords.Item2 + i].PieceColor != this.PieceColor)
                        {
                            break;
                        }
                    }

                }
                else { break; }
            }

            return availableMoves;
        }
    }
}
