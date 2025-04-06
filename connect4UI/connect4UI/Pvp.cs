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

    public partial class Connect4PvP : Form
    {
        private Button[,] board = new Button[6, 7]; // board array 6 rows, 7 columns
        private Color _currentPlayerColor = Color.Red; // Start with red
        private bool IsGameOver = false;

        public Connect4PvP()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Initialize the board with your buttons (row 0 is top, row 5 is bottom)
            board[0, 0] = Col0Row0;
            board[1, 0] = Col0Row1;
            board[2, 0] = Col0Row2;
            board[3, 0] = Col0Row3;
            board[4, 0] = Col0Row4;
            board[5, 0] = Col0Row5;

            board[0, 1] = Col1Row0;
            board[1, 1] = Col1Row1;
            board[2, 1] = Col1Row2;
            board[3, 1] = Col1Row3;
            board[4, 1] = Col1Row4;
            board[5, 1] = Col1Row5;

            board[0, 2] = Col2Row0;
            board[1, 2] = Col2Row1;
            board[2, 2] = Col2Row2;
            board[3, 2] = Col2Row3;
            board[4, 2] = Col2Row4;
            board[5, 2] = Col2Row5;

            board[0, 3] = Col3Row0;
            board[1, 3] = Col3Row1;
            board[2, 3] = Col3Row2;
            board[3, 3] = Col3Row3;
            board[4, 3] = Col3Row4;
            board[5, 3] = Col3Row5;

            board[0, 4] = Col4Row0;
            board[1, 4] = Col4Row1;
            board[2, 4] = Col4Row2;
            board[3, 4] = Col4Row3;
            board[4, 4] = Col4Row4;
            board[5, 4] = Col4Row5;

            board[0, 5] = Col5Row0;
            board[1, 5] = Col5Row1;
            board[2, 5] = Col5Row2;
            board[3, 5] = Col5Row3;
            board[4, 5] = Col5Row4;
            board[5, 5] = Col5Row5;

            board[0, 6] = Col6Row0;
            board[1, 6] = Col6Row1;
            board[2, 6] = Col6Row2;
            board[3, 6] = Col6Row3;
            board[4, 6] = Col6Row4;
            board[5, 6] = Col6Row5;

            // Tag buttons so we know which column each belongs to
            Col0Btn.Tag = 0;
            Col1Btn.Tag = 1;
            Col2Btn.Tag = 2;
            Col3Btn.Tag = 3;
            Col4Btn.Tag = 4;
            Col5Btn.Tag = 5;
            Col6Btn.Tag = 6;

            // Attach event handlers only once in this initialization step
            Col0Btn.Click -= ColumnButton_Click; // Unsubscribe just in case it's subscribed multiple times
            Col1Btn.Click -= ColumnButton_Click;
            Col2Btn.Click -= ColumnButton_Click;
            Col3Btn.Click -= ColumnButton_Click;
            Col4Btn.Click -= ColumnButton_Click;
            Col5Btn.Click -= ColumnButton_Click;
            Col6Btn.Click -= ColumnButton_Click;

            Col0Btn.Click += ColumnButton_Click;
            Col1Btn.Click += ColumnButton_Click;
            Col2Btn.Click += ColumnButton_Click;
            Col3Btn.Click += ColumnButton_Click;
            Col4Btn.Click += ColumnButton_Click;
            Col5Btn.Click += ColumnButton_Click;
            Col6Btn.Click += ColumnButton_Click;

            StartGame();
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StartGame()
        {
            int randomPlayer = RandomNumberGenerator();
            Player player1, player2;
            if (randomPlayer == 0)
            {
                player1 = new RedPlayer("Red Player", Color.Red, 0);
                MessageBox.Show("Red goes first!");
                player2 = new YellowPlayer("Yellow Player", Color.Yellow, 0);
            }
            else
            {
                player1 = new YellowPlayer("Yellow Player", Color.Yellow, 0);
                MessageBox.Show("Yellow goes first!");
                player2 = new RedPlayer("Red Player", Color.Red, 0);
            }
            _currentPlayerColor = player1.TokenColor;
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
                MessageBox.Show($"Player {_currentPlayerColor} wins!");
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
            _currentPlayerColor = (_currentPlayerColor == Color.Red) ? Color.Yellow : Color.Red;  // Switch players
        }

        private bool MakeMove(int column)
        {
            for (int row = 5; row >= 0; row--) // start from bottom row
            {
                Debug.WriteLine($"Checking Row: {row}, Column: {column}, Color: {board[row, column].BackColor}");
                if (board[row, column].BackColor == Color.White)
                {
                    Debug.WriteLine($"Filling Row: {row}, Column: {column}");
                    board[row, column].BackColor = _currentPlayerColor;  // fill the spot
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
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 4; col++) // Only check up to column 4
                {
                    if (board[row, col].BackColor == _currentPlayerColor &&
                        board[row, col + 1].BackColor == _currentPlayerColor &&
                        board[row, col + 2].BackColor == _currentPlayerColor &&
                        board[row, col + 3].BackColor == _currentPlayerColor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckVerticalWin()
        {
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < 3; row++) // Only check up to row 3
                {
                    if (board[row, col].BackColor == _currentPlayerColor &&
                        board[row + 1, col].BackColor == _currentPlayerColor &&
                        board[row + 2, col].BackColor == _currentPlayerColor &&
                        board[row + 3, col].BackColor == _currentPlayerColor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckDiagonalWin()
        {
            // Check for diagonal wins (both directions)
            for (int row = 0; row <= 5; row++)
            {
                for (int col = 0; col <=6 ; col++)
                {
                    // Check diagonal down-right
                    if (row <= 2 && col <= 3 &&
                        board[row, col].BackColor == _currentPlayerColor &&
                        board[row + 1, col + 1].BackColor == _currentPlayerColor &&
                        board[row + 2, col + 2].BackColor == _currentPlayerColor &&
                        board[row + 3, col + 3].BackColor == _currentPlayerColor)

                    {
                        return true;
                    }

                    // Check diagonal down-left
                    if (row <= 2 && col >= 3 &&
                        board[row, col].BackColor == _currentPlayerColor &&
                        board[row + 1, col - 1].BackColor == _currentPlayerColor &&
                        board[row + 2, col - 2].BackColor == _currentPlayerColor &&
                        board[row + 3, col - 3].BackColor == _currentPlayerColor) 
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



        public class Player
        {
            public string Name;
            public Color TokenColor;
            public int Score;


            public Player(string name, Color tokenColor, int score)
            {
                Name = name;
                TokenColor = tokenColor;
                Score = score;

            }

        }

        public class RedPlayer : Player
        {
            public RedPlayer(string name, Color tokenColor, int score) : base(name, tokenColor, score)
            {
                Name = "Red Player";
                TokenColor = Color.Red;
                Score = 0;
            }
        }

        public class YellowPlayer : Player
        {
            public YellowPlayer(string name, Color tokenColor, int score) : base(name, tokenColor, score)
            {
                Name = "Yellow Player";
                TokenColor = Color.Yellow;
                Score = 0;
            }
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



