using System.Collections.Generic;
using System.Linq;

namespace SuperLeague
{
    public class Match
    {
        public string HomeTeam { get; private set; }
        public int HomeGoals { get; private set; }
        public string AwayTeam { get; private set; }
        public int AwayGoals { get; private set; }
        public Match(string homeTeam, int homeGoals, string awayTeam, int awayGoals)
        {
            this.HomeTeam = homeTeam;
            this.HomeGoals = homeGoals;
            this.AwayTeam = awayTeam;
            this.AwayGoals = awayGoals;
        }

        public static List<Match> GetMatchesOfTeam(string name, ref List<Match> matches)
            => matches.Where(m => m.HomeTeam == name || m.AwayTeam == name).ToList();
    }
}
