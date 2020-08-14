using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public class PlayerDataEventArgs : EventArgs {
        public string Name { get; set; }
        public int Chips { get; set; }
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

        
    }
}
