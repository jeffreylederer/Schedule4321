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

                var games = new List<Game>();
                int numOfRinks = numOfPlayers / 3;
               


                int gameNumber = 0;
                #region first game
                { 
                    int player = 0;
                    var game = new Game(0);
                    switch (numOfPlayers%3)
                    {
                        // games with three player

                        case 0:
                            for (int r = 0; r < numOfRinks; r++)
                            {
                                game.Add(new Rink(r, player++, player++, player++));
                            }
                            break;
                        // one game with four players
                        case 1:
                            for (int r = 0; r < numOfRinks - 1; r++)
                            {
                                game.Add(new Rink(r, player++, player++, player++));
                            }
                            game.Add(new Rink(numOfRinks - 1, player++, player++, player++,
                                player++));

                            break;
                        // two games with four players
                        case 2:
                            for (int r = 0; r < numOfRinks - 2; r++)
                            {
                                game.Add(new Rink(r, player++, player++, player++));
                            }
                            game.Add(new Rink(numOfRinks - 2, player++, player++, player++,
                                player++));
                            game.Add(new Rink(numOfRinks - 1, player++, player++, player++,
                                player++));
                            break;
                    }
                    games.Add(game);
                }
                #endregion

                int counter = 0;
                for (gameNumber = 1; gameNumber < 3; gameNumber++)
                {
                    counter = 0;
                    var rinks = new Rink[gameNumber];
                    do
                    {
                        if (games.Count == gameNumber + 1)
                            games.Remove(games.Find(x=>x.GameNumber==gameNumber));
                        var game = new Game(gameNumber);
                            
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
                        switch (numOfPlayers%3)
                        {
                            // games with three player

                            case 0:
                                for (int r = 0; r < numOfRinks; r++)
                                {
                                    game.Add(new Rink(r, players[player++], players[player++], players[player++]));
                                }
                                break;
                            // one game with four players
                            case 1:
                                for (int r = 0; r < numOfRinks - 1; r++)
                                {
                                    game.Add(new Rink(r, players[player++], players[player++], players[player++]));
                                }
                                game.Add(new Rink(numOfRinks - 1, players[player++], players[player++],
                                    players[player++],
                                    players[player++]));

                                break;
                            // two games with four players
                            case 2:
                                for (int r = 0; r < numOfRinks - 2; r++)
                                {
                                    game.Add(new Rink(r, players[player++], players[player++], players[player++]));
                                }
                                game.Add(new Rink(numOfRinks - 2, players[player++], players[player++],
                                    players[player++],
                                    players[player++]));
                                game.Add(new Rink(numOfRinks - 1, players[player++], players[player++],
                                    players[player++],
                                    players[player++]));
                                break;
                        }
                        games.Add(game);
                        counter++;
                    } while (Validations.CheckSameOpponent(games, numOfPlayers));

                }
                Console.Out.WriteLine(counter);
                Output.PrintGames(games);
                Output.PrintRinks(numOfPlayers, games);
                Console.In.ReadLine();
            }
            Console.In.ReadLine();
        }
    }
}
