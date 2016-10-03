using System.Collections.Generic;


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
    }
}
