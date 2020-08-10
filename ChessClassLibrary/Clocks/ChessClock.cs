using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Clocks
{
    public class ChessClock
    {
        public ChessClock(int duration)
        {
            _WhitesTimer = new Clock(duration);
            _BlacksTimer = new Clock(duration);
            EventsMediator.PlayerMoved += ChangeTimer;
        }

        public Clock _WhitesTimer { get; set; }
        public Clock _BlacksTimer { get; set; }

        private void ChangeTimer(object sender, PlayerEventArgs e) {
            switch (e.pieceColor)
            {
                case PieceColor.White:
                    _WhitesTimer.StopClock();
                    _BlacksTimer.ResumeClock();
                    break;

                case PieceColor.Black:
                    _WhitesTimer.ResumeClock();
                    _BlacksTimer.StopClock();
                    break;

                default:
                    break;
            }
        }

    }
}
