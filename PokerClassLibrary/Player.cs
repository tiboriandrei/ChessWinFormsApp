using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PokerClassLibrary
{
    public class Player
    {
        public Player(string name, int chips)
        {
            Name = name;
            Chips = chips;
            
            //PokerEventsMediator.RequestHandData += SendHandData;
        }

        public string Name { get; set; }        
        public int Chips { get; set; }
        public Tuple<Card, Card> Hand { get; set; }

        public void DealHand(Tuple<Card, Card> hand) {
            
            Hand = hand;
        }

        public void SendHandData(object sender, EventArgs e) {           
                PlayerDataEventArgs args = new PlayerDataEventArgs { Hand = this.Hand };
                PokerEventsMediator.OnSendData(this, args);                
        }
    }
}
