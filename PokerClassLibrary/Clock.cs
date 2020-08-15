﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public static class Clock
    {
        private static double MaxTime { get; set; }

        private static DateTime StartTime;

        private static bool Stopped = true;

        public static void InitClock(int _duration)
        {
            MaxTime = _duration;
        }

        public static void ResumeClock()
        {
            if (Stopped)
            {
                StartTime = DateTime.Now;
                Stopped = false;
            }
        }

        public static void StopClock()
        {
            MaxTime = GetTimeLeft().TotalSeconds;
            Stopped = true;
        }

        public static TimeSpan GetTimeLeft()
        {
            if (MaxTime <= 0)
            {
                PlayerActionEventArgs args = new PlayerActionEventArgs { Action = PlayerAction.Fold };
                PokerEventsMediator.OnPlayerAction(null, args);
            }

            if (Stopped)
            {
                return TimeSpan.FromSeconds(MaxTime);
            }
            else
            {
                TimeSpan timePassed = DateTime.Now - StartTime;
                return TimeSpan.FromSeconds(MaxTime - timePassed.TotalSeconds);
            }
        }
    }
}