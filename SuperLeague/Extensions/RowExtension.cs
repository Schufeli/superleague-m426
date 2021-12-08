namespace SuperLeague.Extensions
{
    public static class RowExtension
    {
        public static Row SetGoals(this Row row)
        {
            foreach (var element in row.Matches)
            {
                if (element.HomeTeam.Equals(row.Name))
                {
                    row.ScoredGoals += element.HomeGoals;
                    row.ReceivedGoals += element.AwayGoals;
                }
                if (element.AwayTeam.Equals(row.Name))
                {
                    row.ScoredGoals += element.AwayGoals;
                    row.ReceivedGoals += element.HomeGoals;
                }
            }
            return row;
        }

        public static Row SetResultsAndPoints(this Row row)
        {
            foreach (var element in row.Matches)
            {
                if (element.HomeTeam.Equals(row.Name))
                {
                    if (element.HomeGoals > element.AwayGoals)
                    {
                        row.Points += 3;
                        row.Wins += 1;
                    }
                    if (element.HomeGoals == element.AwayGoals)
                    {
                        row.Points += 1;
                        row.Draws += 1;
                    }
                    if (element.HomeGoals < element.AwayGoals)
                        row.Losses += 1;

                }
                if (element.AwayTeam.Equals(row.Name))
                {
                    if (element.AwayGoals > element.HomeGoals)
                    {
                        row.Points += 3;
                        row.Wins += 1;
                    }   
                    if (element.AwayGoals == element.HomeGoals)
                    {
                        row.Points += 1;
                        row.Draws += 1;
                    }
                    if (element.AwayGoals < element.HomeGoals)
                        row.Losses += 1;
                }
            }
            return row;
        }

        public static Row SetGoalRatio(this Row row)
        {
            row.GoalRatio = row.ScoredGoals - row.ReceivedGoals;
            return row;
        }
    }
}
