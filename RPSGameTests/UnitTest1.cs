using Xunit;

namespace RPS_Game.Tests
{
    public class RPSGameTests
    {
        [Theory]
        [InlineData("rock", "scissors", "Player")]  // Player wins
        [InlineData("rock", "paper", "AI")]         // AI wins
        [InlineData("rock", "rock", "No winner")]   // Tie
        [InlineData("paper", "rock", "Player")]     // Player wins
        [InlineData("paper", "scissors", "AI")]     // AI wins
        [InlineData("paper", "paper", "No winner")] // Tie
        [InlineData("scissors", "paper", "Player")] // Player wins
        [InlineData("scissors", "rock", "AI")]      // AI wins
        [InlineData("scissors", "scissors", "No winner")] // Tie
        public void DetermineWinner_ShouldReturnCorrectWinner(string playerMove, string aiMove, string expectedWinner)
        {
            // Act
            var actualWinner = RPSGame.DetermineWinner(playerMove, aiMove);

            // Assert
            Assert.Equal(expectedWinner, actualWinner);
        }
        [Fact]
        public void UpdateScore_ShouldUpdatePlayerScore_WhenPlayerWins()
        {
            // Arrange
            var player = new Player("Player");
            var ai = new Player("AI");
            string winner = "Player";

            // Act
            RPSGame.UpdateScore(player, ai, winner);

            // Assert
            Assert.Equal(1, player.Score);
            Assert.Equal(0, ai.Score);
        }

        [Fact]
        public void UpdateScore_ShouldUpdateAIScore_WhenAIWins()
        {
            // Arrange
            var player = new Player("Player");
            var ai = new Player("AI");
            string winner = "AI";

            // Act
            RPSGame.UpdateScore(player, ai, winner);

            // Assert
            Assert.Equal(0, player.Score);
            Assert.Equal(1, ai.Score);
        }
    }
}
