namespace GameLogic
{
    public class MenuManager
    {
        public enum MenuState
        {
            MainMenu,
            StartGame,
            JoinGame,
            Quit
        }

        public MenuState CurrentState { get; private set; }
        public string PlayerName { get; private set; }
        public string RoomName { get; private set; }

        public MenuManager()
        {
            CurrentState = MenuState.MainMenu;
        }

        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }

        public void SetRoomName(string room)
        {
            RoomName = room;
        }

        public void NavigateTo(MenuState state)
        {
            CurrentState = state;
        }
    }
}