using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Turns
    {
        public static void playerTurn(Player currentPlayer, Player opponent)
        {
            Console.WriteLine($"{currentPlayer} it is your turn! Here is your hand: \n");

            displayHand(currentPlayer); // Display current player hand

            CardValue value = promptForInput(currentPlayer);

            checkOtherPlayerHand(opponent,value);
        }

        private static void checkOtherPlayerHand(Player player, CardValue value)
        {
            // Checks the other players hand for a card that contains the value given
            if (player.handOfCards.Exists(card => card.Value == value)) 
            {
                Console.WriteLine("Match!");
            }

            else
            {
                Console.WriteLine("Go fish!");
            }
        }

        public static CardValue promptForInput(Player player) // Returns a valid card value
        {
            Console.Write("Now enter a value you want from the other player: \n");

            bool validValue = false;
            string input = "";

            while (!validValue) // While the user hasn't supplied us with a valid value
            {
                input = Console.ReadLine();

                // checks to see if the user input is contained within our cardvalue enum
                // If it doesn't exist throw an error 

                if (!Enum.IsDefined(typeof(CardValue), input.ToLower()))
                    Console.WriteLine("Enter a valid value: ace, deuce, king, etc.");

                else
                    validValue = true;
            }

            // Converts the user input string to a CardValue type
            CardValue value = (CardValue)Enum.Parse(typeof(CardValue), input);

            return value;
        }

        public static void displayHand(Player player)
        {

            foreach (Card card in player.handOfCards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }

    }
}
