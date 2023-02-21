using System;

class Program
{
    static void Main()
    {
        // Set up initial game state
        int player1Score = 0;
        int player2Score = 0;
        int ballX = Console.WindowWidth / 2;
        int ballY = Console.WindowHeight / 2;
        int ballSpeedX = 1;
        int ballSpeedY = 1;
        int player1Y = Console.WindowHeight / 2;
        int player2Y = Console.WindowHeight / 2;
        bool isPlaying = true;

        // Hide the cursor to make the game look cleaner
        Console.CursorVisible = false;

        // Main game loop
        while (isPlaying)
        {
            // Clear the console
            Console.Clear();

            // Draw the game board
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, i);
                Console.Write("|");
            }

            // Draw the ball
            Console.SetCursorPosition(ballX, ballY);
            Console.Write("O");

            // Draw the players
            for (int i = -2; i <= 2; i++)
            {
                Console.SetCursorPosition(0, player1Y + i);
                Console.Write("|");
                Console.SetCursorPosition(Console.WindowWidth - 1, player2Y + i);
                Console.Write("|");
            }

            // Move the ball
            ballX += ballSpeedX;
            ballY += ballSpeedY;

            // Check for collisions with walls
            if (ballY <= 0 || ballY >= Console.WindowHeight - 1)
            {
                ballSpeedY *= -1;
            }

            // Check for collisions with players
            if (ballX == 1 && ballY >= player1Y - 2 && ballY <= player1Y + 2)
            {
                ballSpeedX *= -1;
            }
            else if (ballX == Console.WindowWidth - 2 && ballY >= player2Y - 2 && ballY <= player2Y + 2)
            {
                ballSpeedX *= -1;
            }

            // Check for score
            if (ballX <= 0)
            {
                player2Score++;
                ballX = Console.WindowWidth / 2;
                ballY = Console.WindowHeight / 2;
                ballSpeedX *= -1;
            }
            else if (ballX >= Console.WindowWidth - 1)
            {
                player1Score++;
                ballX = Console.WindowWidth / 2;
                ballY = Console.WindowHeight / 2;
                ballSpeedX *= -1;
            }

            // Move the players
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W && player1Y > 2)
                {
                    player1Y -= 2;
                }
                else if (key.Key == ConsoleKey.S && player1Y < Console.WindowHeight - 3)
                {
                    player1Y += 2;
                }
                else if (key.Key == ConsoleKey.UpArrow && player2Y > 2)
                {
                    player2Y -= 2;
                }
                else if (key.Key == ConsoleKey.DownArrow && player2Y < Console.WindowHeight - 3)
                {
                    player2Y += 2;
                }
                else if (key.Key == ConsoleKey.Escape)
                                {
                    isPlaying = false;
                }
            }

            // Print the current score
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 0);
            Console.Write("Player 1: {0}", player1Score);
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 0);
            Console.Write("Player 2: {0}", player2Score);

            // Wait a short amount of time before redrawing the screen to prevent flickering
            System.Threading.Thread.Sleep(16);
        }
    }
}