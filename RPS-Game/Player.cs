using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Game
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public string ChoosingMove()
        {
            string move = string.Empty;
            try
            {
                Console.WriteLine($"{Name}, What's your move? (rock, paper, scissors): ");
                move = Console.ReadLine().ToLower();
                while (move != "rock" && move != "paper" && move != "scissors")
                {
                    Console.WriteLine("Oooops! That's not a valid move. Try again with rock, paper, or scissors: ");
                    move = Console.ReadLine().ToLower();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"unexpected error: {ex.Message}");
            }
            return move;
        }
    }
}
