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
        public Tournament(string name, string name2, int roundCount, List<Round> rounds, List<Player> players)
        {
            this.name = name;
            this.name2 = name2;
            this.roundCount = roundCount;
            this.rounds = rounds;
            this.players = players;
        }
        public static Tournament Create()
        {
            ConsoleOutput.Write("Jméno: ");
            string name = ConsoleInput.Input();
            ConsoleOutput.Write("Disciplína: ");
            string name2 = ConsoleInput.Input();
            ConsoleOutput.Write("Počet kol: ");
            int roundCount = ConsoleInput.InputInt();

            Tournament tournament = new(name, name2, roundCount, [], []);
            return tournament;
        }
        public void AddPlayer()
        {
            ConsoleOutput.Write("Přezdívka: ");
            string name = ConsoleInput.Input();
            Player player = new();
            this.players.Add(player);
        }
        public void RemovePlayer()
        {

        }
        public void NewRound()
        {
            try
            {
                if (rounds.Count < roundCount && rounds.Last().opened == false)
                {

                    rounds.Add(new(rounds.Count + 1, [], true));
                }
                else
                {
                    ConsoleOutput.Write("Nelze vytvořit další kolo.");
                }
            }
            catch(Exception e)
            {
                rounds.Add(new(rounds.Count + 1, [], true));
            }

            for (int i = 0; i < (players.Count() + 1)/2 ; i++)
            {
                rounds.Last().games.Append(new(new(), new(),0));
            }
            while (true)
            {
                int gameIndex;
                Game game = new(new(),new(),0);
                ConsoleOutput.List(rounds.Last().games);
                int input = ConsoleInput.InputInt();
                if (input > 0 && input <= rounds.Last().games.Count())
                {
                    gameIndex = input - 1;
                }
                else { continue; }
                ConsoleOutput.List(players);
                int input2 = ConsoleInput.InputInt();
                if (input2 > 0 && input2 <= players.Count())
                {
                    game.player1 = players[input2 - 1];
                }
                else { continue; }
                int input3 = ConsoleInput.InputInt();
                if (input3 > 0 && input3 <= players.Count())
                {
                    game.player2 = players[input3 - 1];
                }
                else { continue; }
                rounds.Last().games[gameIndex] = game;
            }
            
        }
    }
    public class ConsoleInput
    {
        public static string Input()
        {
            return Console.ReadLine();
        }
        public static int InputInt()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int input2))
                {
                    return input2;

                }
                else
                {
                    ConsoleOutput.Write("Neplatný vstup");
                    continue;
                }
            }
        }
    }
    public class ConsoleOutput
    {
        public static void Write(string text)
        {
            Console.WriteLine(text);
        }
        public static void List(Game[] games)
        {
            int i = 1;
            foreach (Game g in games)
            {
                Console.WriteLine($"{i}. {g.player1.name} {g.result} {g.player2.name}");
                i++;
            }
        }
        public static void List(List<Player> players)
        {
            int i = 1;
            foreach (Player p in players)
            {
                Console.WriteLine($"{i}. {p.name} ({p.nickname})");
                i++;
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Tournament test = Tournament.Create();
            //test.NewRound();
            //Console.WriteLine(rounds.Last().games.Count());

        }
    }
}
