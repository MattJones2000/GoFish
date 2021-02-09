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

            while (activeGame)
            {

                if (player1.HandOfCards.Count == 0 || player2.HandOfCards.Count == 0)
                {
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

        public static void Sleep(int time)
        {
            System.Threading.Thread.Sleep(time);
        }

    }
}
