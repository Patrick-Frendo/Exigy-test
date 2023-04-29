using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using test;

namespace ClockPatience
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the input of a file. 
            //Avoid having to manually input the characters one by one.
            string input = File.ReadAllText("input.txt");

            //Split the input into separate lines.
            string[] inputStrings = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // Initialize to keep track of the current line.
            int index = 0;

            //Loop through each line of input, stopping when the "#" character is found.
            while (inputStrings[index] != "#")
            {
                // Create a new list to store Card objects.
                List<Card> cards = new List<Card>();

                //For each set of 4 lines, create a list of Card objects.
                for (int i = 0; i < 4; i++)
                {
                    // Split the current line into individual card strings.
                    string[] cardStrings = inputStrings[index + i].Split(' ');
                    foreach (string cardString in cardStrings)
                    {
                        //Add each new "card" into the card object.
                        cards.Add(new Card(cardString[0], cardString[1]));
                    }
                }

                // Increment the index by 4 to move to the next set.
                index += 4;

                // Create a dictionary to map card ranks to their corresponding integer values.
                // This will be used to determine which pile a card should be moved to.                
                Dictionary<char, int> cardValues = new Dictionary<char, int>
                {
                    { 'A', 1}, { '2', 2}, { '3', 3}, { '4', 4}, { '5', 5}, { '6', 6}, { '7', 7},
                    { '8', 8}, { '9', 9}, { 'T', 10}, { 'J', 11}, { 'Q', 12}, { 'K', 13}
                };

                //Initialize 13 card piles as stacks, one for each hour on a clock(1 - 12 + the king pile = 13).
                List<Stack<Card>> piles = new List<Stack<Card>>();
                for (int i = 0; i < 13; i++)
                {
                    piles.Add(new Stack<Card>());
                }

                // Distribute the cards from the 'cards' list to the piles in reverse order.
                for (int i = cards.Count - 1; i >= 0; i--)
                {
                    // Calculate the pile index based on the position of the card in the 'cards' list.
                    int pileIndex = (cards.Count - 1 - i) % 13;

                    // Add the current card to the appropriate pile.
                    piles[pileIndex].Push(cards[i]);
                }

                // Initialize variables to keep track of the exposed card count, last exposed card, and current pile.
                int exposedCount = 0;
                Card? lastCardExposed = null;
                int currentPile = 12;

                /*
                While there are still face-down cards in the current pile, perform the following steps:
                    a. Pop the top card from the current pile.
                    b. Increment the exposed card count.
                    c. Set the last exposed card to the current card.
                    d. Update the current pile based on the value of the current card.
                */
                while (piles[currentPile].Count > 0)
                {
                    Card currentCard = piles[currentPile].Pop();
                    exposedCount++;
                    lastCardExposed = currentCard;
                    currentPile = cardValues[currentCard.Rank] - 1;
                }

                //If the last exposed card is not null, print the number of exposed cards and the last exposed card. 
                //If no cards were exposed, print a message indicating this.
                if (lastCardExposed != null)
                {
                    Console.WriteLine($"{exposedCount:D2},{lastCardExposed}");
                }
                else
                {
                    Console.WriteLine("No cards were exposed.");
                }
            }
        }
    }
}
