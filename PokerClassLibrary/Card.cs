using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public class Card
    {
        public Card(Tuple<int, CardColor> type)
        {
            Type = type;
        }

        public Tuple<int, CardColor> Type { get; set; }
    }
}
