namespace FootballLeague
{
    using System;
    using League;

    public static class ProgramMain
    {
        public static void Main(string[] args)
        {
            string line;
            while (!(line = Console.ReadLine()).Equals("End"))
            {
                try
                {
                    LeagueManager.HandleInput(line);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
        }
    }
}