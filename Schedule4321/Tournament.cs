using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule4321
{
    public class Tournament
    {
        private int NumberOfPlayers { get; set; }
        private List<Game> Games { get; set; }

        private readonly IEnumerable<int[]> _listofPlayerLists;

        /// <summary>
        /// Constructor for class
        /// </summary>
        /// <param name="numOfPlayers"></param>
        public Tournament(int numOfPlayers)
        {
            NumberOfPlayers = numOfPlayers;

            // get all permutations of player order
            var perm = new Permutation();
            _listofPlayerLists = perm.GetPermutations(numOfPlayers);

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
        private bool CheckSameOpponent()
        {

            for (var player = 0; player < NumberOfPlayers; player++)
            {
                var rinks = FindRinks(player);
                if ((NumberOfPlayers % 3) != 0 && !Validations.CheckTwos(rinks))
                    return false;
                if (!Validations.CheckSameOpponent(player, rinks))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check to make sure games in tournament meet test such as each opponent plays each no more than once
        /// and on tournaments with number of players not divisible by three, each player is in two persons game no more than once.
        /// </summary>
        /// <returns>true if game meets test and false if not</returns>
        public bool ValidTournament()
        {
            foreach (var playersList in _listofPlayerLists)
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
        /// Find rinks where a player is playing each game in tournament
        /// </summary>
        /// <param name="player">index number of player</param>
        /// <returns>an array of rinks (one for each game) where the player is playing</returns>
        public Rink[] FindRinks(int player)
        {
            var rinks = new Rink[Games.Count];
            foreach (var game in Games)
            {
                rinks[game.GameNumber] = game.Rinks.Find(x => x.Players.Any(y => y == player));
            }
            return rinks;
        }

        /// <summary>
        /// prints out a list of rinks for each player sorted by games; one line for each number of players in a tournament.
        /// </summary>
        public void PrintRinks()
        {

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
            Console.Out.Write("\n");
        }

        /// <summary>
        /// prints out list of players on each rink, listed by number of players in tournament
        /// </summary>
        public  void PrintGames()
        {
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
