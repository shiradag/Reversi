using Xunit;
using GameLogic;

namespace GameLogic.Tests
{
    public class MenuManagerTests
    {
        [Fact]
        public void TestDefaultState()
        {
            var menuManager = new MenuManager();
            Assert.Equal(MenuManager.MenuState.MainMenu, menuManager.CurrentState);
        }

        [Fact]
        public void TestSetPlayerName()
        {
            var menuManager = new MenuManager();
            menuManager.SetPlayerName("Alice");
            Assert.Equal("Alice", menuManager.PlayerName);
        }

        [Fact]
        public void TestNavigateToStartGame()
        {
            var menuManager = new MenuManager();
            menuManager.NavigateTo(MenuManager.MenuState.StartGame);
            Assert.Equal(MenuManager.MenuState.StartGame, menuManager.CurrentState);
        }
    }
}