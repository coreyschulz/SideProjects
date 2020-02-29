/* 
  CardDeck.h
  >> CardDeck outline

  @author Corey Schulz
  @version 1.0 10/16/2019
 */

#ifndef CARD_DECK_H
#define CARD_DECK_H

class CardDeck
{
    private: 
    int numCards; 
    int *initialDeck; 
    int *round1Deck; 
    int *rotationGroups; 

    /**
      Plays a single round of the shuffling game. 
      From the resultant deck, we can determine the rotation groups
       for the game (which means we don't have to play every single round!)
    */
    void playOneRound(); 

    /**
      "pops" a card off the deck. 
      Since I can't use dynamically-sized arrays for this problem, I really just 
       keep track elsewhere of what the max size of the array is, and then the extra
       space is filled with things that used to be needed.
      Helper method for playOneRound. 
      
      @param deckSize current size of the deck, should decrease after pop.
      @return the popped value
    */
    int popCard(int deckSize); 

    /*
      Calculates which cards move with each in the same pattern each turn (and how many),
      updates rotationGroups with that pattern. 
    */ 
    void calculateRotationGroups(); 

    /**
      returns the final answer, which is the least common multiple of each
       of the rotation groups.

      @return the game's final answer!
    */ 
    int finalAnswer(); 

    /**
      returns the greatest common divisor between the two numbers. 
      Helper method for calculateRotationGroups.

      @param a first integer
      @param b second integer
      @return the greatest common divisor
    */
    int gcd(int a, int b); 

    public: 
    /**
      CardDeck constructor
      @param input number of cards in the deck
    */ 
    CardDeck(int input); 

    /**
      CardDeck destructor 
      Cleans up calloc'd memory used in initialDeck, round1Deck, rotationGroups!
    */ 
    ~CardDeck(); 

    /**
      Helper method to play overall game. 
      Runs all the steps necessary to produce the final answer!
      
      @return the game's final answer!
    */ 
    int playGame(); 
};

#endif 