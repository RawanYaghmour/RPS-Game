namespace RPS_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Rock, Paper, Scissors Game!!");

            try
            {
                Player player = new Player("Player");
                Player ai = new Player("AI");


                // Normal mode:
                RPSGame.StartGame(player, ai, cheatMode: false);

                // Cheat mode:
                // RPSGame.StartGame(player, ai, cheatMode: true); 

            }
            catch (Exception ex)
            {
                Console.WriteLine($"unexpected error: {ex.Message}");
            }
        }
    }
}
