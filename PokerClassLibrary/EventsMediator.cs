using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public sealed class EventsMediator
    {
        private static readonly EventsMediator _Instance = new EventsMediator();
        private EventsMediator() { }

        public static EventsMediator GetInstance()
        {
            return _Instance;
        }
    }
}
