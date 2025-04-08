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
            for (int row = 0; row <= board.GetLength(0) - 4; row++)
            {
                for (int col = 0; col <= board.GetLength(1) - 4; col++)
                {
                    if (board[row, col].BackColor == color &&
                        board[row + 1, col + 1].BackColor == color &&
                        board[row + 2, col + 2].BackColor == color &&
                        board[row + 3, col + 3].BackColor == color)
                    {
                        return true;
                    }

                    if (col >= 3 && board[row, col].BackColor == color &&
                        board[row + 1, col - 1].BackColor == color &&
                        board[row + 2, col - 2].BackColor == color &&
                        board[row + 3, col - 3].BackColor == color)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CheckDraw(Button[,] board)
        {
            foreach (var cell in board)
            {
                if (cell.BackColor == Color.White) return false; // exit as soon as there is an unplayed slot
            }
            return true; // all slots are occupied, therefore a draw
        }
        
    }

}
