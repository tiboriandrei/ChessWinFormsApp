using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public static class Round
    { 
        //public static List<Player> Players { get; set; }
        public static int Pot { get; private set; }
        public static List<Card> FloppedCards { get; private set; } = new List<Card>();

        public static void NewRound()
        {
            Pot = 0;
            FloppedCards.Clear();
        }

        public static void IncreasePot(int amount) {
            Pot += amount;
        }
    }
}
