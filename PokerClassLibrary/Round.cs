using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public static class Round
    { 
        //public static List<Player> Players { get; set; }
        public static int Pot { get; set; } = 0;
        public static List<Card> FloppedCards { get; set; } = new List<Card>();
    }
}
