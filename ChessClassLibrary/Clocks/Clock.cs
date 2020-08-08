using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Clocks
{
    public class Clock
    {
        private double MaxTime { get; set; }

        private DateTime StartTime;

        public Clock(int _duration)
        {
            MaxTime = _duration;            
        }

        public void StartClock() {
            StartTime = DateTime.Now;
        }

        public void StopClock()
        {
            MaxTime = GetTimeLeft();
            StartTime = DateTime.Now;
        }

        public double GetTimeLeft() {
            TimeSpan timePassed = DateTime.Now - StartTime; 
            return MaxTime - timePassed.TotalSeconds;
        }

        //in blitzmode, when player moves and the time left is low, increment +5 by event or something

    }
}
