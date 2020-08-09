using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public static class MoveLogic
    {
        public static bool IsInRange(this int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value >= inclusiveMinimum && value <= inclusiveMaximum) { return true; } else { return false; }
        }

        //public List<Move> GetDiagonalMoves(Tuple<int, int> coords) {
        //    //List<Move> availableMoves = new List<Move>();
        //    //var Layout = GameState.GetGameState();

        //    //for (int i = 1; i < 8; i++)
        //    //{
        //    //    if (IsInRange(coords.Item1 - i, 0, 7) && IsInRange(coords.Item2 - i, 0, 7))
        //    //    {
        //    //        if (Layout[coords.Item1 - i][coords.Item2 - i].PieceColor == this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2 - i)));

        //    //        if (Layout[coords.Item1 - i][coords.Item2 - i].PieceColor != this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //    }
        //    //    else { break; }
        //    //}

        //    //for (int i = 1; i < 8; i++)
        //    //{
        //    //    if (IsInRange(coords.Item1 - i, 0, 7) && IsInRange(coords.Item2 + i, 0, 7))
        //    //    {
        //    //        if (Layout[coords.Item1 - i][coords.Item2 + i].PieceColor == this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 - i, coords.Item2 + i)));

        //    //        if (Layout[coords.Item1 - i][coords.Item2 + i].PieceColor != this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //    }
        //    //    else { break; }
        //    //}

        //    //for (int i = 1; i < 8; i++)
        //    //{
        //    //    if (IsInRange(coords.Item1 + i, 0, 7) && IsInRange(coords.Item2 - i, 0, 7))
        //    //    {
        //    //        if (Layout[coords.Item1 + i][coords.Item2 - i].PieceColor == this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2 - i)));

        //    //        if (Layout[coords.Item1 + i][coords.Item2 - i].PieceColor != this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //    }
        //    //    else { break; }
        //    //}

        //    //for (int i = 1; i < 8; i++)
        //    //{
        //    //    if (IsInRange(coords.Item1 + i, 0, 7) && IsInRange(coords.Item2 + i, 0, 7))
        //    //    {
        //    //        if (Layout[coords.Item1 + i][coords.Item2 + i].PieceColor == this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //        availableMoves.Add(new Move(coords, Tuple.Create(coords.Item1 + i, coords.Item2 + i)));

        //    //        if (Layout[coords.Item1 + i][coords.Item2 + i].PieceColor != this.PieceColor)
        //    //        {
        //    //            break;
        //    //        }
        //    //    }
        //    //    else { break; }
        //    //}

        //    //return availableMoves;
        //}
    }
}
