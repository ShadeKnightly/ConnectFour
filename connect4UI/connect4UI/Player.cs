using System;
using System.Drawing;
using System.Windows.Forms;
using connect4UI;

namespace connect4UI
{
    public interface IPlayer
    {
        string Name { get; }
        Color TokenColor { get; }

        Bitmap TokenImage { get; }
        int Score { get; set; }
        int MakeMove(Button[,] board); //return column player wants to put their token
    }


    public abstract class Player : IPlayer
    {
        public string Name { get; }
        public Color TokenColor { get; }

        public Bitmap TokenImage { get; }
        public int Score { get; set; }

        protected Player(string name, Color col, Bitmap img)
        {
            Name = name;
            TokenColor = col;
            TokenImage = img;
        }

        public abstract int
            MakeMove(Button[,] board); //need abstract so human and AI can implement their different logic
    }

    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, Color col, Bitmap img) : base(name, col, img)
        {
        }

        public override int MakeMove(Button[,] board)
        {
            throw new NotImplementedException(
                "Human moves are handled by UI event."); //handled by button click event handler
        }
    }
    public class AIPlayer : Player
    {
        private static Random rnd = new Random();

        public AIPlayer(string name, Color col, Bitmap img) : base(name, col, img)
        {
        }

        // Basic AI move: choose random or first move advantage
        public override int MakeMove(Button[,] board)
        {
            int? column = FirstMoveAdvantage(board) ?? ChooseRandomColumn(board);
            return column.Value; // return a valid column
        }

        // Check if center column (3) is available for a first move advantage
        protected int? FirstMoveAdvantage(Button[,] board)
        {
            if (board[5, 3].ForeColor == Color.Black)
            {
                return 3; // AI prefers the center
            }

            return null;
        }

        // Choose a random valid column
        protected int ChooseRandomColumn(Button[,] board)
        {
            int column;
            do
            {
                column = rnd.Next(board.GetLength(1));
            } while (!IsValidMove(board, column));

            return column;
        }

        // Check if the column is valid (empty space on top)
        protected bool IsValidMove(Button[,] board, int column)
        {
            return board[0, column].ForeColor == Color.Black;
        }
    }

    public class SmartAIPlayer : AIPlayer
    {
        public SmartAIPlayer(string name, Color col, Bitmap img) : base(name, col, img)
        {
        }

        // Override MakeMove to add smarter logic: prioritize winning, blocking
        public override int MakeMove(Button[,] board)
        {
            Color opponentColor = (TokenColor == Color.Red) ? Color.Yellow : Color.Red;

            // First try to win, then block, then randomly choose
            int? column = FindWinningMove(board, TokenColor) ?? // Winning move for the AI
                          FindWinningMove(board, opponentColor) ?? // Blocking the opponent
                          FirstMoveAdvantage(board) ?? // First move advantage (center preference)
                          ChooseRandomColumn(board); // Random if nothing else

            return column.Value;
        }
        // Find a winning move for a specific color
        private int? FindWinningMove(Button[,] board, Color color)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (IsValidMove(board, col) && SimulateMove(board, col, color))
                {
                    return col; // return column if it leads to a win
                }
            }

            return null;
        }

        // Simulate a move for a specific color and check if it results in a win
        private bool SimulateMove(Button[,] board, int column, Color color)
        {
            for (int row = board.GetLength(0) - 1; row >= 0; row--)
            {
                if (board[row, column].ForeColor == Color.Black)
                {
                    board[row, column].ForeColor = color; // simulate the move
                    bool isWinningMove = CheckWin(board, color);
                    board[row, column].ForeColor = Color.Black; // undo the move
                    return isWinningMove;
                }
            }
            return false;
        }
        // Check if the move results in a win
        private bool CheckWin(Button[,] board, Color color)
        {
            return GameLogic.CheckWin(board, color);
        }

    }
}


