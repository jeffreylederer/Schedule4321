﻿using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.Core.Metadata.Edm;


namespace Schedule4321
{
    /// <summary>
    /// This class represents a game in a tournament played on multiple rinks simultaneously
    /// </summary>
    public class Game : IEquatable<Game> 

    {
        public int GameNumber { get; set; }
        public List<Rink> Rinks { get; set; }


        /// <summary>
        /// Constructor for Game object
        /// </summary>
        /// <param name="gameNumber">Game number in tournament</param>
        public Game(int gameNumber)
        {
            GameNumber = gameNumber;
            Rinks = new List<Rink>();
        }

        /// <summary>
        /// Add a rink to game
        /// </summary>
        /// <param name="rink">a Rink object</param>
        public void Add(Rink rink)
        {
            Rinks.Add(rink);
        }

        /// <summary>
        /// Assign an array of players to rinks
        /// </summary>
        /// <param name="players">an array of player indices</param>
        public void AssignPlayers(int[] players)
        {

            var player = 0;
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
                // one game with four players
                case 1:
                    for (r = 0; r < players.Count()/3 - 1; r++)
                    {
                        Add(new Rink(r, players[player++], players[player++], players[player++]));
                    }
                    Add(new Rink(r++, players[player++], players[player++], players[player++], players[player++]));
                    break;
                // two games with four players
                case 2:
                    for (r = 0; r < players.Count()/3-2; r++)
                    {
                        Add(new Rink(r, players[player++], players[player++], players[player++]));
                    }
                    Add(new Rink(r++, players[player++], players[player++], players[player++], players[player++]));
                    Add(new Rink(r, players[player++], players[player++], players[player++], players[player++]));
                    break;
            }

        }

        /// <summary>
        /// Checks to see if another game is the same as this one
        /// </summary>
        /// <param name="game">another game</param>
        /// <returns>true if same object</returns>
        public bool Equals(Game game)
        {
            return game.GameNumber == GameNumber;
        }


    }
}
