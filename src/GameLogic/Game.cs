namespace GameLogic
{
    public class Game
    {
        public string[,] Board { get; private set; }
        public string CurrentPlayer { get; private set; }

        public Game()
        {
            Board = new string[8, 8];
            CurrentPlayer = "Player1";
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                Board[i, j] = "";

            // Place starting pieces
            Board[3, 3] = "Player1";
            Board[4, 4] = "Player1";
            Board[3, 4] = "Player2";
            Board[4, 3] = "Player2";
        }

        public bool MakeMove(int x, int y)
        {
            if (Board[x, y] != "") return false; // Invalid move
            Board[x, y] = CurrentPlayer;
            CurrentPlayer = CurrentPlayer == "Player1" ? "Player2" : "Player1";
            return true;
        }
    }
}