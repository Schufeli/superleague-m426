using Newtonsoft.Json;
using SuperLeague.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuperLeague
{
    public class Table
    {
        public List<Row> TableRows = new();

        static void Main(string[] args)
        {
            Table table = new Table();
            List<Match> matches = ReadMatches(args[0]);
            List<string> teams = GetAllTeams(ref matches);

            foreach (string team in teams)
            {
                List<Match> teamMatches = Match.GetMatchesOfTeam(team, ref matches);

                Row row = new Row(team, ref teamMatches)
                    .SetGoals()
                    .SetGoalRatio()
                    .SetResultsAndPoints();

                table.TableRows.Add(row);
            }
            table.OrderTableByPointsAndGoalsDesc();
            table.PrintTable(table.TableRows);
        }

        private static List<Match> ReadMatches(string jsonPath) 
        {
            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                List<Match> matches = JsonConvert.DeserializeObject<List<Match>>(json);
                return matches;
            }
        }

        public static List<string> GetAllTeams(ref List<Match> matches)
        {
            List<string> result = new();
            foreach (Match element in matches)
                if (!result.Contains(element.HomeTeam))
                    result.Add(element.HomeTeam);
            return result;

        }

        private void PrintTable(List<Row> rows) // Wäre eigentlich CreateTable aber wurde umbenannt, da das Table nicht erstellt sondern nur ausgegeben wird.
        {
            int counter = 1; // Can be used as rank indicator because list is ordered before function call
            Console.WriteLine("{0, 30} {1,5} {2,5} {3,5} {4,5} {5,5} {6,5} {7,5} {8}", "Name", "#", "w", "d", "l", "+", "-", "=", "P");
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (Row row in rows)
            {
                Console.WriteLine($"{row.Name, 30} {counter, 5} {row.Wins, 5} {row.Draws, 5} {row.Losses, 5} {row.ScoredGoals, 5} {row.ReceivedGoals, 5} {row.GoalRatio, 5} {row.Points}");
                counter++;
            }
        }

        /* Sie finden die weiteren Methoden der Table Klasse in dem Extension file Extensions/TableExtension */
    }
}
