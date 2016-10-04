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

        /// <summary>
        /// Constructor for a Rink ojbect
        /// </summary>
        /// <param name="rinkNumber">Rink number in the game</param>
        /// <param name="args">an array of player indices</param>
        public Rink(int rinkNumber, params int[] args)
        {
            RinkNumber = rinkNumber;
            Players = new int[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                Players[i] = args[i];
            }
        }
      
    }
}
