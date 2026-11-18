namespace PVA_Projekt
{
    
    public class TournamentStorage
    {
       
        public static void Save(Tournament tournament, string fileName)
        {
        
            List<string> lines = new()
            {
                "TRN;2",
                $"TURNAJ;{tournament.name};{tournament.name2};{tournament.roundCount}",
                $"BODOVANI;{tournament.points[0]};{tournament.points[1]};{tournament.points[2]}"
            };

            Dictionary<string, int> playerIds = new();
            for (int i = 0; i < tournament.players.Count; i++)
            {
                Player player = tournament.players[i];
                int id = i + 1;
                playerIds.Add(player.nickname, id);
                lines.Add($"HRAC;{id};{player.nickname};{player.name}");
            }

           
            foreach (Round round in tournament.rounds)
            {
                int opened = round.opened ? 1 : 0;
                lines.Add($"KOLO;{round.number};{opened}");

                foreach (Game game in round.games)
                {
                    if (game.result == 4 || !playerIds.ContainsKey(game.player2.nickname))
                    {
                        lines.Add($"ZAPAS;{playerIds[game.player1.nickname]};-;VOLNO");
                    }
                    else
                    {
                        string result = game.result switch
                        {
                            0 => "?",
                            1 => "V1",
                            2 => "V2",
                            3 => "R",
                            _ => throw new InvalidOperationException("Neznámý výsledek zápasu.")
                        };
                        lines.Add($"ZAPAS;{playerIds[game.player1.nickname]};{playerIds[game.player2.nickname]};{result}");
                    }
                }
            }

            File.WriteAllLines(fileName, lines);
        }

       
        public static Tournament Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Soubor turnaje nebyl nalezen.", fileName);
            }

            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length < 3 || lines[0] != "TRN;2")
            {
                throw new InvalidDataException("Soubor nemá správný formát turnaje.");
            }

            string[] tournamentData = lines[1].Split(';');
            string[] scoringData = lines[2].Split(';');
            if (tournamentData.Length != 4 || tournamentData[0] != "TURNAJ" ||
                scoringData.Length != 4 || scoringData[0] != "BODOVANI")
            {
                throw new InvalidDataException("V souboru chybí údaje o turnaji nebo bodování.");
            }

            if (!int.TryParse(tournamentData[3], out int roundCount) ||
                !int.TryParse(scoringData[1], out int winPoints) ||
                !int.TryParse(scoringData[2], out int drawPoints) ||
                !int.TryParse(scoringData[3], out int byePoints))
            {
                throw new InvalidDataException("Počet kol nebo bodování není platné číslo.");
            }

          
            List<Player> players = new();
            Dictionary<int, Player> playerIds = new();
            List<Round> rounds = new();
            Round currentRound = null;

           
            for (int i = 3; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(';');
                if (fields[0] == "HRAC")
                {
                   
                    if (fields.Length != 4 || !int.TryParse(fields[1], out int id))
                    {
                        throw new InvalidDataException($"Neplatný hráč na řádku {i + 1}.");
                    }
                    Player player = new(fields[2], fields[3]);
                    players.Add(player);
                    playerIds.Add(id, player);
                }
                else if (fields[0] == "KOLO")
                {
                    
                    if (fields.Length != 3 || !int.TryParse(fields[1], out int number) ||
                        (fields[2] != "0" && fields[2] != "1"))
                    {
                        throw new InvalidDataException($"Neplatné kolo na řádku {i + 1}.");
                    }
                    currentRound = new Round(number, new List<Game>(), fields[2] == "1");
                    rounds.Add(currentRound);
                }
                else if (fields[0] == "ZAPAS")
                {
                    
                    if (fields.Length != 4 || currentRound == null ||
                        !int.TryParse(fields[1], out int firstId) ||
                        !playerIds.TryGetValue(firstId, out Player firstPlayer))
                    {
                        throw new InvalidDataException($"Neplatný zápas na řádku {i + 1}.");
                    }

                    Player secondPlayer;
                    int result;
                    if (fields[2] == "-" && fields[3] == "VOLNO")
                    {
                        secondPlayer = new Player("Volný los", "Volný los");
                        result = 4;
                    }
                    else if (int.TryParse(fields[2], out int secondId) &&
                        playerIds.TryGetValue(secondId, out secondPlayer))
                    {
                        result = fields[3] switch
                        {
                            "?" => 0,
                            "V1" => 1,
                            "V2" => 2,
                            "R" => 3,
                            _ => throw new InvalidDataException($"Neplatný výsledek na řádku {i + 1}.")
                        };
                    }
                    else
                    {
                        throw new InvalidDataException($"Neplatný soupeř na řádku {i + 1}.");
                    }

                    currentRound.games.Add(new Game(firstPlayer, secondPlayer, result));
                }
                else
                {
                    throw new InvalidDataException($"Neznámý záznam na řádku {i + 1}.");
                }
            }

            return new Tournament(tournamentData[1], tournamentData[2], roundCount,
                rounds, players, new[] { winPoints, drawPoints, byePoints });
        }

    }
}