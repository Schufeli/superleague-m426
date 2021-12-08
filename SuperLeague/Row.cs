

using System.Collections.Generic;

namespace SuperLeague
{
    public class Row
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int ScoredGoals { get; set; }
        public int ReceivedGoals { get; set; }
        public int GoalRatio { get; set; }
        public int Points { get; set; }
        public List<Match> Matches { get; private set; }

        public Row(string name, ref List<Match> matches)
        {
            this.Name = name;
            this.Rank = 0;
            this.Matches = matches;
        }

        /* Sie finden alle Methoden der Row Klasse in dem Extension file Extensions/RowExtension.cs */
    }
}
