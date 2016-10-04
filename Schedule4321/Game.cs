﻿using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.Core.Metadata.Edm;


namespace Schedule4321
{
    public class Game
    {
        public int GameNumber { get; set; }
        public List<Rink> Rinks { get; set; }

        public Game(int gameNumber)
        {
            GameNumber = gameNumber;
            Rinks = new List<Rink>();
        }

        public void Add(Rink rink)
        {
            Rinks.Add(rink);
        }

        public void AssignPlayers(int[] players)
        {
            
            int player = 0;
            int r;
            switch (players.Count() % 3)
            {
                // games with three player

                case 0:
                    for (r = 0; r < players.Count()/3; r++)
                    {
                        Add(new Rink(r, players[player++], players[player++], players[player++]));
                    }
                    break;
                // two games with two players
                case 1:
                    for (r = 0; r < players.Count()/3 - 1; r++)
                    {
                        Add(new Rink(r, players[player++], players[player++], players[player++]));
                    }
                    Add(new Rink(r++, players[player++], players[player++]));
                    Add(new Rink(r, players[player++], players[player++]));

                    break;
                // one game with two players
                case 2:
                    for (r = 0; r < players.Count()/3; r++)
                    {
                        Add(new Rink(r, players[player++], players[player++], players[player++]));
                    }
                    Add(new Rink(r, players[player++], players[player++]));
                    break;
            }

        }

        public static void DistributePlayers( int[] players)
        {
            for(var i=0;i<players.Length; i++)
            {
                players[i] = i;
            }
        }

       
    }
}