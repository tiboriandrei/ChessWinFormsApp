using ChessClassLibrary.Pieces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static void SaveObj<T>(T saveableObject, string fileName, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(saveableObject);
                writer = new StreamWriter(@".\" + fileName, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T LoadSerializedObj<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        //-----------------------------------------------------------------

        // King check functions

        //-----------------------------------------------------------------

        public static bool EnemyPawnCheck(int kingX, int kingY, Dictionary<int, Dictionary<int, ChessPiece>> scenario, PieceColor enemy)
        {
            if (enemy == PieceColor.Black)
            {
                if (HelperMaths.IsInRange(kingX - 1, 0, 7) && HelperMaths.IsInRange(kingY - 1, 0, 7))
                {
                        if (scenario[kingX - 1][kingY - 1]?.ToString() == enemy.ToString() + "Pawn")
                        {
                            return true;
                        }                    
                }

                if (HelperMaths.IsInRange(kingX - 1, 0, 7) && HelperMaths.IsInRange(kingY + 1, 0, 7))
                {
                        if (scenario[kingX - 1][kingY + 1]?.ToString() == enemy.ToString() + "Pawn")
                        {
                            return true;
                        }                    
                }
            }

            if (enemy == PieceColor.White)
            {
                if (HelperMaths.IsInRange(kingX + 1, 0, 7) && HelperMaths.IsInRange(kingY - 1, 0, 7))
                {
                        if (scenario[kingX + 1][kingY - 1]?.ToString() == enemy.ToString() + "Pawn")
                        {
                            return true;
                        }                    
                }

                if (HelperMaths.IsInRange(kingX + 1, 0, 7) && HelperMaths.IsInRange(kingY + 1, 0, 7))
                {
                        if (scenario[kingX + 1][kingY + 1]?.ToString() == enemy.ToString() + "Pawn")
                        {
                            return true;
                        }                    
                }
            }
            return false;
        }

        public static bool HorseThreatCheck(int kingX, int kingY, Dictionary<int, Dictionary<int, ChessPiece>> scenario, PieceColor enemy)
        {
                if (HelperMaths.IsInRange(kingX - 2, 0, 7) && HelperMaths.IsInRange(kingY - 1, 0, 7))
                {
                    if (scenario[kingX - 2][kingY - 1]?.ToString() == enemy.ToString() + "Horseman")
                    {
                        return true;
                    }
                }

            if (HelperMaths.IsInRange(kingX - 2, 0, 7) && HelperMaths.IsInRange(kingY + 1, 0, 7))
            {
                if (scenario[kingX - 2][kingY + 1]?.ToString() == enemy.ToString() + "Horseman")
                {
                    return true;
                }
            }

            if (HelperMaths.IsInRange(kingX + 2, 0, 7) && HelperMaths.IsInRange(kingY - 1, 0, 7))
            {
                if (scenario[kingX + 2][kingY - 1]?.ToString() == enemy.ToString() + "Horseman")
                {
                    return true;
                }
            }

            if (HelperMaths.IsInRange(kingX + 2, 0, 7) && HelperMaths.IsInRange(kingY + 1, 0, 7))
            {
                if (scenario[kingX + 2][kingY + 1]?.ToString() == enemy.ToString() + "Horseman")
                {
                    return true;
                }
            }

            //

            if (HelperMaths.IsInRange(kingX + 1, 0, 7) && HelperMaths.IsInRange(kingY + 2, 0, 7))
            {
                if (scenario[kingX + 1][kingY + 2]?.ToString() == enemy.ToString() + "Horseman")
                {
                    return true;
                }
            }

            if (HelperMaths.IsInRange(kingX - 1, 0, 7) && HelperMaths.IsInRange(kingY + 2, 0, 7))
            {
                if (scenario[kingX - 1][kingY + 2]?.ToString() == enemy.ToString() + "Horseman")
                {
                    return true;
                }
            }

            if (HelperMaths.IsInRange(kingX + 1, 0, 7) && HelperMaths.IsInRange(kingY - 2, 0, 7))
            {
                if (scenario[kingX + 1][kingY - 2]?.ToString() == enemy.ToString() + "Horseman")
                {
                    return true;
                }
            }

            if (HelperMaths.IsInRange(kingX - 1, 0, 7) && HelperMaths.IsInRange(kingY - 2, 0, 7))
            {
                if (scenario[kingX - 1][kingY - 2]?.ToString() == enemy.ToString() + "Horseman")
                {
                    return true;
                }
            }

            return false;
        }

        public static bool VerticalThreatCheck(int kingX, int kingY, Dictionary<int, Dictionary<int, ChessPiece>> scenario, PieceColor enemy)
        {
            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingX + i, 0, 7))
                {
                    if (scenario[kingX + i][kingY] != null)
                    {
                        if (scenario[kingX + i][kingY].ToString() == enemy.ToString() + PieceType.Rook.ToString() ||
                            scenario[kingX + i][kingY].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingX - i, 0, 7))
                {
                    if (scenario[kingX - i][kingY] != null)
                    {
                        if (scenario[kingX - i][kingY].ToString() == enemy.ToString() + PieceType.Rook.ToString() ||
                            scenario[kingX - i][kingY].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        }

        public static bool HorizontalThreatCheck(int kingX, int kingY, Dictionary<int, Dictionary<int, ChessPiece>> scenario, PieceColor enemy)
        {
            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingY + i, 0, 7))
                {
                    if (scenario[kingX][kingY + i] != null)
                    {
                        if (scenario[kingX][kingY + i].ToString() == enemy.ToString() + PieceType.Rook.ToString() ||
                            scenario[kingX][kingY + i].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingY - i, 0, 7))
                {
                    if (scenario[kingX][kingY - i] != null)
                    {
                        if (scenario[kingX][kingY - i].ToString() == enemy.ToString() + PieceType.Rook.ToString() ||
                            scenario[kingX][kingY - i].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        }

        public static bool DiagonalThreatCheck(int kingX, int kingY, Dictionary<int, Dictionary<int, ChessPiece>> scenario, PieceColor enemy)
        {
            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingX + i, 0, 7) && HelperMaths.IsInRange(kingY + i, 0, 7))
                {
                    if (scenario[kingX + i][kingY + i] != null)
                    {
                        if (scenario[kingX + i][kingY + i].ToString() == enemy.ToString() + PieceType.Madman.ToString() ||
                            scenario[kingX + i][kingY + i].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingX - i, 0, 7) && HelperMaths.IsInRange(kingY + i, 0, 7))
                {
                    if (scenario[kingX - i][kingY + i] != null)
                    {
                        if (scenario[kingX - i][kingY + i].ToString() == enemy.ToString() + PieceType.Madman.ToString() ||
                            scenario[kingX - i][kingY + i].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingX + i, 0, 7) && HelperMaths.IsInRange(kingY - i, 0, 7))
                {
                    if (scenario[kingX + i][kingY - i] != null)
                    {
                        if (scenario[kingX + i][kingY - i].ToString() == enemy.ToString() + PieceType.Madman.ToString() ||
                            scenario[kingX + i][kingY - i].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (HelperMaths.IsInRange(kingX - i, 0, 7) && HelperMaths.IsInRange(kingY - i, 0, 7))
                {
                    if (scenario[kingX - i][kingY - i] != null)
                    {
                        if (scenario[kingX - i][kingY - i].ToString() == enemy.ToString() + PieceType.Madman.ToString() ||
                            scenario[kingX - i][kingY - i].ToString() == enemy.ToString() + PieceType.Queen.ToString())
                        {
                            return true;
                        }
                        else { break; }
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        
        }
    }
}
