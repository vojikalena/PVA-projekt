namespace PVA_Projekt
{
    public class Player
    {
        public string nickname;
        public string name;
    }

    public class Game
    {
        public Player player1;
        public Player player2;
        public int result;
        public Game(Player player1, Player player2, int result)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.result = result;
        }

    }

    public class Round
    {
        public int number;
        public Game[] games;
        public bool opened;
        public Round(int number, Game[] games, bool opened)
        {
            this.number = number;
            this.games = games;
            this.opened = opened;
        }

    }
    public class Tournament
    {
        public string name;
        public string name2;
        public int roundCount;
        public List<Round> rounds;
        public List<Player> players;


    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            


        }
    }
}
