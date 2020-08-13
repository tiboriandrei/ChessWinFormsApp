using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public class Player
    {
        public int Chips { get; set; }
        public Tuple<Card, Card> MyProperty { get; set; }
    }
}
