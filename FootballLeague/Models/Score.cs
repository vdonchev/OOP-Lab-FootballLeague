namespace FootballLeague.Models
{
    using System;
    using Utils;

    public class Score
    {
        private int homeTeamGoals;
        private int awayTeamGoals;

        public Score(int homeTeamGoals, int awayTeamGoals)
        {
            this.HomeTeamGoals = homeTeamGoals;
            this.AwayTeamGoals = awayTeamGoals;
        }

        public int HomeTeamGoals
        {
            get
            {
                return this.homeTeamGoals;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(MsgConstants.NumberCantBeNegative, "Home team goals"));
                }

                this.homeTeamGoals = value;
            }
        }

        public int AwayTeamGoals
        {
            get
            {
                return this.awayTeamGoals;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(MsgConstants.NumberCantBeNegative, "Away team goals"));
                }

                this.awayTeamGoals = value;
            }
        }
    }
}