namespace FootballLeague.League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Utils;

    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches; }
        }

        public static void AddTeam(Team team)
        {
            if (TeamExistInLeague(team))
            {
                throw new InvalidOperationException(MsgConstants.TeamAlreadyExists);
            }

            teams.Add(team);
        }

        public static void AddMatches(Match match)
        {
            if (MatchExistInLeague(match))
            {
                throw new InvalidOperationException(MsgConstants.TeamAlreadyExists);
            }

            matches.Add(match);
        }

        private static bool MatchExistInLeague(Match match)
        {
            return matches.Any(m => m.Id == match.Id);
        }

        private static bool TeamExistInLeague(Team team)
        {
            return teams.Any(t => t.Name == team.Name);
        }
    }
}