namespace PVA_Projekt
{
    public class Player
    {
        public string nickname;
        public string name;

        public Player(nickname, name)
        {
            this.nickname = nickname;
            this.name = name;
        }
    }

    public class Players
    {
        private List<Players> Players = new List<Players>();
        public void AddPlayer(string name, string nickname)
        {
            foreach (i in Players )
            {
                
            }
            Players.Add(name, nickname);
            
        }
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
        public Tournament(string name, string name2, int roundCount,List<Round> rounds,List<Player> players)
        {
            this.name = name;
            this.name2 = name2;
            this.roundCount = roundCount2;
            this.rounds = rounds;
            this.players = players;
        }

    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            


        }
    }
}
