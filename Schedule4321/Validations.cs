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
        /// <returns>return false if one or zero rinks have four players</returns>
        public static bool MultipleFours(Rink[] rinks)
        {
            int numofFours = 0;
            foreach (var rink in rinks)
            {
                //limit number of four games
                if (rink.Players.Length == 4)
                {
                    if (numofFours > 0)
                        return true;
                    numofFours++;
                }
            }
            return false;
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
        /// <param name="numOfPlayers">Number of players in the tournament</param>
        /// <param name="player">the player index number</param>
        /// <param name="rinks">>An array of rink objects, each object is a rink number and an array of players</param>
        /// <returns>returns false if no opponent is only seen zero or one time</returns>
        public static bool CheckSameOpponent(int numOfPlayers, int player, Rink[] rinks)
        {

            //test one, you only play against each player once

            var players = new List<int>();

            foreach(var rink in rinks)
            {
                foreach (var t in rink.Players)
                {
                    if (t != player && t != -1)
                    {
                        if (players.Contains(t))
                            return true;
                        players.Add(t);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Check to make all players only see another opponent no more than once
        /// </summary>
        /// <param name="numOfPlayers">Number of players in the tournament</param>
        /// <param name="games">A list of game objects</param>
        /// <returns>returns false if no opponent is only seen zero or one time for each player</returns>
        public static bool CheckSameOpponent(List<Game> games, int numOfPlayers)
        {

            for (int i = 0; i < numOfPlayers; i++)
            {
                var rinks = Rink.FindRinks(games, i);
                if (CheckSameOpponent(numOfPlayers, i, rinks))
                    return true;
            }
            return false;
        }
    }
}