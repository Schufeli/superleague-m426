using Xunit;
using System.Collections.Generic;
using SuperLeague.Extensions;

namespace SuperLeague.Tests
{
    public class RowTest
    {
        public List<Match> MockMatches;

        public RowTest()
        {
            MockMatches = new List<Match>()
            {
                new("FC Luzern", 4, "FC Basel", 4),
                new("FC Zürich", 2, "FC Basel", 4),
                new("FC Buochs", 2, "FC Basel", 4),
                new("FC Buochs", 2, "FC Basel", 4),
                new("FC Basel", 2, "FC Zürich", 4)
            };
        }

        [Fact]
        public void SetGoals_WithMockListOfMatches_ChecksEachMatchAndFillsOutTheGoalAndFields()
        {
            // Arrange
            int expectedScoredGoals = 18;
            int expectedReceivedGoals = 14;
            string team = "FC Basel";

            // Act
            Row row = new Row(team, ref MockMatches)
                .SetGoals();

            // Assert
            Assert.Equal(expectedScoredGoals, row.ScoredGoals);
            Assert.Equal(expectedReceivedGoals, row.ReceivedGoals);
        }

        [Fact]
        public void SetResultsAndPoints_WithMockListOfMatches_ChecksEachMatchAndFillsOutThePointWinLossAndDrawFields() 
        {
            // Arrange
            int expectedWins = 3;
            int expectedLosses = 1;
            int expectedDraws = 1;
            int expectedPoints = 10;
            string team = "FC Basel";

            // Act
            Row row = new Row(team, ref MockMatches)
                .SetResultsAndPoints();

            // Assert
            Assert.Equal(expectedWins, row.Wins);
            Assert.Equal(expectedLosses, row.Losses);
            Assert.Equal(expectedDraws, row.Draws);
            Assert.Equal(expectedPoints, row.Points);
        }

        [Fact]
        public void SetGoalRatio_WithMockListOfMatches_ReturnsTheGoalRatioBetweenScoredAndReceivedGoals()
        {
            // Arrange
            int expectedGoalRatio = 4;
            string team = "FC Basel";

            // Act
            Row row = new Row(team, ref MockMatches)
                .SetGoals()
                .SetGoalRatio();

            // Assert
            Assert.Equal(expectedGoalRatio, row.GoalRatio);
        }
    }
}
