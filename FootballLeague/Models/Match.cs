namespace FootballLeague.Models
{
    using System;
    using Utils;

    public class Match
    {
        private Team homeTeam;
        private Team awayTeam;
        private Score score;
        private int id;

        public Match(Team homeTeam, Team awayTeam, Score score, int id)
        {
            if (homeTeam.Name == awayTeam.Name)
            {
                throw new ArgumentException(MsgConstants.TeamsShouldBeDifferent);
            }

            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.MatchScore = score;
            this.Id = id;
        }

        private Team AwayTeam
        {
            get { return this.awayTeam; }
            set { this.awayTeam = value; }
        }

        private Team HomeTeam
        {
            get { return this.homeTeam; }
            set { this.homeTeam = value; }
        }

        private Score MatchScore
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            return this.MatchScore.HomeTeamGoals > this.MatchScore.AwayTeamGoals
                ? this.HomeTeam
                : this.AwayTeam;
        }

        public override string ToString()
        {
            return $"{this.HomeTeam} {this.MatchScore.HomeTeamGoals} : {this.MatchScore.AwayTeamGoals} {this.AwayTeam}";
        }

        private bool IsDraw()
        {
            return this.MatchScore.HomeTeamGoals == this.MatchScore.AwayTeamGoals;
        }
    }
}