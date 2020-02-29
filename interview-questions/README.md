# Shuffle Game

## Compiling and Running
I used C++ to solve this problem. To compile: 

```bash
$ g++ -o carddeck main.cpp CardDeck.cpp
```

...And then to run: 

```bash
$ ./carddeck 500
```
Where 500 can be replaced with the input (int) argument! 

This was compiled on my machine with `Apple clang version 11.0.0` via `g++ version 4.2.1`. 

## Design

I started off by implementing the naive version, where you go through the game manually for every round. That turned out to be nonperformant very quickly, so I decided to find another solution. 

I had to go through the game by hand quite a few times to finally get the pattern, but once I did (and figured out the math) it turned out to be a fairly simple implementation. 

Not being able to use C++'s STL made the management of data a bit harder, but it wasn't that bad overall to just allocate it and free it myself. Considerations did have to be taken, though, that arrays are locked to a fixed size once `calloc`'d.

## Other notes: 

If a game will take more rounds than an integer can fit, then the number will overflow. This won't cause the program to crash -- `int`s will wrap -- but this could be resolved by using a `BigInteger` class in Boost, or storing data in `long long`s. 
[or just not playing a card game with a 20,000 card deck]

## In conclusion: 

Thanks so much for your consideration for this role! I hope to be able to interview in person -- it's been a dream of mine to work at Apple for the longest time and I'm really, truly, grateful to finally have the opportunity! 

Corey Schulz