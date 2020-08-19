using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public static class Round
    { 
        public static List<Player> Players { get; set; }
        public static int Pot { get; private set; }        

        public static void NewRound()
        {
            Players = Game.Players;
            Pot = 0;            
        }

        public static void IncreasePot(int amount) {
            Pot += amount;            
        }        
    }
}
