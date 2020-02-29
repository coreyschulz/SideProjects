/* 
  CardDeck.cpp
  >> Implementation of the CardDeck class

  @author Corey Schulz
  @version 1.0 10/16/2019
 */

#include <stdlib.h>
#include "CardDeck.h"


void CardDeck::playOneRound()
{
  int newDeckIndex = numCards - 1; 
  int initialDeckSize = numCards; 

  while(initialDeckSize > 0)
  {
    round1Deck[newDeckIndex] = initialDeck[0]; 
    popCard(initialDeckSize); 
    newDeckIndex -= 1; 
    initialDeckSize -= 1; 

    if(initialDeckSize != 0)
    {
      int newEndVal = popCard(initialDeckSize); 
      initialDeck[initialDeckSize - 1] = newEndVal; 
    }
  }
}

int CardDeck::popCard(int deckSize)
{
  int ret = initialDeck[0]; 

  for(int i = 0; i < deckSize - 1; i++)
  {
    initialDeck[i] = initialDeck[i + 1];
  }

  return ret; 
}

void CardDeck::calculateRotationGroups()
{
  for(int i = 0; i < numCards; i++)
  {
    int currentIndex = i; 
    while(round1Deck[currentIndex] != i)
    {
      currentIndex = round1Deck[currentIndex]; 
      rotationGroups[i] += 1; 
    }
  }
}

int CardDeck::finalAnswer()
{
  int ret = 1; 
  for(int i = 0; i < numCards; i++)
  {
    ret *= rotationGroups[i] / gcd(ret, rotationGroups[i]);
  }
  return ret; 

}

int CardDeck::gcd(int a, int b)
{
  if(b == 0)
  {
    return a; 
  }
  return gcd(b, a % b); 
}

CardDeck::CardDeck(int input)
{
  numCards = input; 
  initialDeck = (int*)calloc(sizeof(int), numCards); 
  round1Deck = (int*)calloc(sizeof(int), numCards);
  rotationGroups = (int*)calloc(sizeof(int), numCards); 

  for(int i = 0; i < numCards; i++)
  {
    initialDeck[i] = i; 
    rotationGroups[i] = 1; 
  }
}

CardDeck::~CardDeck()
{
  free(initialDeck); 
  initialDeck = NULL; 

  free(round1Deck); 
  round1Deck = NULL; 

  free(rotationGroups); 
  rotationGroups = NULL; 
}

int CardDeck::playGame()
{
  playOneRound(); 
  calculateRotationGroups(); 
  return finalAnswer(); 
}
