using Xunit;

namespace RPS_Game.Tests
{
    public class RPSGameTests
    {
        [Theory]
        [InlineData("rock", "scissors", "Player")] // Player wins
        [InlineData("rock", "paper", "AI")]       // AI wins
        [InlineData("rock", "rock", "No winner")]       // No winner
        public void DetermineWinner_ShouldReturnCorrectWinner(string playerMove, string aiMove, string expectedWinner)
        {
            // Act
            var actualWinner = RPSGame.DetermineWinner(playerMove, aiMove);

            // Assert
            Assert.Equal(expectedWinner, actualWinner);
        }

        [Theory]
        [InlineData("rock", "paper", "scissors")] // AI beats rock
        [InlineData("paper", "scissors", "rock")] // AI beats paper
        [InlineData("scissors", "rock", "paper")] // AI beats scissors
        public void GetAICheatMove_ShouldReturnCorrectMove(string playerMove, string expectedAIMove, string expectedMessage)
        {
            // Act
            var actualAIMove = RPSGame.GenerateAICheatMove(playerMove);

            // Assert
            Assert.Equal(expectedAIMove, actualAIMove);
        }

        [Theory]
        [InlineData("rock")]
        [InlineData("paper")]
        [InlineData("scissors")]
        public void ChoosingMove_ShouldReturnValidMove(string move)
        {
            // Arrange
            var player = new Player("TestPlayer");

            // Act
            Assert.Contains(move, RPSGame.move);
        }
    }
}
