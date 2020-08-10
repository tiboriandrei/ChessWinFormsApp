using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessClassLibrary
{
    public static class HelperMaths
    {
        public static bool IsInRange(this int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value >= inclusiveMinimum && value <= inclusiveMaximum) { return true; } else { return false; }
        }

        public static Dictionary<int, Dictionary<int, ChessPiece>> FlipTable(Dictionary<int, Dictionary<int, ChessPiece>> table) 
        {
            //Dictionary<int, Dictionary<int, ChessPiece>> flippedTable = new Dictionary<int, Dictionary<int, ChessPiece>>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var aux = table[i][j];
                    table[i][j] = table[7 - i][7 - j];
                    table[7 - i][7 - j] = aux;                    
                }
            }
            return table;
        }

        public static bool ContainsObjectMove(List<Move> moves, Move attemptedMove)
        {
            if (moves.Any(coord => coord.Origin.Item2 == attemptedMove.Origin.Item2 && coord.Origin.Item1 == attemptedMove.Origin.Item1 &&
                                   coord.Destination.Item2 == attemptedMove.Destination.Item2 && coord.Destination.Item1 == attemptedMove.Destination.Item1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
