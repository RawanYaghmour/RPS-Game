using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Game
{
    public class RPSGame
    {
        public static string[] move = { "rock", "paper", "scissors" };

        public static string DetermineWinner(string playerMove, string aiMove)
        {
            if (playerMove == aiMove)
                return "No winner";

            return (playerMove == "rock" && aiMove == "scissors") ||
                   (playerMove == "paper" && aiMove == "rock") ||
                   (playerMove == "scissors" && aiMove == "paper") ? "Player" : "AI";
        }

        public static string GenerateAIMove()
        {
            Random rnd = new Random();
            int index = rnd.Next(move.Length);
            return move[index];
        }

        // "Hard Mode"
        public static string GenerateAICheatMove(string playerMove)
        {
            return playerMove switch
            {
                "rock" => "paper",
                "paper" => "scissors",
                "scissors" => "rock",
                _ => throw new ArgumentException("Invalid player move")
            };
        }

        public static void ExecuteRound(Player player, Player ai, bool cheatMode)
        {
            string playerMove = player.ChoosingMove();

            string aiMove = cheatMode ? GenerateAICheatMove(playerMove) : GenerateAIMove();
            Console.WriteLine($"AI {(cheatMode ? "(Cheat Mode) " : "")}chose: {aiMove}");

            string winner = DetermineWinner(playerMove, aiMove);
            UpdateScore(player, ai, winner);

            AnnounceRoundResult(winner);
            ShowScores(player, ai);
        }

        public static void UpdateScore(Player player, Player ai, string winner)
        {
            if (winner == "Player")
            {
                player.Score++;
            }
            else if (winner == "AI")
            {
                ai.Score++;
            }
        }

        private static void AnnounceRoundResult(string winner)
        {
            if (winner == "Player")
            {
                Console.WriteLine("You win this round!");
            }
            else if (winner == "AI")
            {
                Console.WriteLine("AI wins this round!");
            }
            else
            {
                Console.WriteLine("No winner!");
            }
        }

        public static void ShowScores(Player player, Player ai)
        {
            Console.WriteLine($"\nScores:\n{player.Name}: {player.Score}\n{ai.Name}: {ai.Score}");
        }

        public static void StartGame(Player player, Player ai, bool cheatMode)
        {
            int roundNumber = 1;
            while (player.Score < 3 && ai.Score < 3)
            {
                Console.WriteLine($"Round {roundNumber}:");
                ExecuteRound(player, ai, cheatMode);
                roundNumber++;
            }

            DeclareFinalWinner(player, ai);
        }

        private static void DeclareFinalWinner(Player player, Player ai)
        {
            if (player.Score > ai.Score)
            {
                Console.WriteLine("Hooraaaaaaaaaaaaaaay! You've won the game!!!!!");
            }
            else
            {
                Console.WriteLine("The AI is the winner! Try again for victory!");
            }
        }
    }
}
