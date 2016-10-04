using System.Collections.Generic;
using System.Linq;


namespace Schedule4321
{
    public static class Validations
    {
        /// <summary>
        /// Check to make sure player is only in a two person game no more than once
        /// </summary>
        /// <param name="rinks">An array of rink objects, each object is a rink number and an array of players</param>
        /// <returns>return true if one or zero rinks have two players</returns>
        public static bool CheckTwos(Rink[] rinks)
        {
            var numofFours = 0;
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
        /// Make sure player does plays on same rink more than once
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
        /// Check to make sure a specified player only sees another opponent no more than once in tournament
        /// </summary>
        /// <param name="player">the player index number</param>
        /// <param name="rinks">>An array of rink objects, each object is a rink number and an array of players</param>
        /// <returns>returns true if no opponent is only seen zero or one time</returns>
        public static bool CheckSameOpponent(int player, Rink[] rinks)
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

        
    }
}