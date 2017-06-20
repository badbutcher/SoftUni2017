namespace _004ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<string, SortedSet<string>> league = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, int> wins = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split(new string[] { " | ", ":" }, StringSplitOptions.RemoveEmptyEntries);
                    string teamOne = data[0];
                    string teamTwo = data[1];
                    int teamOneHomeGoals = int.Parse(data[2]);
                    int teamOneAwayGoals = int.Parse(data[5]);
                    int teamTwoHomeGoals = int.Parse(data[4]);
                    int teamTwoAwayGoals = int.Parse(data[3]);

                    if (!league.ContainsKey(teamOne))
                    {
                        league.Add(teamOne, new SortedSet<string>());
                    }

                    league[teamOne].Add(teamTwo);

                    if (!league.ContainsKey(teamTwo))
                    {
                        league.Add(teamTwo, new SortedSet<string>());
                    }

                    league[teamTwo].Add(teamOne);

                    if (!wins.ContainsKey(teamOne))
                    {
                        wins.Add(teamOne, 0);
                    }

                    if (!wins.ContainsKey(teamTwo))
                    {
                        wins.Add(teamTwo, 0);
                    }

                    int teamOneTotalGoals = teamOneHomeGoals + teamOneAwayGoals;
                    int teamTwoTotalGoals = teamTwoHomeGoals + teamTwoAwayGoals;

                    if (teamOneHomeGoals < teamTwoHomeGoals && teamOneTotalGoals == teamTwoTotalGoals)
                    {
                        wins[teamOne]++;
                    }
                    else if (teamOneHomeGoals > teamTwoHomeGoals && teamOneTotalGoals == teamTwoTotalGoals)
                    {
                        wins[teamTwo]++;
                    }
                    else if (teamOneTotalGoals < teamTwoTotalGoals)
                    {
                        wins[teamTwo]++;
                    }
                    else if (teamOneTotalGoals > teamTwoTotalGoals)
                    {
                        wins[teamOne]++;
                    }
                }
            }

            var result = wins.OrderByDescending(a => a.Value).ThenBy(c => c.Key);

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine("- Wins: {0}", item.Value);
                Console.WriteLine("- Opponents: {0}", string.Join(", ", league[item.Key]));
            }
        }
    }
}