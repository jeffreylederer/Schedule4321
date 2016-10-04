using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Schedule4321
{
    class Program
    {
        static void Main(string[] args)
        {
            Random getrandom = new Random();

            //for (int player = 0; player < 15; player++)
            //{
            //    Console.Out.Write("{0:0}\t", player+1);
            //}
            Console.Out.Write("\n");
            for (int numOfPlayers=9; numOfPlayers<16; numOfPlayers++)
            {

                var games = new List<Game>();
                int numOfRinks = numOfPlayers / 3;
 
                // game 1
                var game = new Game(0);
                var players = new int[numOfPlayers];
                Game.DistributePlayers(players);
                game.AssignPlayers(players);
                games.Add(game);

                if (Validations.CheckGame(games, 1, players))
                {
                    Output.PrintGames(games);
                    Output.PrintRinks(numOfPlayers, games);
                }
                else
                {
                    Console.Out.WriteLine("No solution for tournameent with {0:0} players", numOfPlayers);

                }
                //Console.In.ReadLine();
            }
            Console.In.ReadLine();
        }
        
    }
}
