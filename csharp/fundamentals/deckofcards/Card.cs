namespace DeckOfCards{
    public class Card{
        public string StringVal { get; set; }
        public string Suit { get; set; }
        public int Val { get; set; }

        public Card(string stringval, string suit, int val){
            StringVal = stringval;
            Suit = suit;
            Val = val;
        }
    }
}