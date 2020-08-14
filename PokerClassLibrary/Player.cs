using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public class Player
    {
        public Player(string name, int chips)
        {
            Name = name;
            Chips = chips;
        }

        public string Name { get; set; }        
        public int Chips { get; set; }
        public Tuple<Card, Card> Hand { get; set; }
    }
}
