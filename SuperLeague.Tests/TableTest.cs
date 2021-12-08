using System.Collections.Generic;
using Xunit;
using SuperLeague.Extensions;

namespace SuperLeague.Tests
{
    public class TableTest
    {
        public List<Match> MockMatches;

        public TableTest()
        {
            MockMatches = new List<Match>()
            {
                new("FC Luzern", 2, "FC Basel", 4),
                new("FC Zürich", 2, "FC Basel", 4),
                new("FC Buochs", 2, "FC Basel", 4),
                new("FC Buochs", 2, "FC Basel", 4),
                new("FC Basel", 2, "FC Zürich", 4)
            };
        }

        [Fact]
        public void GetAllTeams_WithMockListOfMatches_IteratesListAndReturnsNewListWithOnlyTeamNames()
        {
            // Arrange
            int expected = 4;

            // Act
            List<string> teams = Table.GetAllTeams(ref MockMatches);
            int actual = teams.Count;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OrderTableByPointsAndGoalsDesc_WithMockTableRows_SortsListByPointsDesc()
        {
            // Arrange
            string expectedFirstTeamName = "FC Basel";
            int expectedFirstTeamPoints = 12;
            string expectedLastTeamName = "FC Buochs";
            int expectedLastTeamPoints = 0;
            Table table = new();

            // Act
            List<string> teams = Table.GetAllTeams(ref MockMatches);
            foreach (string team in teams)
            {
                List<Match> teamMatches = Match.GetMatchesOfTeam(team, ref MockMatches);

                Row row = new Row(team, ref teamMatches)
                    .SetGoals()
                    .SetGoalRatio()
                    .SetResultsAndPoints();

                table.TableRows.Add(row);
            }

            table.OrderTableByPointsAndGoalsDesc();

            // Assert
            Assert.Equal(expectedFirstTeamName, table.TableRows[0].Name);
            Assert.Equal(expectedFirstTeamPoints, table.TableRows[0].Points);
            Assert.Equal(expectedLastTeamName, table.TableRows[3].Name);
            Assert.Equal(expectedLastTeamPoints, table.TableRows[3].Points);
        }
    }
}
