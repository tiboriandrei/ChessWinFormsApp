using ChessClassLibrary.Clocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary
{
    public class PlayerEventArgs : EventArgs
    {
        public PieceColor pieceColor { get; set; }
    }

    public sealed class EventsMediator
    {
        private static readonly EventsMediator _Instance = new EventsMediator();
        private EventsMediator() { }

        public static EventsMediator GetInstance()
        {
            return _Instance;
        }

        // ----------------------------------------------------------------

        public static event EventHandler<PlayerEventArgs> PlayerMoved;
        public static void OnPlayerMoved(object sender, PlayerEventArgs e)
        {
            PlayerMoved?.Invoke(null, e);
        }

        // ----------------------------------------------------------------

        public static event EventHandler TimesUp;
        public static void OnTimesUp(object sender, EventArgs e)
        {
            TimesUp?.Invoke(sender, e);
        }

        // ----------------------------------------------------------------

        public static event EventHandler<PlayerEventArgs> Winner;
        public static void OnWinner(object sender, PlayerEventArgs e)
        {
            Winner?.Invoke(sender, e);
        }
    }
}
