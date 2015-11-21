namespace FootballLeague
{
    using System;

    public static class ProgramMain
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != null && !line.Equals("End"))
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

                line = Console.ReadLine();
            }
        }
    }
}