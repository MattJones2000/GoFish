using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Turns
    {
        public static void playerTurn(Player currentPlayer, Player opponent, List<Card> activeDeck)
        {
            

            Player.displayHand(currentPlayer); // Display current player hand

            Player.checkForDuplicates(currentPlayer); // Check hand for duplicate cards
            
            Console.WriteLine($"\nplayer 2:  Here is your hand: \n");
            Player.displayHand(opponent); 

            // Validate user input
            CardValue tempValue = promptForInput(currentPlayer);
            
            // Ensure that the card request exists in the current player's hand
            CardValue value  = checkPlayerHand(currentPlayer, tempValue);

            // Will check opponent's hand --> go fish or add a pair to current player pair number
            checkOpponentHand(currentPlayer, opponent,value ,activeDeck);
        }

        private static void checkOpponentHand(Player currentPlayer, Player opponent, CardValue value, List<Card> activeDeck)
        {
            
            // Make sure that the opponent has the card that they are requesting, will return null if they don't have it
            var opponentCard = opponent.HandOfCards.Find(card => card.Value == value);

            var currentPlayerCard = currentPlayer.HandOfCards.Find(card => card.Value == value);

            if (opponentCard != null)
            {
                // Remove the cards we found from both of their decks
                currentPlayer.HandOfCards.Remove(currentPlayerCard);
                opponent.HandOfCards.Remove(opponentCard);

                currentPlayer.NumOfPairs++;

                Console.WriteLine($" Player {opponent.PlayerNumber} has a {value}! A {value} has been removed from both players decks. Player {currentPlayer.PlayerNumber} " +
                    $"now has {currentPlayer.NumOfPairs} pairs!");
            }

            else
            {
                // Give the current player a card from the deck
                DeckOfCards.PickUp(currentPlayer, activeDeck);
                Console.WriteLine($"Go fish! Player {currentPlayer.PlayerNumber} has picked up one card");
            }

        }

        private static CardValue promptForInput(Player player) // Returns a valid card value
        {
            Console.Write("\nNow enter a value you want from the other player: \n");

            bool validValue = false;
            string input = "";

            while (!validValue) // While the user hasn't supplied us with a valid value
            {
                input = Console.ReadLine();

                // checks to see if the user input is contained within our cardvalue enum
                // If it doesn't exist throw an error 

                if (!Enum.IsDefined(typeof(CardValue), input.ToLower()))
                    Console.WriteLine("Enter a valid value: ace, two, king, etc.");
               
                else
                    validValue = true;
            }

            CardValue value = (CardValue)Enum.Parse(typeof(CardValue), input.ToLower());
            return value;
        }

        private static CardValue checkPlayerHand(Player player, CardValue value)
        {
            // Make sure that a card with the value that is requested is within the current player's hand

            bool inHand = true;

            // Checks the player's hand for the first card with the given value. Will return null if none are found
            var currentPlayerCard = player.HandOfCards.Find(card => card.Value == value);

            // Will store the correct value, default is that they entered a value that was correct

            CardValue newValue = value; 

            if (currentPlayerCard == null)
            {
                inHand = false;
            }

            while (!inHand)
            {
                // Validate user input again
                Console.WriteLine("\nYou must enter a value that you have in your hand\n");

                newValue = promptForInput(player);
               
                currentPlayerCard = player.HandOfCards.Find(card => card.Value == newValue);

                if (currentPlayerCard != null)
                {
                    inHand = true; 
                }

            }

                return newValue;
        }

      
      

  
    }
}
