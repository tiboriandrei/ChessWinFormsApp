using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PokerClassLibrary
{
    public static class Dealer
    {
        private static Deck Deck { get; set; }
        private static List<Card> FloppedCards { get; set; } = new List<Card>();
        private static List<Card> CutCards { get; set; } = new List<Card>();

        public static void InitDealer() {
            Deck = Deck.GetInstance;
            PokerEventsMediator.AddPlayer += AddPlayer;
            PokerEventsMediator.PlayerAction += HandlePlayerAction;
        }

        private static Thread t1;

        private static void StartNewRound() {
            foreach (var card in CutCards) { Deck.Cards.Push(card); }
            foreach (var card in FloppedCards) { Deck.Cards.Push(card); }

            Deck.Cards = Shuffle(Deck.Cards);

            Round.NewRound();

            foreach (var player in Round.Players) { DealHand(player); }
            PokerEventsMediator.OnUpdateGraphics(null, EventArgs.Empty);

            t1 = new Thread(StartBets);
            t1.Start();

            while (t1.IsAlive) {
                Thread.Sleep(10);
            }

            DealFlop();

            FlopEventArgs flopArgs = new FlopEventArgs { FloppedCards = FloppedCards };
            PokerEventsMediator.OnFlop(null, flopArgs);

            t1 = new Thread(StartBets);
            t1.Start();

            // wait for bids

            // DealOneCard();

            // wait for bids

            // DealOneCard();

            // wait for bids

            //Round round = new Round(Game.Players, new List<Card>());
        }

        private static PlayerAction action;
        private static int PlayerBet = 0;
        public static void StartBets() {
            int placeAtTable = 0;

            for (int i = 0; i < Round.Players.Count; i++)
            {
                action = PlayerAction.Wait;
                PlayerDataEventArgs args = new PlayerDataEventArgs
                {
                    Chips = Round.Players[i].Chips,
                    PlaceAtTable = placeAtTable++
                };
                PokerEventsMediator.OnStartBet(null, args);

                Clock.ResumeClock();

                while (action == PlayerAction.Wait)
                {
                    Thread.Sleep(10);
                }

                switch (action)
                {
                    case PlayerAction.Wait:
                        break;
                    case PlayerAction.Check:
                        break;
                    case PlayerAction.Bet:
                        Round.IncreasePot(PlayerBet);
                        break;
                    case PlayerAction.Fold:
                        Round.Players.RemoveAt(i--);
                        break;
                }
            }             
            t1.Abort();
        }

        private static void HandlePlayerAction(object sender, PlayerActionEventArgs e) {
            action = e.Action;
            PlayerBet = e.BetAmount;
            Clock.InitClock(10);
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
            FloppedCards.AddRange(Flop);
        }

        private static void DealOneCard() {
            CutCards.Add(Deck.Cards.Pop());
            Card TurnRiver = Deck.Cards.Pop();
        }

        public static void AddPlayer(object sender, PlayerDataEventArgs e) {
            Game.Players.Add(new Player(e.Name, e.Chips));

            if (Game.Players.Count == 2)
            {
                Thread t0 = new Thread(StartNewRound);
                t0.Start();
            }
        }

        private static void MoveChips() { 
            
        }

        private static Stack<T> Shuffle<T>(Stack<T> stack)
        {
            List<T> list = new List<T>();
            int length = stack.Count;
            for (int i = 0; i < length; i++)
            {
                list.Add(stack.Pop());
            }

            Random r = new Random();
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
