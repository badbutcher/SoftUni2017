namespace _006
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Team> teams = new List<Team>();
            List<Player> players = new List<Player>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split(';');
                    string command = data[0];

                    if (command == "Team")
                    {
                        teams.Add(new Team(data[1], 0, new List<Player>()));
                    }
                    else if (command == "Add")
                    {
                        try
                        {
                            string teamName = data[1];
                            string playerName = data[2];
                            int endurance = int.Parse(data[3]);
                            int sprint = int.Parse(data[4]);
                            int dribble = int.Parse(data[5]);
                            int passing = int.Parse(data[6]);
                            int shooting = int.Parse(data[7]);
                            Team team = teams.FirstOrDefault(a => a.Name == teamName);

                            if (team == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Player player = new Player(playerName, new Stats(endurance, sprint, dribble, passing, shooting));
                                players.Add(player);
                                team.AddPlayer(player);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (command == "Remove")
                    {
                        try
                        {
                            string teamName = data[1];
                            string playerName = data[2];

                            Team team = teams.FirstOrDefault(a => a.Name == teamName);
                            if (team == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                continue;
                            }
                            else
                            {
                                Player player = players.FirstOrDefault(a => a.Name == playerName);
                                if (player == null)
                                {
                                    Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                                    continue;
                                }

                                team.Players.Remove(player);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (command == "Rating")
                    {
                        try
                        {
                            string teamName = data[1];
                            Team team = teams.FirstOrDefault(a => a.Name == teamName);
                            if (team == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine("{0} - {1}", teamName, team.GetRating());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}