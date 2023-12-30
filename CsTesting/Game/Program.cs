class Program
{
    static int playerX = 10;
    static int playerY = 10;
    static List<Enemy> enemies = new List<Enemy>();

    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    static void Main()
    {
        Console.WindowHeight = 16;
        Console.WindowWidth = 32;
        Console.BufferHeight = 16;
        Console.BufferWidth = 32;

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            DrawPlayer();
            DrawEnemies();
            MovePlayer();
            MoveEnemies();
            DetectCollisions();
            Thread.Sleep(100);
        }
    }

    static void DrawPlayer()
    {
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("P");
    }

    static void DrawEnemies()
    {
        foreach (var enemy in enemies)
        {
            Console.SetCursorPosition(enemy.X, enemy.Y);
            Console.Write("E");
        }
    }

    static void MovePlayer()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (playerY > 0) playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    if (playerY < Console.WindowHeight - 1) playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (playerX > 0) playerX--;
                    break;
                case ConsoleKey.RightArrow:
                    if (playerX < Console.WindowWidth - 1) playerX++;
                    break;
            }
        }
    }

    static void MoveEnemies()
    {
        Random random = new Random();
        foreach (var enemy in enemies)
        {
            enemy.X += random.Next(-1, 2);
            enemy.Y += random.Next(-1, 2);

            // Ensure enemies stay within the console window
            enemy.X = Math.Max(0, Math.Min(enemy.X, Console.WindowWidth - 1));
            enemy.Y = Math.Max(0, Math.Min(enemy.Y, Console.WindowHeight - 1));
        }
    }

    static void DetectCollisions()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.X == playerX && enemy.Y == playerY)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                Console.Write("Game Over!");
                Environment.Exit(0);
            }
        }
    }
}