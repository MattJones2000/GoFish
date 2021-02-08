using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Player
    {
        public bool activeTurn { get; set; }
        public int PlayerNumber { get; private set; }
        public List<Card> HandOfCards { get; set; }
        public int NumOfPairs { get; set; }

        public Player(int number, bool turn)
        {
            PlayerNumber = number;
            activeTurn = turn;
        }

        public static void checkForDuplicates(Player currentPlayer)
        {

            // Returns Dictionary<CardValue, Card>>
            var cardsOrderedByValue = currentPlayer.HandOfCards.GroupBy(card => card.Value);

            // Create the new hand for the player
            var newHand = new List<Card>();

            // for each key: value pair in the dictionary
            foreach (var valueCardPair in cardsOrderedByValue)
            {
                // Gets the card value of the current iteration
                var currentKey = valueCardPair.Key;

                // Returns the list of cards that correspond to the given key (card value in this case)
                var listOfCardsByKey = valueCardPair.ToList();

                // Gives us the number of cards that correspond to the given card value
                var numOfCards = listOfCardsByKey.Count;

                // If the cnumber of cards
                if (numOfCards % 2 != 0)
                {
                    // If the key only has one or three corresponding card, it's safe to add the first card to the deck
                    // Other wise we do nothing 
                    newHand.Add(listOfCardsByKey[0]);
                }

                else if (numOfCards == 2)
                {
                    currentPlayer.NumOfPairs++;

                    Console.WriteLine($"\nLucky! You had a pair of {currentKey}'s! They will removed from your deck and your pair count is now: " +
                        $"{currentPlayer.NumOfPairs} pairs!");
                }


                else if (numOfCards == 4)
                {
                    currentPlayer.NumOfPairs += 2;

                    Console.WriteLine($"\nLucky! You had two pairs of {currentKey}'s! They will removed from your deck and your pair count is now: " +
                        $"{currentPlayer.NumOfPairs} pairs!");
                }


            }


            currentPlayer.HandOfCards = newHand;

            displayHand(currentPlayer);

        }

        public static void displayHand(Player currentPlayer)
        {
            Console.WriteLine($"Player {currentPlayer.PlayerNumber} it is your turn! Here is your hand: \n");

            foreach (Card card in currentPlayer.HandOfCards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }
    }
}
