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
            for (var numOfPlayers=9; numOfPlayers<16; numOfPlayers++)
            {
                var tournament = new Tournament(numOfPlayers);
                if (tournament.ValidTournament())
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
