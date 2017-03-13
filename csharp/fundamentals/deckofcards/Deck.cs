using System;
using System.Collections.Generic;

namespace DeckOfCards{
    public class Deck{
        List<Card> cards { get; set; }

        public Deck(){
            cards = new List<Card>();
            Reset();
        }

        public Card Deal(){
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void Reset(){
            string[] cardVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suits = {"Clubs", "Hearts", "Spades", "Diamonds"};

            for(int i = 0; i < suits.Length; i++){
                for(int j = 0; j < cardVals.Length; j++){
                    Card myCard = new Card(cardVals[j], suits[i], j + 1);
                    cards.Add(myCard);
                }
            }
        }

        public void Shuffle(){
            Random rand = new Random();
            
            for(int i = 0; i < cards.Count - 1; i++){
                int RandIdx = rand.Next(i, 52);

                Card temp = cards[RandIdx];
                cards[RandIdx] = cards[i];
                cards[i] = temp;
            }
        }
    }
}