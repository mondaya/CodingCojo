using System.Collections.Generic;

namespace DeckOfCards{
    public class Player{
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name){
            Name = name;
            Hand = new List<Card>();
        }


        public Card Draw(Deck deck){
            Card myCard = deck.Deal();
            Hand.Add(myCard);
            return myCard;
        }

        public Card Discard(int idx){
            idx--;
            if(idx >= Hand.Count){
                return null;
            }
            Card card = Hand[idx];
            Hand.RemoveAt(idx);
            return card;
        }
    }
}