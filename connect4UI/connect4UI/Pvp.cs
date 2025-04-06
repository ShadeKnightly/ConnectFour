using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connect4UI.Properties;


namespace connect4UI
{
    public class Player
    {
        public string Name;
        public Color TokenColor;
        public int Score;

        public Player(string name, Color tokenColor, int score=0)
        {
            Name = name;
            TokenColor = tokenColor;
            Score = score;
        }

    }

    public class RedPlayer : Player
    {
        public RedPlayer() : base("Red Player", Color.Red)
        {
        }
    }

    public class YellowPlayer : Player
    {
        public YellowPlayer() : base("Yellow Player", Color.Yellow)
        {
        }
    }




    public partial class Connect4PvP : Form
    {
        private Button[,] board = new Button[6, 7]; // board array 6 rows, 7 columns
        //private Color _currentPlayerColor = Color.Red; // Start with red
        private bool IsGameOver = false;
        private Player currentPlayer, player1, player2; 

        public Connect4PvP()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Initialize the board with your buttons (row 0 is top, row 5 is bottom)
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    board[row, col] = (Button)this.Controls.Find($"Col{col}Row{row}", true)[0];
                }
            }

            foreach (var button in new[] { Col0Btn, Col1Btn, Col2Btn, Col3Btn, Col4Btn, Col5Btn, Col6Btn })
            {
                // Attach event handlers only once in this initialization step
                button.Click -= ColumnButton_Click;// Unsubscribe just in case it's subscribed multiple times
                button.Click += ColumnButton_Click;

                // Tag buttons so we know which column each belongs to
                button.Tag = Array.IndexOf(new[] { Col0Btn, Col1Btn, Col2Btn, Col3Btn, Col4Btn, Col5Btn, Col6Btn }, button);
            }

            if (currentPlayer == null) CoinToss();
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CoinToss()
        {
            int randomPlayer = RandomNumberGenerator();
            if (randomPlayer == 0)
            {
                player1 = new RedPlayer();
                MessageBox.Show("Red goes first!");
                player2 = new YellowPlayer();
            }
            else
            {
                player1 = new YellowPlayer();
                MessageBox.Show("Yellow goes first!");
                player2 = new RedPlayer();
            }
            currentPlayer = player1;
        }

        private void ColumnButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int column = Convert.ToInt32(clickedButton.Tag); // Get the column number


            // Print out the column number and the rows being checked
            Debug.WriteLine($"Column: {column} clicked");

            // Do not allow more moves if game is over
            if (IsGameOver) 
            {
                return;
            }

            // Try to make the move
            if (!MakeMove(column))
            {
                MessageBox.Show("Column is full. Choose another column.");
                return;
            }

            // Check for a winner
            if (CheckWin())
            {
                currentPlayer.Score++;

                MessageBox.Show($"{currentPlayer.Name} wins! Current score: {currentPlayer.Score}.");
                IsGameOver = true;
                return;
            }

            if (CheckDraw())
            {
                MessageBox.Show("It's a draw!");
                IsGameOver = true;
                return;
            }


            // If valid move, no winner yet, not even a draw, let other player have a turn
            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }

        private bool MakeMove(int column)
        {
            for (int row = 5; row >= 0; row--) // start from bottom row
            {
                Debug.WriteLine($"Checking Row: {row}, Column: {column}, Color: {board[row, column].BackColor}");
                if (board[row, column].BackColor == Color.White)
                {
                    Debug.WriteLine($"Filling Row: {row}, Column: {column}");
                    board[row, column].BackColor = currentPlayer.TokenColor;  // fill the spot
                    return true;
                }
            }
            return false; //invalid move; full column
        }

        private bool CheckWin()
        {
            // Check horizontal, vertical, and diagonal directions for a win
            return CheckHorizontalWin() || CheckVerticalWin() || CheckDiagonalWin();
        }

        private bool CheckHorizontalWin()
        {
            var currColor = currentPlayer.TokenColor;
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 4; col++) // Only check up to column 4
                {
                    if (board[row, col].BackColor == currColor &&
                        board[row, col + 1].BackColor == currColor &&
                        board[row, col + 2].BackColor == currColor &&
                        board[row, col + 3].BackColor == currColor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckVerticalWin()
        {
            var currColor = currentPlayer.TokenColor;
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < 3; row++) // Only check up to row 3
                {
                    if (board[row, col].BackColor == currColor &&
                        board[row + 1, col].BackColor == currColor &&
                        board[row + 2, col].BackColor == currColor &&
                        board[row + 3, col].BackColor == currColor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckDiagonalWin()
        {
            var currColor = currentPlayer.TokenColor;
            // Check for diagonal wins (both directions)
            for (int row = 0; row <= 5; row++)
            {
                for (int col = 0; col <=6 ; col++)
                {
                    // Check diagonal down-right
                    if (row <= 2 && col <= 3 &&
                        board[row, col].BackColor == currColor &&
                        board[row + 1, col + 1].BackColor == currColor &&
                        board[row + 2, col + 2].BackColor == currColor &&
                        board[row + 3, col + 3].BackColor == currColor)

                    {
                        return true;
                    }

                    // Check diagonal down-left
                    if (row <= 2 && col >= 3 &&
                        board[row, col].BackColor == currColor &&
                        board[row + 1, col - 1].BackColor == currColor &&
                        board[row + 2, col - 2].BackColor == currColor &&
                        board[row + 3, col - 3].BackColor == currColor) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckDraw()
        {
            foreach (var cell in board)
            {
                if (cell.BackColor == Color.White) return false; //still unplayed slots
            }
            return true;
        }



        

        private int RandomNumberGenerator()
        {
            Random rnd = new Random();

            var num = rnd.Next(2);

            return num;
        }



        


        private void Col0Row0_Click(object sender, EventArgs e)
        {

        }


        private void Col0Row1_Click(object sender, EventArgs e)
        {

        }

        private void Col0Row2_Click(object sender, EventArgs e)
        {

        }

        private void Col0Row3_Click(object sender, EventArgs e)
        {

        }

        private void Col0Row4_Click(object sender, EventArgs e)
        {

        }

        private void Col0Row5_Click(object sender, EventArgs e)
        {

        }

    }
}



