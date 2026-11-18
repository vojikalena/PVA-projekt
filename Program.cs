using System;
using System.Collections.Generic;
using System.Linq;

namespace PVA_Projekt
{
    public class Player
    {
        public string nickname;
        public string name;

        public Player(string nickname, string name)
        {
            this.nickname = nickname;
            this.name = name;
        }
    }
    public class Players
    {
        private List<Player> players = new List<Player>();


        public bool AddPlayer(string name, string nickname)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(nickname))
            {
                Console.WriteLine("Jméno ani přezdívka nesmí být prázdné.");
                return false;
            }

            foreach (Player p in players)
            {
                if (p.nickname.Equals(nickname, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Přezdívka '{nickname}' už existuje, hráč nebyl přidán.");
                    return false;
                }
            }

            players.Add(new Player(nickname, name));
            Console.WriteLine($"Hráč {name} ({nickname}) byl přidán.");
            return true;
        }

        public void PrintPlayers()
        {
            if (players.Count == 0)
            {
                Console.WriteLine("Seznam hráčů je prázdný.");
                return;
            }

            Console.WriteLine("Seznam hráčů:");
            foreach (Player p in players)
            {
                Console.WriteLine($"- {p.name} (přezdívka: {p.nickname})");
            }
        }


        public bool RemovePlayer(string nickname, List<Game> playedGames)
        {
            Player found = null;
            foreach (Player p in players)
            {
                if (p.nickname.Equals(nickname, StringComparison.OrdinalIgnoreCase))
                {
                    found = p;
                    break;
                }
            }

            if (found == null)
            {
                Console.WriteLine($"Hráč s přezdívkou '{nickname}' neexistuje.");
                return false;
            }

            foreach (Game g in playedGames)
            {
                if (g.player1 == found || g.player2 == found)
                {
                    Console.WriteLine($"Hráče '{nickname}' nelze odebrat, protože už odehrál zápas.");
                    return false;
                }
            }

            players.Remove(found);
            Console.WriteLine($"Hráč '{nickname}' byl odebrán.");
            return true;
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
        public List<Game> games;
        public bool opened;
        public Round(int number, List<Game> games, bool opened)
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
        public int[] points;
        public Tournament(string name, string name2, int roundCount, List<Round> rounds, List<Player> players, int[] points)
        {
            this.name = name;
            this.name2 = name2;
            this.roundCount = roundCount;
            this.rounds = rounds;
            this.players = players;
            this.points = points;
        }
        public static Tournament Create()
        {
            ConsoleOutput.Write("Jméno: ");
            string name = ConsoleInput.Input();
            ConsoleOutput.Write("Disciplína: ");
            string name2 = ConsoleInput.Input();
            ConsoleOutput.Write("Počet kol: ");
            int roundCount = ConsoleInput.InputInt();
            ConsoleOutput.Write("Body za výhru: ");
            int winPoints = ConsoleInput.InputInt();
            ConsoleOutput.Write("Body za remízu: ");
            int drawPoints = ConsoleInput.InputInt();
            ConsoleOutput.Write("Body za volný los: ");
            int points = ConsoleInput.InputInt();
            Tournament tournament = new(name, name2, roundCount, [], [new("test", "Test"), new("test2", "Test2")], [winPoints, drawPoints, points]);
            return tournament;
        }
        public void AddPlayer()
        {
            ConsoleOutput.Write("Přezdívka: ");
            string name = ConsoleInput.Input();
            Player player = new("","");
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
            catch (Exception e)
            {
                rounds.Add(new(rounds.Count + 1, [], true));
            }

            for (int i = 0; i < (players.Count + 1) / 2; i++)
            {
                Player p1 = players[i * 2];
                Player p2 = players[i * 2 + 1];
                //rounds.Last().games.Add(new(new("",""), new("",""),0));
                rounds.Last().games.Add(new(new(p1.nickname, p1.name), new(p2.nickname, p2.name), 0));
            }
            List<bool> playersRound = [];
            foreach (Player p in players)
            {
                playersRound.Add(false);
            }
            while (true)
            {
                int gameIndex;
                Game game = new(new("", ""), new("", ""), 0);

                ConsoleOutput.List(rounds.Last().games, points);
                int input = ConsoleInput.InputInt();

                if (input == 0) { break; }
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
                if (input3 == 0)
                {
                    game.player2 = new("", "");
                }
                else if (input3 > 0 && input3 <= players.Count())
                {
                    game.player2 = players[input3 - 1];
                }
                else { continue; }
                if (game.player1.nickname == game.player2.nickname) { continue; }
                if (playersRound[input2 - 1] == false)
                {
                    playersRound[input2 - 1] = true;
                }
                else { continue; }
                if (playersRound[input3 - 1] == false)
                {
                    playersRound[input3 - 1] = true;
                }
                else { continue; }
                rounds.Last().games[gameIndex] = game;
            }
            int j = 0;
            foreach (bool item in playersRound)
            {
                if (item == false)
                {
                    rounds.Last().games.Add(new(players[j], new("Volný los", "Volný los"), 4));
                }
                j++;

            }
            ConsoleOutput.Write($"{rounds.Last().number}. kolo - Zápasy:");
            ConsoleOutput.List(rounds.Last().games, points);
        }
        public void SetResult()
        {
            while (true)
            {
                ConsoleOutput.Write("Vyber zápas: ");
                ConsoleOutput.List(rounds.Last().games, points);
                int input = ConsoleInput.InputInt();
                if (input == 0) { break; }
                if (input <= 0 || input > rounds.Last().games.Count)
                {
                    continue;
                }
                Game game = rounds.Last().games[input - 1];
                if (game.result == 4 || !players.Any(player => player.nickname == game.player2.nickname))
                {
                    ConsoleOutput.Write("Volný los nelze upravit jako běžný zápas.");
                    continue;
                }
                ConsoleOutput.Clear();
                ConsoleOutput.Write($"{input}. {rounds.Last().games[input - 1].player1.name} - {rounds.Last().games[input - 1].player2.name}");
                ConsoleOutput.Write($"Výsledek: {ConsoleOutput.ResultToString(rounds.Last().games[input - 1].result, points)}");
                ConsoleOutput.Write($"1 - Vyhrál bílý ({points[0]}:0)");
                ConsoleOutput.Write($"2 - Vyhrál černý (0:{points[0]})");
                ConsoleOutput.Write($"3 - Remíza ({points[1]}:{points[1]})");
                int input2 = ConsoleInput.InputInt();
                if (input2 <= 0 || input2 > 3)
                {
                    continue;
                }
                rounds.Last().games[input - 1].result = input2;
            }

        }
        public void CloseRound()
        {
            while (true)
            {
                foreach (Game g in rounds.Last().games)
                {
                    if (g.result == 0)
                    {
                        ConsoleOutput.Write("Chybí výsledky zápasů");
                        break;
                    }
                }
                rounds.Last().opened = false;
                ConsoleOutput.Write("Kolo úspěšně uzavřeno");

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
        public static void List(List<Game> games, int[] points)
        {
            int i = 1;
            foreach (Game g in games)
            {
                Console.WriteLine($"{i}. {g.player1.name} {ResultToString(g.result, points)} {g.player2.name}");
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
        public static void Clear()
        {
            Console.Clear();
        }
        public static string ResultToString(int result, int[] points)
        {
            if (result == 0)
            {
                return "0:0";
            }
            else if (result == 1)
            {
                // return "3:0";
                return $"{points[0]}:0";
            }
            else if (result == 2)
            {
                // return "0:3";
                return $"0:{points[0]}";
            }
            else if (result == 3)
            {
                //return "1:1";
                return $"{points[1]}:{points[1]}";
            }
            else if (result == 4)
            {
                return "1:0";
            }
            else { return "?"; }
        }
    }
    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            string saveFile = "tournament.trn";
            Tournament tournament;

            ConsoleOutput.Write("Načíst uložený turnaj? (a/n)");
            string answer = ConsoleInput.Input();
            if (answer.Trim().ToLower() == "a")
            {
                try
                {
                    tournament = TournamentStorage.Load(saveFile);
                    ConsoleOutput.Write("Turnaj byl načten.");
                }
                catch (FileNotFoundException)
                {
                    ConsoleOutput.Write($"Soubor {saveFile} nebyl nalezen.");
                    ConsoleOutput.Write("Chcete vytvořit nový turnaj? (a/n)");
                    string newTournamentAnswer = ConsoleInput.Input();
                    if (newTournamentAnswer.Trim().ToLower() == "a")
                    {
                        tournament = Tournament.Create();
                    }
                    else
                    {
                        return;
                    }
                }
                catch (InvalidDataException e)
                {
                    ConsoleOutput.Write($"Soubor nelze načíst: {e.Message}");
                    return;
                }
            }
            else
            {
                tournament = Tournament.Create();
            }

            if (tournament.rounds.Count == 0 || !tournament.rounds.Last().opened)
            {
                tournament.NewRound();
            }
            tournament.SetResult();

            try
            {
                TournamentStorage.Save(tournament, saveFile);
                ConsoleOutput.Write($"Turnaj byl uložen do souboru {saveFile}.");
            }
            catch (IOException e)
            {
                ConsoleOutput.Write($"Turnaj se nepodařilo uložit: {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                ConsoleOutput.Write($"Turnaj se nepodařilo uložit: {e.Message}");
            }

        }
    }*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Players seznam = new Players();
            List<Game> odehraneZapasy = new List<Game>();
            bool bezi = true;
            Tournament tournament = new("", "", 0, [], [], []);
            string saveFile = "tournament.trn";
            while (bezi)
            {
                Console.WriteLine();
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1 - Přidat hráče");
                Console.WriteLine("2 - Vypsat hráče");
                Console.WriteLine("3 - Odebrat hráče");
                Console.WriteLine("4 - Načíst/vytvořit turnaj");
                Console.WriteLine("5 - Uložit turnaj");
                Console.WriteLine("0 - Konec");
                Console.Write("Volba: ");

                string volba = Console.ReadLine();
                
                switch (volba)
                {
                    case "1":
                        Console.Write("Jméno: ");
                        string jmeno = Console.ReadLine();
                        Console.Write("Přezdívka: ");
                        string prezdivka = Console.ReadLine();
                        seznam.AddPlayer(jmeno, prezdivka);
                        break;

                    case "2":
                        seznam.PrintPlayers();
                        break;

                    case "3":
                        Console.Write("Přezdívka hráče k odebrání: ");
                        string odebrat = Console.ReadLine();
                        seznam.RemovePlayer(odebrat, odehraneZapasy);
                        break;

                    case "4":
                        Console.WriteLine("Nacist/vytvorit");
                        //string saveFile = "tournament.trn";
                        //Tournament tournament;

                        ConsoleOutput.Write("Načíst uložený turnaj? (a/n)");
                        string answer = ConsoleInput.Input();
                        if (answer.Trim().ToLower() == "a")
                        {
                            try
                            {
                                tournament = TournamentStorage.Load(saveFile);
                                ConsoleOutput.Write("Turnaj byl načten.");
                            }
                            catch (FileNotFoundException)
                            {
                                ConsoleOutput.Write($"Soubor {saveFile} nebyl nalezen.");
                                ConsoleOutput.Write("Chcete vytvořit nový turnaj? (a/n)");
                                string newTournamentAnswer = ConsoleInput.Input();
                                if (newTournamentAnswer.Trim().ToLower() == "a")
                                {
                                    tournament = Tournament.Create();
                                }
                                else
                                {
                                    return;
                                }
                            }
                            catch (InvalidDataException e)
                            {
                                ConsoleOutput.Write($"Soubor nelze načíst: {e.Message}");
                                return;
                            }
                        }
                        else
                        {
                            tournament = Tournament.Create();
                        }
                        break;

                    case "5":
                        
                        try
                        {
                            TournamentStorage.Save(tournament, saveFile);
                            ConsoleOutput.Write($"Turnaj byl uložen do souboru {saveFile}.");
                        }
                        catch (IOException e)
                        {
                            ConsoleOutput.Write($"Turnaj se nepodařilo uložit: {e.Message}");
                        }
                        catch (InvalidOperationException e)
                        {
                            ConsoleOutput.Write($"Turnaj se nepodařilo uložit: {e.Message}");
                        }
                        break;
                    case "0":
                        bezi = false;
                        Console.WriteLine("Program se ukončuje.");
                        break;

                    default:
                        Console.WriteLine("Neplatná volba, zkus to znovu.");
                        break;
                }
            }
        }
    }
}
