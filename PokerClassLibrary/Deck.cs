using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerClassLibrary
{
    public sealed class Deck
    {
        private static Deck _Instance = null;
        public Stack<Card> Cards { get; set; } = new Stack<Card>();

        private Deck() {            
            for (int i = 1; i <= 14; i++)
            {
                Cards.Push(new Card(Tuple.Create(i, CardColor.BlackHeart)));
                Cards.Push(new Card(Tuple.Create(i, CardColor.RedHeart)));
                Cards.Push(new Card(Tuple.Create(i, CardColor.Clover)));
                Cards.Push(new Card(Tuple.Create(i, CardColor.Diamond)));
            }            
        }

        public static Deck GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Deck();
                }
                return _Instance;
            }
        }
    }
}
