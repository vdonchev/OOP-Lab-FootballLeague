namespace FootballLeague
{
    using System;
    using System.Linq;
    using Models;
    using Utils;

    public static class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputTokens = input.Split();
            switch (inputTokens[0])
            {
                case "AddTeam":
                    AddTeam(inputTokens[1], inputTokens[2], DateTime.Parse(inputTokens[3]));
                    break;
                case "AddMatch":
                    AddMatch(int.Parse(inputTokens[1]), inputTokens[2], inputTokens[3], int.Parse(inputTokens[4]), int.Parse(inputTokens[5]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputTokens[1], inputTokens[2], DateTime.Parse(inputTokens[3]), decimal.Parse(inputTokens[4]), inputTokens[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
            }
        }

        private static void AddPlayerToTeam(string playerFirstName, string playerLastName, DateTime playerBirthDate, decimal playerSalary, string playerTeam)
        {
            if (League.Teams.All(t => t.Name == playerTeam))
            {
                throw new InvalidOperationException(string.Format(MsgConstants.TeamNotFound, playerTeam));    
            }

            var currentPlayer = new Player(playerFirstName, playerLastName, playerSalary, playerBirthDate);
            var currentTeam = League.Teams.First(t => t.Name == playerTeam);
            currentTeam.AddPlayer(currentPlayer);

            Console.WriteLine(MsgConstants.PlayerAdded, currentPlayer, currentTeam);
        }

        private static void AddTeam(string teamName, string teamNickName, DateTime teamDateFounded)
        {
            var currentTeam = new Team(teamName, teamNickName, teamDateFounded);
            League.AddTeam(currentTeam);

            Console.WriteLine(MsgConstants.TeamAdded, currentTeam);
        }

        private static void AddMatch(int matchId, string homeTeamName, string awayTeamName, int homeTeamGoals, int awayTeamGoals)
        {
            if (League.Matches.Any(match1 => match1.Id == matchId))
            {
                throw new InvalidOperationException(MsgConstants.MatchAlreadyExists);
            }

            if (League.Teams.All(team => team.Name != homeTeamName))
            {
                throw new InvalidOperationException(string.Format(MsgConstants.TeamNotFound, homeTeamName));
            }

            if (League.Teams.All(team => team.Name != awayTeamName))
            {
                throw new InvalidOperationException(string.Format(MsgConstants.TeamNotFound, awayTeamName));
            }

            var homeTeam = League.Teams.First(team => team.Name == homeTeamName);
            var awayTeam = League.Teams.First(team => team.Name == awayTeamName);
            var currentScore = new Score(homeTeamGoals, awayTeamGoals);
            var currentMatch = new Match(homeTeam, awayTeam, currentScore, matchId);
            League.AddMatches(currentMatch);

            Console.WriteLine(MsgConstants.MatchAdded, currentMatch);
        }

        private static void ListTeams()
        {
            foreach (var team in League.Teams)
            {
                Console.WriteLine(team);
            }
        }

        private static void ListMatches()
        {
            foreach (var match in League.Matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}