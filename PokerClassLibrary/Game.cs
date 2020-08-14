using System;
using System.Collections.Generic;
using System.Text;

namespace PokerClassLibrary
{
    public static class Game
    {
        public static List<Player> Players { get; set; }

        public static void AddPlayer(Player player) {
            Players.Add(player);
        }

        public static void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
    }
}
