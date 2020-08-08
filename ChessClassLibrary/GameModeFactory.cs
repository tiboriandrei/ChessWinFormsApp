using ChessClassLibrary.GameModes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public static class GameModeFactory
    {
        public static Game InitializeGame(GameModeOption gameMode)
        {  
            Game game = null;
            switch (gameMode.ToString())
            {
                case "Normal": game = new NormalChess((int)gameMode); break;
                case "Blitz": game = new BlitzChess((int)gameMode); break;
                //case "Custom": game = new CustomChess(); break;
            }

            return game;
        }
    }
}
