using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class GameStateTest
    {
        [TestMethod]
        public void InitTestMethod()
        {
            GameState.InitGameState();
            GameState.InitGameState();
        }
    }
}
