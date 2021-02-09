using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public enum CardSuit { Diamonds, Spades, Hearts, Clubs }
    public enum CardValue
    {
        ace = 1,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        jack,
        queen,
        king
    }

    class Card
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public static void PrintCard(Card card)
        {
            string printString = "";

            if (card.Value == CardValue.ace)
            {
                printString =
                    " V         " +
                    "           " +
                    "           " +
                    "     S     " +
                    "           " +
                    "           " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.two)
            {
                printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "           " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.three)
            {
                printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.four)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "           " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.five)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "     S     " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.six)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.seven)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.eight)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.nine)
            {
                printString =
                    " V         " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "         V ";
                PrintMethod(card, printString);
            }
            if (card.Value == CardValue.ten || card.Value == CardValue.jack || card.Value == CardValue.queen || card.Value == CardValue.king)
            {
                printString =
                    " V         " +
                    "    S S    " +
                    "     S     " +
                    "  S S S S  " +
                    "     S     " +
                    "    S S    " +
                    "         V ";
                PrintMethod(card, printString);
            }
        }

        public static void ResetCursor(int cardsDisplayed)
        {
            // Manually sets the cursor position so our cards align (no new lines)
            int cursorXValue = cardsDisplayed * 11;
            Console.SetCursorPosition(cursorXValue, 7);
        }
        public static void PrintMethod(Card card, string cardString)
        {
            bool hasWrittenFirstNumber = false;

            switch (card.Suit)
            {
                case CardSuit.Hearts:
                case CardSuit.Diamonds:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case CardSuit.Clubs:
                case CardSuit.Spades:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            for (int i = 0; i < cardString.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (i % 11 == 0 && i != 0)
                {
                    Console.CursorLeft -= 11;
                    Console.CursorTop += 1;
                }
                if (cardString[i] == 'S')
                {
                    switch (card.Suit)
                    {
                        case CardSuit.Hearts:
                            Console.Write('♥');
                            break;
                        case CardSuit.Clubs:
                            Console.Write("♣");
                            break;
                        case CardSuit.Diamonds:
                            Console.Write("♦");
                            break;
                        case CardSuit.Spades:
                            Console.Write("♠");
                            break;
                    }
                    continue;
                }
                else if (cardString[i] == 'V')
                {
                    if (card.Value == CardValue.ten)
                    {
                        if (hasWrittenFirstNumber == false)
                        {
                            Console.Write(10);
                            hasWrittenFirstNumber = true;
                            i++;
                        }
                        else
                        {
                            Console.CursorLeft--;
                            Console.Write(10);
                        }
                        continue;
                    }
                    else if (card.Value == CardValue.jack)
                    {
                        Console.Write("J");
                    }
                    else if (card.Value == CardValue.queen)
                    {
                        Console.Write("Q");
                    }
                    else if (card.Value == CardValue.king)
                    {
                        Console.Write("K");
                    }
                    else if (card.Value == CardValue.ace)
                    {
                        Console.Write("A");
                    }
                    else 
                    {
                        int cardValue = (int)card.Value;
                        string cardValueAsString = cardValue.ToString();
                        Console.Write(cardValueAsString);
                    }
                  
                }
                else
                {
                    Console.Write(cardString[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
