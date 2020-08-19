using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public class PlayerDataEventArgs : EventArgs {
        public string Name { get; set; }
        public int Chips { get; set; }
        public Tuple<Card, Card> Hand { get; set; }
        public int PlaceAtTable { get; set; }
    }

    public class PlayerActionEventArgs : EventArgs {
        public PlayerAction Action { get; set; }
        public int BetAmount { get; set; }
    }

    public class FlopEventArgs : EventArgs {
        public List<Card> FloppedCards { get; set; }        
    }

    public sealed class PokerEventsMediator
    {
        private static readonly PokerEventsMediator _Instance = new PokerEventsMediator();
        private PokerEventsMediator() { }

        public static PokerEventsMediator GetInstance()
        {
            return _Instance;
        }

        // ----------------------------------------------------------------

        public static event EventHandler<PlayerDataEventArgs> AddPlayer;
        public static void OnAddPlayer(object sender, PlayerDataEventArgs e)
        {
            AddPlayer?.Invoke(null, e);
        }

        // ----------------------------------------------------------------

        public static event EventHandler UpdateGraphics;
        public static void OnUpdateGraphics(object sender, EventArgs e)
        {
            UpdateGraphics?.Invoke(null, e);
        }

        // ----------------------------------------------------------------

        public static event EventHandler<PlayerDataEventArgs> StartBet;
        public static void OnStartBet(object sender, PlayerDataEventArgs e)
        {
            StartBet?.Invoke(null, e);
        }

        // ----------------------------------------------------------------

        public static event EventHandler<PlayerActionEventArgs> PlayerAction;
        public static void OnPlayerAction(object sender, PlayerActionEventArgs e)
        {
            PlayerAction?.Invoke(sender, e);
        }
        
        // ----------------------------------------------------------------

        public static event EventHandler<FlopEventArgs> Flop;
        public static void OnFlop(object sender, FlopEventArgs e)
        {
            Flop?.Invoke(null, e);
        }

        // ----------------------------------------------------------------

        public static event EventHandler BetsStageEnded;
        public static void OnBetsStageEnded(object sender, EventArgs e)
        {
            BetsStageEnded?.Invoke(null, e);
        }


    }
}
