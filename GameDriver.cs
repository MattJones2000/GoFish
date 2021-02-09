using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class GameDriver
    {
        public void RunGame()
        {
            
            bool activeGame = true;

            Player player1 = new Player(1, true);
            Player player2 = new Player(2, false);
            
            // Initialize and shuffle deck
            DeckOfCards deck = new DeckOfCards();
            var activeDeck = deck.CreateNewDeck();
            DeckOfCards.Shuffle(activeDeck);

            // Deal hands to both players

            DeckOfCards.Deal(player1, player2, activeDeck);
            Console.WriteLine("\n**************** WELCOME TO GOOOOOOOOOOO FISHHH!!!! *********************\n");
            while (activeGame)
            {

                if (player1.HandOfCards.Count == 0 || player2.HandOfCards.Count == 0)
                {
                    declareWinner(player1, player2);
                    activeGame = false;
                    break; 
                }

                
                if (player1.activeTurn)
                {
                    // Runs the turns method as player1 being the current player
                    Turns.playerTurn(player1, player2, activeDeck);
                    player1.activeTurn = false; 
                    
                }

                else
                {
                    // Runs the turns method as player2 being the current player
                    Turns.playerTurn(player2, player1, activeDeck);
                    player1.activeTurn = true;
                }

            }

            
        }

        private void declareWinner(Player player1, Player player2)
        {
            if (player1.NumOfPairs > player2.NumOfPairs)
            {
                Console.WriteLine("\n**************** WE HAVE A WINNER ****************************\n");
                Console.WriteLine("\n The deck has run out and now we need to decide a winner.... drumroll please...\n");
                GameDriver.Sleep(4000);

                Console.WriteLine($"\nPlayer {player1.PlayerNumber} has won! Player {player1.PlayerNumber} had {player1.NumOfPairs} pairs while " +
                    $"Player {player2.PlayerNumber} came close with {player2.NumOfPairs} pairs!");


                Console.WriteLine("\n Press enter to exit the program.");
                Console.ReadLine();
            }

            else if (player2.NumOfPairs > player1.NumOfPairs)
            {
                Console.WriteLine("\n**************** WE HAVE A WINNER ****************************\n");
                Console.WriteLine("\nThe deck has run out and now we need to decide a winner.... drumroll please...\n");
                GameDriver.Sleep(4000);

                Console.WriteLine($"\nPlayer {player2.PlayerNumber} has won! Player {player2.PlayerNumber} had {player2.NumOfPairs} pairs while " +
                    $"Player {player1.PlayerNumber} came close with {player1.NumOfPairs} pairs!\n");


                Console.WriteLine("\n Press enter to exit the program.");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("\nThe game has ended in a tie!\n");

                Console.WriteLine($"\nBoth players have {player1.NumOfPairs} pairs!\n");

                Console.WriteLine("\nPress enter to exit the program.");
                Console.ReadLine();
            }
        }

        public static void Sleep(int time)
        {
            System.Threading.Thread.Sleep(time);
        }

        private void announceResults (Player player)
        {
            Console.WriteLine("\n**************** WE HAVE A WINNER ****************************\n");
            Console.WriteLine("\n The deck has run out and now we need to decide a winner.... drumroll please...\n");
            GameDriver.Sleep(4000);

        }
    }
}
