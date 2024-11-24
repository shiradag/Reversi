using GameLogic;

namespace MockUI;

internal static class Program
{
    private static void Main(string[] args)
    {
        var menuManager = new MenuManager();
        var game = new Game();

        Console.WriteLine("Welcome to Reversi!");
        while (true)
        {
            switch (menuManager.CurrentState)
            {
                case MenuManager.MenuState.MainMenu:
                    DisplayMainMenu(menuManager, game);
                    break;
                case MenuManager.MenuState.StartGame:
                    PlayGame(game);
                    menuManager.NavigateTo(MenuManager.MenuState.MainMenu);
                    break;
                case MenuManager.MenuState.JoinGame:
                    Console.WriteLine("Join Game not implemented yet.");
                    menuManager.NavigateTo(MenuManager.MenuState.MainMenu);
                    break;
                case MenuManager.MenuState.Quit:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static void DisplayMainMenu(MenuManager menuManager, Game game)
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Start Game");
        Console.WriteLine("2. Join Game");
        Console.WriteLine("3. Quit");
        Console.WriteLine("Type 'sim' to run a simulation.");

        string? choice = Console.ReadLine()?.ToLower();
        switch (choice)
        {
            case "1":
                menuManager.NavigateTo(MenuManager.MenuState.StartGame);
                break;
            case "2":
                menuManager.NavigateTo(MenuManager.MenuState.JoinGame);
                break;
            case "3":
                menuManager.NavigateTo(MenuManager.MenuState.Quit);
                break;
            case "sim":
                RunSimulation(game: game);
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    private static void PlayGame(Game game)
    {
        Console.WriteLine("\nStarting Reversi Game!");
        game = new Game(); // Reset the game
        while (true)
        {
            Console.WriteLine($"Current Player: {game.CurrentPlayer}");
            DisplayBoard(game);

            Console.WriteLine("Enter your move (row, column) or 'q' to quit:");
            string? input = Console.ReadLine();
            if (input?.ToLower() == "q") break;

            if (ParseMove(input!, out int row, out int col))
            {
                if (game.MakeMove(row, col)) continue;
                Console.WriteLine("Invalid move. Try again.");
            }
            else
            {
                Console.WriteLine("Invalid input. Use format: row,column (e.g., 3,4).");
            }
        }
    }

    private static void RunSimulation(Game game)
    {
        Console.WriteLine("\nRunning Simulation...");
        game = new Game(); // Reset the game
        var rand = new Random();

        for (int i = 0; i < 10; i++) // Simulate 10 random moves
        {
            int row, col;
            do
            {
                row = rand.Next(0, 8);
                col = rand.Next(0, 8);
            } while (!game.MakeMove(row, col));

            Console.WriteLine($"Move {i + 1}: Player {game.CurrentPlayer} -> ({row}, {col})");
            DisplayBoard(game);
        }

        Console.WriteLine("Simulation Complete. Returning to Main Menu...");
    }

    private static void DisplayBoard(Game game)
    {
        Console.WriteLine("\n   0 1 2 3 4 5 6 7"); // Column labels
        Console.WriteLine("  ----------------");
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"{i} |"); // Row label
            for (int j = 0; j < 8; j++)
            {
                string piece = game.Board[i, j];
                Console.Write(string.IsNullOrEmpty(piece) ? "." : piece[6]); // Show '1' or '2' from "Player1"/"Player2"
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("  ----------------");
    }

    private static bool ParseMove(string input, out int row, out int col)
    {
        string[] parts = input.Split(',');
        if (parts.Length == 2 &&
            int.TryParse(parts[0], out row) &&
            int.TryParse(parts[1], out col) &&
            row is >= 0 and < 8 &&
            col is >= 0 and < 8)
            return true;

        row = col = -1;
        return false;
    }
}
