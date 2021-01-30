using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class DeckOfCards
    {
        public List<Card> CreateNewDeck()
        {
            List<Card> Deck = new List<Card>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Card playingCard = new Card(suit, value);
                    Deck.Add(playingCard);

                }
            }
            return Deck; 
        }

        static Random r = new Random();
        public void Shuffle(List<Card> deck)
        {
            for (var i = deck.Count - 1; i > 0; i--)
            {
                var temp = deck[i];
                var index = r.Next(0, i + 1);
                deck[i] = deck[index];
                deck[index] = temp;
            }
        }

        public void Deal(Player player1, Player player2, List<Card> deck)
        {

                player1.handOfCards = deck.Take(7).ToList();
                deck.RemoveRange(0, 7); // Take the first 7 cards of the deck and give to player
                                        // then remove those cards from the deck. 

                player2.handOfCards = deck.Take(7).ToList();
                deck.RemoveRange(0, 7); 
          
        }

        public void PickUp(Player player, List<Card> deck)
        {
            // A single player picks up a single card (go fish)
            player.handOfCards = deck.Take(1).ToList();
            deck.RemoveRange(0, 1);
        }
    }

}
