namespace PVA_Projekt
{
    public class Player
    {
        public string nickname;
        public string name;
    }
     public class Players
    {
        
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
        Tournament Create(){
            Console.Write.Line("Jméno: ");
            string name = ConsoleInput.Input();
            Console.Write.Line("Disciplína: ");
            string name2 = ConsoleInput.Input();
            Console.Write.Line("Počet kol: ");
            int roundCount = ConsoleInput.InputInt();

            Tournament tournament = new(name, name2, roundCount, [],[]);
            return tournament;
        }
    }
    public class ConsoleInput{
        string Input()
        {
            return Console.ReadLine();
        }
        int InputInt()
        {
            while (true)
            {
                string input = Console.WriteLine();
                if(int.TryParse(input, out int input2))
                {
                    return input2;

                }
                else
                {
                    System.Console.WriteLine(":Neplatný vstup");
                    continue;
                }
            }
            
        }

    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            


        }
    }
}
