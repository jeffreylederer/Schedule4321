# Schedule4321
Lawn Bowling 4321 Scheduler

This will create a printed schedule for a 4321 Lawn Bowling tournament so the tournament director can create the individual scorecards.

In theory this should work with any tournament with 9 to 30 players. It does not allow any player to play any other player more than once.

When there are the number of players is not evenly divisible by 3, the program creates one or four games with two players.

The only issue is the PROGRAM CANNOT complete. It uses permutations to create different possible player orders. As more players are added to the game, the permuations grow by x!*x!. The only trick I
am doing right now is to first create game one with players ordered from 1 to x. I then try to create game twos running through the permutations until I find a valid two game tournament. I then do the
same trick with game three. If no valid three game tournament is found, I go back to the second step with the next permutation.

I am thinking there must be a trick around the fact that a rink with players 1,2,3 is the same a rink with players 3,2,1 with respect to validity. I just cannot figure out how to take advantage of
this trick.

I am not worried about the final rule which is that players should not play on the same rink more than once in a tournament.
I think that after coming up with valid tournament, I can add extra rinks and move individual rinks around in each game around until I satisfied this extra rule.
