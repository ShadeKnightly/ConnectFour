using System;
using System.Drawing;
using System.Windows.Forms;

namespace connect4UI
{
    public static class GameLogic
    {
        //AL - these functions need parameter for the board and color
        //since they moved to a static class from originally being inside pvp
        //they do not have access to the board and color in pvp
        public static bool IsBoardEmpty(Button[,] board)
        {
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col].BackColor != Color.Black)
                        return false;
                }
            }
            return true;
        }

        public static bool CheckWin(Button[,] board, Color color)
        {
            return CheckHorizontalWin(board, color) ||
                   CheckVerticalWin(board, color) ||
                   CheckDiagonalWin(board, color);
        }

        //loop through rows to find winning pattern
        public static bool CheckHorizontalWin(Button[,] board, Color color)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col <= board.GetLength(1) - 4; col++)
                {
                    if (board[row, col].BackColor == color &&
                        board[row, col + 1].BackColor == color &&
                        board[row, col + 2].BackColor == color &&
                        board[row, col + 3].BackColor == color)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //loop through columns to find winning pattern
        public static bool CheckVerticalWin(Button[,] board, Color color)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                for (int row = 0; row <= board.GetLength(0) - 4; row++)
                {
                    if (board[row, col].BackColor == color &&
                        board[row + 1, col].BackColor == color &&
                        board[row + 2, col].BackColor == color &&
                        board[row + 3, col].BackColor == color)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //look for diagonal winning pattern
        public static bool CheckDiagonalWin(Button[,] board, Color color)
        {
            int rows = board.GetLength(0); // rows (in case it changes from 6)
            int cols = board.GetLength(1); // columns (in case it changes from 7)

            // check for diagonal down-right (\) wins
            for (int row = 0; row <= rows - 4; row++) // start row 0 up to total-4
            {
                for (int col = 0; col <= cols - 4; col++) // start col 0 up to total-4
                {
                    if (board[row, col].BackColor == color &&
                        board[row + 1, col + 1].BackColor == color &&
                        board[row + 2, col + 2].BackColor == color &&
                        board[row + 3, col + 3].BackColor == color)
                    {
                        return true;
                    }
                }
            }

            // check for diagonal down-left (/) wins
            for (int row = 0; row <= rows - 4; row++) // start row 0 up to total-4
            {
                for (int col = 3; col < cols; col++) // start from col=3 until no more cols
                {
                    if (board[row, col].BackColor == color &&
                        board[row + 1, col - 1].BackColor == color &&
                        board[row + 2, col - 2].BackColor == color &&
                        board[row + 3, col - 3].BackColor == color)
                    {
                        return true;
                    }
                }
            }

            return false; // no diagonal win found
        }

        public static bool CheckDraw(Button[,] board)
        {
            foreach (var cell in board)
            {
                if (cell.BackColor == Color.Black) return false; // exit as soon as there is an unplayed slot
            }
            return true; // all slots are occupied, therefore a draw
        }

    }

}