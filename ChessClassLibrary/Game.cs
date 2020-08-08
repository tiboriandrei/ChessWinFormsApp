using ChessClassLibrary.Clocks;
using System;

namespace ChessClassLibrary
{
    public class Game
    {
        public readonly BlacksTimer _BlacksTimer;
        public readonly WhitesTimer _WhitesTimer;

        public Game(int duration)
        {
            _BlacksTimer = new BlacksTimer(duration);
            _WhitesTimer = new WhitesTimer(duration);
        }

        public Table Table { get; set; }
        
        public string PlayerTurn { get; set; } = "White";
        public string MoveResult { get; set; }

        public void GetResult(object sender, string e)
        {
            MoveResult = e;
            //Mediator.GetInstance().Result -= GetResult;

            if (MoveResult == "goodMove")
            {
                if (PlayerTurn == "White")
                {
                    PlayerTurn = "Black";
                }
                else
                {
                    PlayerTurn = "White";
                }
            }
        }
    }
}
