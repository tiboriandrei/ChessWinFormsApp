using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerClassLibrary
{
    public static class Dealer
    {
        private static Deck Deck { get; set; }
        private static List<Card> CutCards { get; set; } = new List<Card>();
        
        public static void InitDealer() {
            Deck = Deck.GetInstance;
            PokerEventsMediator.AddPlayer += AddPlayer;
        }

        private static void StartNewRound() {
            foreach (var card in CutCards)
            {
                Deck.Cards.Push(card);
            }
            Deck.Cards = Shuffle(Deck.Cards);

            Round.NewRound();

            foreach (var player in Round.Players)
            {
                DealHand(player);
            }

            //draw cards

            StartBets();

            // wait for bids

            // DealFlop();

            // wait for bids

            // DealOneCard();

            // wait for bids

            // DealOneCard();

            // wait for bids



            //Round round = new Round(Game.Players, new List<Card>());
        }

        public static void StartBets() {
            foreach (var player in Round.Players)
            {
                //request player action
                //sleep waiting for player action
                //handle action
            }
        }

        private static void DealHand(Player player) {            
            var card1 = Deck.Cards.Pop();
            var card2 = Deck.Cards.Pop();
            player.DealHand(Tuple.Create(card1, card2));            
        }

        private static void DealFlop() {
            CutCards.Add(Deck.Cards.Pop());
            List<Card> Flop = new List<Card>
            {
                Deck.Cards.Pop(),
                Deck.Cards.Pop(),
                Deck.Cards.Pop()
            };
        }

        private static void DealOneCard() {
            CutCards.Add(Deck.Cards.Pop());
            Card TurnRiver = Deck.Cards.Pop();
        }

        public static void AddPlayer(object sender, PlayerDataEventArgs e) {
            Game.Players.Add(new Player(e.Name, e.Chips));

            if (Game.Players.Count == 2)
            {
                StartNewRound();
            }
        }

        private static void MoveChips() { 
            
        }

        private static Stack<T> Shuffle<T>(Stack<T> stack)
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
