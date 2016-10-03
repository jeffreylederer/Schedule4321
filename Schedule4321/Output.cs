using System;
using System.Collections.Generic;
using System.Linq;


namespace Schedule4321
{
    public static class Output
    {
        /// <summary>
        /// prints out a list of rinks for each player sorted by games; one line for each number of players in a tournament.
        /// </summary>
        /// <param name="numOfPlayers"></param>
        /// <param name="games">a list of games which contains a list of rink objects</param>
        public static void PrintRinks(int numOfPlayers, List<Game> games)
        {

            for (int player = 0; player < numOfPlayers; player++)
            {
                foreach(var game in games)
                {
                    var a = game.Rinks.Find(x => x.Players.Any(y => y == player)).RinkNumber + 1;
                    Console.Out.Write(a);
                    if (game.GameNumber < 2)
                        Console.Out.Write("-");
                }
                Console.Out.Write("\t");
            }
            Console.Out.Write("\n");
        }

        /// <summary>
        /// prints out list of players on each rink, listed by number of players in tournament
        /// </summary>
        /// <param name="games">a list of games which contains a list of rink objects</param>
        public static void PrintGames(List<Game> games)
        {
            foreach (var game in games)
            {
                var rks = game.Rinks;
                foreach (var rink in rks)
                {
                    for (var player = 0; player < rink.Players.Length; player++)
                    {
                        Console.Out.Write(rink.Players[player] + 1);
                        if (player < rink.Players.Length - 1)
                            Console.Out.Write("-");
                    }
                    Console.Out.Write("\t");
                }
                Console.Out.Write("\n");
            }
            Console.Out.Write("\n");
        }
    }
}
