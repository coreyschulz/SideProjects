/* 
  main.cpp
  >> Calculate number of rounds for deck to be put back in order. 

  @author Corey Schulz
  @version 1.0 10/16/2019
 */

#include <cstdio>
#include <cstdlib>
#include "CardDeck.h"
  
int main(int argc, char** argv) 
{ 
  if(argc != 2)
  {
    printf("Error! Please enter only one integer argument!\n"); 
    return 0; 
  }

  int numCards = atoi(argv[1]);
  CardDeck deck(numCards);

  printf("%d\n", deck.playGame()); 
  return 0; 
}
