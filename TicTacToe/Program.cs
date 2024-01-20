using System;

class TicTacToe
{
    static char[,] board = new char[3, 3];
    static char currentPlayer = 'X';

    static void Main()
    {
        InitializeBoard();
        PlayGame();
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '.';
            }
        }
    }

    static void PlayGame()
    {
        bool gameOver = false;

        do
        {
            Console.Clear();
            PrintBoard();

            Console.WriteLine($"Player {currentPlayer}, enter your move (row and column): ");
            int row = Convert.ToInt32(Console.ReadLine());
            int column = Convert.ToInt32(Console.ReadLine());

            if (PlaceMove(row, column, currentPlayer))
            {
                gameOver = CheckForWinner();
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Invalid move, try again.");
                Console.ReadLine();
            }

        } while (!gameOver);

        Console.Clear();
        PrintBoard();
        Console.WriteLine("Game over!");
    }

    static bool PlaceMove(int row, int column, char player)
    {
        if (row >= 0 && row < 3 && column >= 0 && column < 3 && board[row, column] == '.')
        {
            board[row, column] = player;
            return true;
        }
        return false;
    }

    static bool CheckForWinner()
    {
        // Check rows, columns, and diagonals for a winner
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer ||
                board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                return true;
            }
        }

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer ||
            board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }

        return false;
    }

    static void PrintBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
