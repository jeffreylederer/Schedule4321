using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedule4321.DAL;
using System.IO;
using System.Security.Cryptography;

namespace Schedule4321
{
    class Program
    {
        static void Main(string[] args)
        {
            Random getrandom = new Random();

            //for (int player = 0; player < 15; player++)
            //{
            //    Console.Out.Write("{0:0}\t", player+1);
            //}
            Console.Out.Write("\n");
            for (int numOfPlayers=9; numOfPlayers<16; numOfPlayers++)
            {
               
                List<List<Rink>> games = null;
                int rinks = numOfPlayers / 3;
                do
                {
                    games = new List<List<Rink>>();
                    
                    for (int game = 0; game < 3; game++)
                    {
                        int[] players = new int[numOfPlayers];
                        for (int i = 0; i < numOfPlayers; i++)
                        {
                            players[i] = -1;
                        }

                        
                        for (int i = 0; i < numOfPlayers; i++)
                        {
                            int c = -1;
                            do
                            {
                                c = getrandom.Next(0, numOfPlayers);

                            } while (players.Contains(c));
                            players[i] = c;

                        }
                        int player = 0;
                        var list = new List<Rink>();
                        switch (numOfPlayers%3)
                        {
                            // games with three player
                                
                            case 0:
                                for (int r = 0; r < rinks; r++)
                                {
                                    list.Add(new Rink(r, players[player++], players[player++], players[player++]));
                                }
                                break;
                            // one game with four players
                            case 1:
                                for (int r = 0; r < rinks - 1; r++)
                                {
                                    list.Add(new Rink(r, players[player++], players[player++], players[player++]));
                                }
                                list.Add(new Rink(rinks - 1, players[player++], players[player++], players[player++], players[player++]));
                                   
                                break;
                            // two games with four players
                            case 2:
                                for (int r = 0; r < rinks - 2; r++)
                                {
                                    list.Add(new Rink(r, players[player++], players[player++], players[player++]));
                                }
                                list.Add(new Rink(rinks - 2, players[player++], players[player++], players[player++], players[player++]));
                                list.Add(new Rink(rinks - 1, players[player++], players[player++], players[player++], players[player++]));
                                break;
                        }
                        games.Add(list);
                    }
                    

                } while (TestList(games, numOfPlayers));

                for (var game = 0; game < 3; game++)
                {

                    var rks = games[game];
                    foreach(var rink in rks)
                    {
                        
                        for (var player = 0; player < rink.Players.Length; player++)
                        {
                            Console.Out.Write(rink.Players[player]+1);
                            if(player < rink.Players.Length-1)
                                Console.Out.Write("-");
                        }
                        Console.Out.Write("\t");
                    }
                    Console.Out.Write("\n");
                }
                Console.Out.Write("\n");


                for (int player = 0; player < numOfPlayers; player++)
                {

                    for (int game = 0; game < 3; game++)
                    {
                        var list = games[game];
                        var a = list.Find(x => x.Players.Any(y => y == player)).RinkNumber + 1;
                        Console.Out.Write(a);
                        if (game < 2)
                            Console.Out.Write("-");

                    }
                    Console.Out.Write("\t");
                }
                Console.Out.Write("\n");
                Console.In.ReadLine();
            }
            Console.In.ReadLine();
        }

        static bool TestList(List<List<Rink>> games, int numOfPlayers)
        {

            //test one, you only play against each player once
            for (int player = 0; player < numOfPlayers; player++)
            {
                var rinks = new Rink[3];
                for (var game = 0; game < 3; game++)
                {
                    var list = games[game];
                    rinks[game] = list.Find(x => x.Players.Any(y => y == player));
                }
                var players = new List<int>();
                //int numofFours = 0;
                for (var game = 0; game < 3; game++)
                {
                    // this is the rink played on by player for each game
                    var rink = rinks[game];

                    // limit number of four games
                    //if (rink.Players.Length == 4)
                    //{
                    //    if (numofFours > 0)
                    //        return true;
                    //    numofFours++;
                    //}
                    foreach (var t in rink.Players)
                    {
                        if (t != player)
                        {
                            if (players.Contains(t))
                                return true;
                            players.Add(t);
                        }
                    }
                }
            }
            return false;
        }

    }
}
