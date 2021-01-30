using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class GameDriver
    {

        public GameDriver()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("\nWelcome to GoFish!\n");

            RunGame();
        }

        private void RunGame()
        {
            int input;
            bool activeGame = true;

            Player player1 = new Player();
            Player player2 = new Player();
            
            // Initialize and shuffle deck
            DeckOfCards deck = new DeckOfCards();
            var activeDeck = deck.CreateNewDeck();
            deck.Shuffle(activeDeck);

            // Deal hands to both players

            deck.Deal(player1,player2,activeDeck);

            Console.WriteLine("Player 1 it is your turn! Here is your hand: \n");

            displayHand(player1);

            input = GetSafeInt("Now ask for a value from player 2 (card value only): ");

            
          
                
           


            while (activeGame)
            {
                





                if (player1.handOfCards.Count == 0 || player2.handOfCards.Count == 0)
                {
                    activeGame = false;
                    break; 
                }

            }
        }

        public void displayHand(Player player)
        {

            foreach (Card card in player.handOfCards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }

        static int GetSafeInt(string prompt)
        {
            int numOne = 0;
            string input = "";
            bool bValid = false;

            while (!bValid)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                try
                {
                    numOne = Convert.ToInt32(input);
                    bValid = true;
                }

                catch (Exception e)
                {
                    Console.WriteLine("Invalid Entry... Make sure input is in int form");
                }
            } // Ends while loop

            return numOne;
        }
    }
}
