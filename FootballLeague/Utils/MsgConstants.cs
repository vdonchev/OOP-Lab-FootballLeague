namespace FootballLeague.Utils
{
    internal static class MsgConstants
    {
        // Error messages
        internal const string StringShouldBeAtLeast = "{0} should be at least {1} characters long.";
        internal const string StringCantBeNullOrEmpty = "{0} cannot be null or empty.";
        internal const string NumberCantBeNegative = "{0} cannot be negative.";
        internal const string TeamsShouldBeDifferent = "Home team and Away team should be different.";
        internal const string DateShouldBeAfter = "{0} should be date after {1}.";
        internal const string PlayerExistsInTeam = "Player already exists in the team.";
        internal const string TeamAlreadyExists = "Team already exists in the league.";
        internal const string MatchAlreadyExists = "Match already exists in the league.";
        internal const string TeamNotFound = "{0} team is not found in the league!";

        // Messages
        internal const string TeamAdded = "Team {0} added!";
        internal const string MatchAdded = "Match {0} added!";
        internal const string PlayerAdded = "{0} added to {1} team!";
    }
}