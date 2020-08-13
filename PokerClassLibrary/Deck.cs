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

        private static Stack<Card> CardDeck { get; set; } = new Stack<Card>();

        private Deck() {            
            for (int i = 1; i <= 14; i++)
            {
                CardDeck.Push(new Card(Tuple.Create(i, CardColor.BlackHeart)));
                CardDeck.Push(new Card(Tuple.Create(i, CardColor.RedHeart)));
                CardDeck.Push(new Card(Tuple.Create(i, CardColor.Clover)));
                CardDeck.Push(new Card(Tuple.Create(i, CardColor.Diamond)));
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



        public static void Shuffle<T>(Stack<T> stack)
        {
            List<T> list = new List<T>();
            foreach (var item in stack)
            {
                list.Add(stack.Pop());
            }

            Random r = new Random(0);
            for (int i = list.Count - 1; i > 0; i--)
            {
                var temp = list[i];
                var index = r.Next(0, i + 1);
                list[i] = list[index];
                list[index] = temp;
            }

            foreach (var card in list)
            {
                stack.Push(card);
            }

            CardDeck = stack as Stack<Card>;
        }
    }
}
