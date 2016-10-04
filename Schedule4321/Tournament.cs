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
            Games = new List<Game>();
            NumberOfPlayers = numOfPlayers;
            var perm = new Permutation();
            _listofPlayerLists = perm.GetPermutations(numOfPlayers);
        }

        public void Add(Game game)
        {
            Games.Add(game);
        }


        /// <summary>
        /// Check to make all players only see another opponent no more than once
        /// </summary>
        /// <returns>returns true if no opponent is only seen zero or one time for each player</returns>
        private  bool CheckSameOpponent()
        {

            for (int player = 0; player < NumberOfPlayers; player++)
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
        /// Test to make sure games in tournament meet test such as each opponent plays each other just once
        /// and on tournaments with number of players not divisible by three, each player in two persons game zero or one time.
        /// </summary>
        /// <returns>true if game meets test and false if not</returns>
        public bool CheckGame()
        {
            foreach (var playersList in _listofPlayerLists)
            {
                var game = new Game(Games.Count);
                game.AssignPlayers(playersList);
                Games.Add(game);
                if (CheckSameOpponent())
                {
                    if (Games.Count == 3)
                        return true;
                    if (CheckGame())
                        return true;
                }
                Games.Remove(game);
            }
            return false;
        }

        /// <summary>
        /// Find rinks where a player is playing each game
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

            for (int player = 0; player < NumberOfPlayers; player++)
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
