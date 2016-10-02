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
    }
}
