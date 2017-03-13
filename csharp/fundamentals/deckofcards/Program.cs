using System;

namespace DeckOfCards
{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("Hello World!");
            Player donovan = new Player("Donovan");
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            System.Console.WriteLine(myDeck);
            donovan.Draw(myDeck);
            donovan.Draw(myDeck);
            donovan.Draw(myDeck);
            donovan.Discard(3);
            donovan.Discard(3);
        }
    }
}
