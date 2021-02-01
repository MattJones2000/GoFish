using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards deck = new DeckOfCards();

            var activeDeck = deck.CreateNewDeck();

            deck.Shuffle(activeDeck);

            Console.WriteLine("\nShuffled Deck:\n");
            foreach (Card cards in activeDeck)
            {
                Console.WriteLine($"{cards.Value} of {cards.Suit}");
            }

            Player player1 = new Player();
            Player player2 = new Player();

            deck.Deal(player1, player2, activeDeck);

            Console.WriteLine("\nPlayer 1's hand:");
            foreach (Card card in player1.handOfCards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }

            Console.WriteLine("\nPlayer 2's hand:");
            foreach (Card card in player2.handOfCards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }

            Console.WriteLine($"Deck count after deal is: {activeDeck.Count}");


            GameDriver game = new GameDriver();

            game.RunGame();

        }   
    }
}
