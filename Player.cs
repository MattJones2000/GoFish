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
                if (numOfCards == 1)
                {
                    // If the key only has one or three corresponding card, it's safe to add the first card to the deck
                    // Other wise we do nothing 
                    newHand.Add(listOfCardsByKey[0]);
                }

                else if (numOfCards == 2)
                {
                    currentPlayer.NumOfPairs++;

                    Console.WriteLine($"\nYou had a pair of {currentKey}'s! They will removed from your deck and your pair count is now: " +
                        $"{currentPlayer.NumOfPairs} pairs!\n");

                    GameDriver.Sleep(3000);
                }

                else if (numOfCards == 3)
                {
                    currentPlayer.NumOfPairs++;

                    Console.WriteLine($"\nYou had a pair of {currentKey}'s! They will removed from your deck and your pair count is now: " +
                        $"{currentPlayer.NumOfPairs} pairs!\n");

                    newHand.Add(listOfCardsByKey[0]);
                    GameDriver.Sleep(3000);
                }

                else if (numOfCards == 4)
                {
                    currentPlayer.NumOfPairs += 2;

                    Console.WriteLine($"\nLucky! You had two pairs of {currentKey}'s! They will removed from your deck and your pair count is now: " +
                        $"{currentPlayer.NumOfPairs} pairs!\n");

                    GameDriver.Sleep(3000);
                }


            }

            if (newHand.Count != currentPlayer.HandOfCards.Count)
            {
                Console.WriteLine($"\nPlayer {currentPlayer.PlayerNumber} it is still your turn, press enter to get your new hand:\n ");

                currentPlayer.HandOfCards = newHand;
                Console.ReadLine();
                Console.Clear();
                displayHand(currentPlayer);
            }

        }

        public static void displayHand(Player currentPlayer)
        {
            GameDriver.Sleep(3000);

            int numOfCardsDisplayed = 1;
            foreach (Card card in currentPlayer.HandOfCards)
            {
                numOfCardsDisplayed++;
                Card.ResetCursor(numOfCardsDisplayed);
                Card.PrintCard(card);
               
               // Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }
    }
}
