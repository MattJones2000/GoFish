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
            int input;
            bool activeGame = true;

            Player player1 = new Player();
            Player player2 = new Player();
            
            // Initialize and shuffle deck
            DeckOfCards deck = new DeckOfCards();
            var activeDeck = deck.CreateNewDeck();
            deck.Shuffle(activeDeck);

            // Deal hands to both players

            deck.Deal(player1, player2, activeDeck);

            while (activeGame)
            {

                if (player1.handOfCards.Count == 0 || player2.handOfCards.Count == 0)
                {
                    activeGame = false;
                    break; 
                }

                Turns.playerTurn(player1,player2); 

            }
        }

      
        
    }
}
