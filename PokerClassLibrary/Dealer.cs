using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerClassLibrary
{
    public static class Dealer
    {
        private static Deck Deck { get; set; }
        private static List<Card> CutCards { get; set; }
        
        public static void InitDealer() {
            Deck = Deck.GetInstance;
        }

        public static void StartNewRound() {
            foreach (var card in CutCards)
            {
                Deck.Cards.Push(card);
            }
            Deck.Cards = Shuffle(Deck.Cards);

            Round.FloppedCards.Clear();
            Round.Pot = 0;

            //Round round = new Round(Game.Players, new List<Card>());
        }

        public static void DealFlop() {
            CutCards.Add(Deck.Cards.Pop());
            List<Card> Flop = new List<Card>
            {
                Deck.Cards.Pop(),
                Deck.Cards.Pop(),
                Deck.Cards.Pop()
            };
        }

        public static void DealOneCard()
        {
            CutCards.Add(Deck.Cards.Pop());
            List<Card> TurnRiver = new List<Card>
            {
                Deck.Cards.Pop(),                
            };
        }
        
        public static void MoveChips() { 
            
        }

        public static Stack<T> Shuffle<T>(Stack<T> stack)
        {
            List<T> list = (from item in stack
                            select stack.Pop()).ToList();

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

            return stack;
        }
    }
}
