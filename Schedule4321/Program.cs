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
               
                var tournament = new Tournament(numOfPlayers);

                var games = new List<Game>();
                int numOfRinks = numOfPlayers / 3;
 
                // game 1
                var game = new Game(0);
                var players = new int[numOfPlayers];
                for (var i = 0; i < players.Length; i++)
                {
                    players[i] = i;
                }
                game.AssignPlayers(players);
                tournament.Add(game);

                if (tournament.CheckGame())
                {
                    tournament.PrintGames();
                    tournament.PrintRinks();
                }
                else
                {
                    Console.Out.WriteLine("No solution for tournament with {0:0} players", numOfPlayers);

                }
                //Console.In.ReadLine();
            }
            Console.In.ReadLine();
        }
        
    }
}
