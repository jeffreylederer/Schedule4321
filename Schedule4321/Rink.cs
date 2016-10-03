using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule4321
{
    public class Rink
    {
        public int RinkNumber { get; set; }
        public int[] Players { get; set; }

        public Rink(int rink, params int[] args)
        {
            RinkNumber = rink;
            Players = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                Players[i] = args[i];
            }
        }

        /// <summary>
        /// Find rinks where a player is playing each game
        /// </summary>
        /// <param name="games">a list of games which contains a list of rink objects</param>
        /// <param name="player">index number of player</param>
        /// <returns>an array of rinks (one for each game) where the player is playing</returns>
        public static Rink[] FindRinks(List<Game> games, int player)
        {
            var rinks = new Rink[games.Count];
            foreach(var game in games)
            {
                rinks[game.GameNumber] = game.Rinks.Find(x => x.Players.Any(y => y == player));
            }
            return rinks;
        }
    }
}
