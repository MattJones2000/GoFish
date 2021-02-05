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
        

    }
}
