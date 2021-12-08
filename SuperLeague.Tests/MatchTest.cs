using System;
using System.Collections.Generic;
using Xunit;

namespace SuperLeague.Tests
{
    public class MatchTest
    {
        public List<Match> MockMatches;

        public MatchTest()
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
        public void GetMatchesOfTeam_WithMockListOfMatches_ReturnsAllMatchesATeamHasPlayed()
        {
            // Arrange
            int expected = 5;
            string team = "FC Basel";

            // Act
            List<Match> matches = Match.GetMatchesOfTeam(team, ref MockMatches);
            int actual = matches.Count;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
