using ChessClassLibrary.Clocks;
using System;
using System.Collections.Generic;

namespace ChessClassLibrary
{
    public class Game
    {
        public readonly ChessClock _ChessClock;       

        public Game(int duration)
        {            
            _ChessClock = new ChessClock(duration);           
        }

    }
}
