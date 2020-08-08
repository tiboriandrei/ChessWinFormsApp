using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChessClassLibrary
{
    public sealed class Coordinate
    {
        private static Coordinate _Instance = null;

        public Dictionary<int, Dictionary<int, int>> Coordinates = new Dictionary<int, Dictionary<int, int>>();

        private Coordinate() {
            for (int i = 0; i < 8; i++)
            {
                Dictionary<int, int> aux = new Dictionary<int, int>();
                for (int j = 0; j < 8; j++)
                {                    
                    aux.Add(j, j);                    
                }
                Coordinates.Add(i, aux);
            }
        }

        public static Coordinate GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Coordinate();
                }
                return _Instance;
            } 
        }
              
        public Tuple<int, int> GetCoord(int x, int y)
        {
            if (_Instance.Coordinates.ContainsKey(x))
            {
                if (_Instance.Coordinates[x].ContainsKey(y))
                {
                    var tuple = (X: _Instance.Coordinates[x][x], Y: _Instance.Coordinates[x][y]);
                    return tuple.ToTuple();
                }
            }
            return null;       
        }

    }
}
