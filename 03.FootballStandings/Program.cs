namespace _03.FootballStandings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Program
    {
        private const string End = "final";

        private static readonly SortedDictionary<string, DataEntry> MatchesArchive =
            new SortedDictionary<string, DataEntry>();

        public static void Main()
        {
            var pattern = Console.ReadLine();

            var line = Console.ReadLine();
            while (line != End)
            {
                var tokens = line.Split().ToArray();
                
                var teamA = FormatTeamName(Regex.Split(tokens[0], Regex.Escape(pattern))[1]);
                var teamB = FormatTeamName(Regex.Split(tokens[1], Regex.Escape(pattern))[1]);

                var score = tokens[2].Split(':');
                var teamAGoals = int.Parse(score[0]);
                var teamBGoals = int.Parse(score[1]);

                var teamAPoints = 0;
                var teamBPoints = 0;

                DesideWinner(teamAGoals, teamBGoals, ref teamAPoints, ref teamBPoints);

                AddStatsToArchive(teamA, teamAGoals, teamAPoints, teamB, teamBGoals, teamBPoints);

                line = Console.ReadLine();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine("League standings:");
            var pos = 1;
            foreach (var team in MatchesArchive.OrderByDescending(t => t.Value.Points))
            {
                Console.WriteLine($"{pos++}. {team.Key} {team.Value.Points}");
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in MatchesArchive.OrderByDescending(t => t.Value.Goals).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value.Goals}");
            }
        }

        private static void AddStatsToArchive(string teamA, int teamAGoals, int teamAPoints, string teamB, int teamBGoals, int teamBPoints)
        {
            if (!MatchesArchive.ContainsKey(teamA))
            {
                MatchesArchive[teamA] = new DataEntry();
            }

            if (!MatchesArchive.ContainsKey(teamB))
            {
                MatchesArchive[teamB] = new DataEntry();
            }

            MatchesArchive[teamA].Goals += teamAGoals;
            MatchesArchive[teamA].Points += teamAPoints;

            MatchesArchive[teamB].Goals += teamBGoals;
            MatchesArchive[teamB].Points += teamBPoints;
        }

        private static string FormatTeamName(string name)
        {
            var res = new string(name.Trim().Reverse().ToArray()).ToUpper();

            return res;
        }

        private static void DesideWinner(int teamAGoals, int teamBGoals, ref int teamAPoints, ref int teamBPoints)
        {
            var res = teamAGoals > teamBGoals;
            if (res)
            {
                teamAPoints += 3;
            }
            else
            {
                res = teamAGoals < teamBGoals;
                if (res)
                {
                    teamBPoints += 3;
                }
                else
                {
                    teamAPoints++;
                    teamBPoints++;
                }
            }
        }
    }

    internal class DataEntry
    {
        public long Goals { get; set; }

        public long Points { get; set; }
    }
}