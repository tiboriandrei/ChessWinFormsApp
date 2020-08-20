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

        private static Thread t1;        

        public static void InitDealer() {
            Deck = Deck.GetInstance;
            PokerEventsMediator.AddPlayer += AddPlayer;
            PokerEventsMediator.PlayerAction += HandlePlayerAction;
            PokerEventsMediator.BetsStageEnded += Deal;
        }        

        private static void StartNewRound() {
            foreach (var card in CutCards) { Deck.Cards.Push(card); }
            foreach (var card in FloppedCards) { Deck.Cards.Push(card); }

            Deck.Cards = Shuffle(Deck.Cards);

            Round.NewRound();

            foreach (var player in Round.Players) { DealHand(player); }

            PlayerActionEventArgs args = new PlayerActionEventArgs { };
            PokerEventsMediator.OnUpdateGraphics(null, args);
                        
            t1 = new Thread(StartBets);
            t1.Start();
        }

        private static int stage = 0;
        private static void Deal(object sender, EventArgs e) {
            switch (stage)
            {
                case 0: DealFlop();
                    break;
                case 1:
                    DealOneCard();
                    break;
                case 2:
                    DealOneCard();
                    break;
            }

            FlopEventArgs flopArgs = new FlopEventArgs { FloppedCards = FloppedCards };
            PokerEventsMediator.OnFlop(null, flopArgs);

            if (stage <= 2) {
                t1 = new Thread(StartBets);
                t1.Start();
                Clock.InitClock(15);
            } else if (stage > 2) {
                //show hands, calculate winner     
                Clock.StopClock();
            }

            
        }

        private static PlayerAction action;
        private static int PlayerBet = 0;
        private static int LastBet;
        
        public static void StartBets() {
            int placeAtTable = 0;
            LastBet = 0;

            for (int i = 0; i < Round.Players.Count; i++)
            {
                Clock.InitClock(15);                

                action = PlayerAction.Wait;
                PlayerDataEventArgs args = new PlayerDataEventArgs
                {
                    Chips = Round.Players[i].Chips,
                    PlaceAtTable = placeAtTable++,
                    LastBet = LastBet
                };
                PokerEventsMediator.OnStartBet(null, args);
                   
                while (action == PlayerAction.Wait)
                {
                    Thread.Sleep(10);
                }

                switch (action)
                {                   
                    case PlayerAction.Check:
                        break;
                    case PlayerAction.Bet:
                        Round.IncreasePot(PlayerBet, i);
                       
                        LastBet = PlayerBet - LastBet;
                        if (PlayerBet > LastBet)
                        {
                            //start new betting round where index 0 = next player
                        }
                        break;
                    case PlayerAction.Fold:
                        Round.Players.RemoveAt(i--);
                        break;
                }
            }  
            
            PokerEventsMediator.OnBetsStageEnded(null, EventArgs.Empty);
            stage++;            
        }

        private static void HandlePlayerAction(object sender, PlayerActionEventArgs e) {
            action = e.Action;
            PlayerBet = e.BetAmount;            
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
            FloppedCards.Add(Deck.Cards.Pop());
        }

        public static void AddPlayer(object sender, PlayerDataEventArgs e) {
            Game.Players.Add(new Player(e.Name, e.Chips));
        }


        public static void StartGame() {
            Thread t0 = new Thread(StartNewRound);
            t0.Start();
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
