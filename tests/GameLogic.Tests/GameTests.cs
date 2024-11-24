using Xunit;
using GameLogic;

namespace GameLogic.Tests
{
    public class GameTests
    {
        [Fact]
        public void TestInitializeBoard()
        {
            var game = new Game();
            Assert.Equal("Player1", game.Board[3, 3]);
            Assert.Equal("Player2", game.Board[3, 4]);
        }

        [Fact]
        public void TestMakeValidMove()
        {
            var game = new Game();
            bool result = game.MakeMove(2, 3);
            Assert.True(result);
            Assert.Equal("Player1", game.Board[2, 3]);
        }

        [Fact]
        public void TestMakeInvalidMove()
        {
            var game = new Game();
            bool result = game.MakeMove(3, 3); // Occupied
            Assert.False(result);
        }
    }
}