using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Clocks
{
    public class Clock
    {
        private double MaxTime { get; set; }

        private DateTime StartTime;

        private bool Stopped = true;

        public Clock(int _duration)
        {
            MaxTime = _duration;            
        }

        public void ResumeClock() {
            if (Stopped)
            {
                StartTime = DateTime.Now;
                Stopped = false;
            }            
        }

        public void StopClock()
        {
            MaxTime = GetTimeLeft().TotalSeconds;
            Stopped = true;
        }

        public TimeSpan GetTimeLeft() {
            if (MaxTime <= 0)
            {
                EventsMediator.OnTimesUp(null, EventArgs.Empty);
            }

            if (Stopped)
            {
                return TimeSpan.FromSeconds(MaxTime);
            }
            else {
                TimeSpan timePassed = DateTime.Now - StartTime;
                return TimeSpan.FromSeconds(MaxTime - timePassed.TotalSeconds);
            }            
        }

        //times up event invoke to refree who invokes further...etc

        //in blitzmode, when player moves and the time left is low, increment +5 by event or something

    }
}
