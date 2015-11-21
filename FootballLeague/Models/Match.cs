namespace FootballLeague.Models
{
    using System;
    using Utils;

    public class Match
    {
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

        private Team AwayTeam { get; }

        private Team HomeTeam { get; }

        private Score MatchScore { get; }

        public int Id { get; private set; }

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