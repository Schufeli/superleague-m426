namespace SuperLeague.Extensions
{
    public static class TableExtension
    {
        public static Table OrderTableByPointsAndGoalsDesc(this Table table)
        {
            table.TableRows.Sort((x, y) => // Wurde eins zu eins aus Ihrem Video "gestohlen" ;)
            {
                if (x.Points > y.Points)
                    return -1;
                else if (x.Points < y.Points)
                    return 1;
                else if (x.GoalRatio > y.GoalRatio)
                    return -1;
                else if (x.GoalRatio < y.GoalRatio)
                    return 1;
                else
                    return x.Name.CompareTo(y.Name);
            });
            return table;
        }
    }
}
