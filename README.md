# Exigy test
Clock Patience Solitair (Alpha Version)

Clock or Sundial is a luck-based patience or solitaire card game with the cards laid out to represent the face of a clock. It is closely related to Travellers.

Clock is a purely mechanical process with no room for skill, and the chances of winning are exactly 1 in 13. It has a feature described by Parlett as 'shuttling' in which a card is placed at the bottom of a pile and the next card to be played comes off the top of the same pile.

Rules
One deck of cards (minus jokers) is used. The deck is shuffled and twelve piles of four cards each are laid out, face down, in a circle. The remaining four cards are placed, also face down, in a pile in the center of the circle.

The twelve positions around the circle represent the 12-hour clock and the pile in the middle represents the hands.

Play starts by turning over the top card of the central pile. When a card is revealed, it is placed face up under the pile at the corresponding hour (i.e., Ace = 1 o'clock, 2 = 2 o'clock, etc. The Jack is 11 o'clock and the Queen is 12 o'clock) and the top card of the pile of that hour is turned over. If a King is revealed, it is placed face up under the central pile.

Play continues in this fashion and the game is won if all the cards (including four Kings) are revealed; turning up the fourth king means you will have completed the clock and won the game. The game is lost if the fourth King is turned up while any cards remain face down.

Reference:
Wikipedia. (2023). Clock (card game). [online] Available at: https://en.wikipedia.org/wiki/Clock_(card_game) [Accessed 27 Apr. 2023].

Implementation
The application uses object-oriented design principles and includes a Card class to represent individual cards. The Card class has properties for Rank and Suit, a constructor to initialize these properties, and a ToString method to return the card representation.

The main logic of the game is implemented in the Main method, where the input is read, the cards and piles are created, and the game is played. The program outputs the results as specified in the problem description.

Development stage (C#)

This console application is an alpha version of a C# implementation of a Clock Patience game solver. 

Note: This alpha version focuses on the core functionality of solving the game (aka it works). Its primary goal is to ensure the application works correctly. Further development will involve evaluating if more complexity is required and refining the implementation based on myself the developer.

Alpha v1.0

Current brain storming ideas:

Card can be in a class with the attributes :
- Rank 
- Suit

-- Needs to be added together we can use ToString for that. Reference: https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring?view=net-8.0

Main method:
Step 1: While loop will be needed to keep asking user for an input untill they enter '#'.
Step 2: Create a list for the object card to store all the input cards. Each card will need to be split into an array of card strings (as input is a string), creating the said card objects.
Step 3: A dictionary is needed to use map for card ranks to the numberic values (A=1 ... K=13).
Step 4: To represent a the clock piles, i found this: https://www.tutorialsteacher.com/csharp/csharp-stack. So for each number in the clock +1(12 for number of clock numbers + 1 for the King pile = 13 Total) there needs to be 13 stacks in a list. So in coding i need to use "List<Stack<Card>>" name it either piles or just stack. 
Step 5: I need to loop through the cards and push the card into the appropriate pile based on the index in the list. 
Step 6: have 2 variable minimum: 1 for the counting the exposed cards and the other to check the last remaining card.
Step 7: Start the gaming part of the code! need to set the pile of the cards into 12 piles.
Step 8: Create a loop for the following steps:
    -   Pop the top card from the the current pile and store it in the exposedCard variable(See step 6).
    -   And put it in the a new variable called currentCard to be able to know which card the system will be controlling.
    -   Increment the exposedCard to check how many cards are left to expose.
    -   Find a way to update the currentPile based on the numberic value of the currentCard rank.(might use the dictionary for this)
Step 9: Once the game ends, we need to print out the following: exposedCount as 2 digits and lastCardExposed as mentioned in the sample.