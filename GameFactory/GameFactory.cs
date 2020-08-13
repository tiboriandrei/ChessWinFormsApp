using ChessClassLibrary;
using System;
using System.Configuration;

namespace GameRepository.Factory
{
    public static class GameFactory
    {
        public static Game GetGame(GameModeOption gameMode) {

            string gameTypeName = ConfigurationManager.AppSettings[gameMode.ToString()];
            Type gameType = Type.GetType(gameTypeName);
            object game = Activator.CreateInstance(gameType, (int)gameMode);

            return game as Game;
        }
    }
}
