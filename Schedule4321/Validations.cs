using System.Collections.Generic;
using System.Linq;


namespace Schedule4321
{
    public static class Validations
    {
        


        /// <summary>
        /// Check to make sure player is only in a four person game once
        /// </summary>
        /// <param name="rinks">An array of rink objects, each object is a rink number and an array of players</param>
        /// <returns>return true if one or zero rinks have two players</returns>
        public static bool CheckTwos(Rink[] rinks)
        {
            int numofFours = 0;
            foreach (var rink in rinks)
            {
                //limit number of four games
                if (rink.Players.Length == 2)
                {
                    if (numofFours > 0)
                        return false;
                    numofFours++;
                }
            }
            return true;
        }

        /// <summary>
        /// Make sure player on plays on same rink once
        /// </summary>
        /// <param name="rinks">An array of rink objects, each object is a rink number and an array of players</param>
        /// <returns>reuturns false if on rinks is repeated</returns>
        public static bool CheckSameRink(Rink[] rinks)
        {
            var listOfRinks = new List<int>();
            foreach(var rink in rinks)
            {
                if (listOfRinks.Contains(rink.RinkNumber))
                    return true;
                listOfRinks.Add(rink.RinkNumber);
            }
            return false;
        }

        /// <summary>
        /// Check to make sure a player only see another opponent no more than once
        /// </summary>
        /// <param name="player">the player index number</param>
        /// <param name="rinks">>An array of rink objects, each object is a rink number and an array of players</param>
        /// <returns>returns true if no opponent is only seen zero or one time</returns>
        private static bool CheckSameOpponent(int player, Rink[] rinks)
        {

            //test one, you only play against each player once

            var opponents = new List<int>();

            foreach(var rink in rinks)
            {
                foreach (var opponent in rink.Players)
                {
                    if (opponent != player)
                    {
                        if (opponents.Contains(opponent))
                            return false;
                        opponents.Add(opponent);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Check to make all players only see another opponent no more than once
        /// </summary>
        /// <param name="numOfPlayers">Number of players in the tournament</param>
        /// <param name="games">A list of game objects</param>
        /// <returns>returns true if no opponent is only seen zero or one time for each player</returns>
        private static bool CheckSameOpponent(List<Game> games, int numOfPlayers)
        {

            for (int player = 0; player < numOfPlayers; player++)
            {
                var rinks = Rink.FindRinks(games, player);
                if ((numOfPlayers%3) != 0 && !CheckTwos(rinks))
                    return false;
                if (!CheckSameOpponent(player, rinks))
                    return false;
            }
            return true;
        }

        public static bool CheckGame(List<Game> games, int gameNumber, int[] original)
        {
            var perm = new Permutation();
            var listPlayers2 = perm.GetPermutations(original);

            foreach (var players in listPlayers2)
            {
                var game = games.Find(x => x.GameNumber == gameNumber);
                if(game != null)
                    games.Remove(game);
                game = new Game(gameNumber);
                game.AssignPlayers(players);
                games.Add(game);
                if (Validations.CheckSameOpponent(games, original.Count()))
                {
                    if (gameNumber == 2)
                        return true;
                    if (CheckGame(games, gameNumber + 1, original))
                        return true;
                }

            }
            return false;
        }
    }
}