using ChessClassLibrary.Clocks;
using System;

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
