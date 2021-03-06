﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Schedule4321
{
    public class Tournament
    {
        private int NumberOfPlayers { get; set; }
        private List<Game> Games { get; set; }

        private readonly IEnumerable<int[]> _listofPlayerLists;
        private readonly IEnumerable<int[]> _listofPlayerLists1;

        /// <summary>
        /// Constructor for class
        /// </summary>
        /// <param name="numOfPlayers"></param>
        public Tournament(int numOfPlayers)
        {
            NumberOfPlayers = numOfPlayers;

            // get all permutations of player order
            _listofPlayerLists = Permutation.GetPermutations(numOfPlayers,1);
            _listofPlayerLists1 = Permutation.GetPermutations(numOfPlayers, 2);

            // create game 1
            Games = new List<Game>();
            var game = new Game(0);
            var players = new int[numOfPlayers];
            for (var i = 0; i < players.Length; i++)
            {
                players[i] = i;
            }
            game.AssignPlayers(players);
            Games.Add(game);
        }



        /// <summary>
        /// Test to make sure all players only see another opponent no more than once in a tournament
        /// </summary>
        /// <returns>true if game meets test and false if not</returns>
        private bool CheckSameOpponent( )
        {
            var tasks = new List<Task<bool>>();
            for (var player = 0; player < NumberOfPlayers; player++)
            {
                var player1 = player;
                tasks.Add(Validations.CheckSameOpponent(player1, Games));
            }
            Task.WaitAll(tasks.ToArray());
            foreach(var task in tasks)
            {
                if (!task.Result)
                    return false;

            }

            return true;
        }

        /// <summary>
        /// Check to make sure games in tournament meet test such as each opponent plays each no more than once
        /// and on tournaments with number of players not divisible by three, each player is in four persons game no more than once.
        /// </summary>
        /// <returns>true if game meets test and false if not</returns>
        public bool ValidTournament()
        {
            foreach (var playersList in Games.Count==1?_listofPlayerLists : _listofPlayerLists1)
            {
                // create a game from list of players
                var game = new Game(Games.Count);
                game.AssignPlayers(playersList);
                Games.Add(game);

                // check to make sure a valid tournament
                if (CheckSameOpponent())
                {
                    if (Games.Count == 3)
                        return true;
                    if (ValidTournament())
                        return true;
                }
                Games.Remove(game);
            }
            return false;
        }

        
        /// <summary>
        /// prints out a list of rinks for each player sorted by games; one line for each number of players in a tournament.
        /// </summary>
        public void PrintRinks()
        {
            for (var player = 0; player < NumberOfPlayers; player++)
                Console.Out.Write("{0:0}\t", player+1);
            Console.Out.WriteLine();
            for (var player = 0; player < NumberOfPlayers; player++)
            {
                foreach (var game in Games)
                {
                    var a = game.Rinks.Find(x => x.Players.Any(y => y == player)).RinkNumber + 1;
                    Console.Out.Write(a);
                    if (game.GameNumber < 2)
                        Console.Out.Write("-");
                }
                Console.Out.Write("\t");
            }
            Console.Out.WriteLine();
            Console.Out.WriteLine();
        }

        /// <summary>
        /// prints out list of players on each rink, listed by number of players in tournament
        /// </summary>
        public  void PrintGames()
        {
            Console.Out.WriteLine("Game with {0:0} players", NumberOfPlayers);
            foreach (var game in Games)
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
