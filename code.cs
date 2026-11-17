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
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Players seznam = new Players();
            List<Game> odehraneZapasy = new List<Game>(); 
            bool bezi = true;

         
            while (bezi)
            {
                Console.WriteLine();
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1 - Přidat hráče");
                Console.WriteLine("2 - Vypsat hráče");
                Console.WriteLine("3 - Odebrat hráče");
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