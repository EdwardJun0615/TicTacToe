using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private char[,] board = new char[3, 3];
        private char currentPlayer = 'X';

        public MainWindow()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Content = currentPlayer.ToString();
            clickedButton.IsEnabled = false;

            // Update board state
            var buttonPosition = clickedButton.Name.Replace("Button", "").Split('_');
            int row = int.Parse(buttonPosition[0]);
            int column = int.Parse(buttonPosition[1]);
            board[row, column] = currentPlayer;

            if (CheckForWinner())
            {
                MessageBox.Show($"Player {currentPlayer} wins!");
                ResetBoard();
                return;
            }

            // Switch player
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }

        private bool CheckForWinner()
        {
            // Check for 3 in a row in each row
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                    return true;
            }

            // Check for 3 in a column in each column
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                    return true;
            }

            // Check for 3 in a diagonal
            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true;

            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true;

            // No winner found
            return false;
        }



        private void ResetBoard()
        {
            // Reset the board array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }

            // Reset the buttons on the UI
            foreach (UIElement element in MainGrid.Children)
            {
                if (element is Button button)
                {
                    button.Content = "";
                    button.IsEnabled = true;
                }
            }

            // Optionally reset the current player
            currentPlayer = 'X'; 
        }

    }
}
