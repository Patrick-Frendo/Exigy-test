using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test
{
    public class Card
    {
        //Getters and setters.
        public char Rank { get; set; }
        public char Suit { get; set; }

        //Constructor.
        public Card(char rank, char suit)
        {
            Rank = rank;
            Suit = suit;
        }
        
        //Method to add the 2 variables together in a string format.
        public override string ToString()
        {
            return $"{Rank}{Suit}";
        }
    }
}