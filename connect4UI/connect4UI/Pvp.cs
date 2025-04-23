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
        private bool IsGameOver = false;
        private Player currentPlayer, player1, player2; 
        private int gameMode = 0;

        public Connect4PvP(int gamemode)
        {
            InitializeComponent();
            this.gameMode = gamemode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // initialize the board with buttons (row 0 is top, row 5 is bottom)
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    board[row, col] = (Button)this.Controls.Find($"Col{col}Row{row}", true)[0];
                }
            }

            

            foreach (var button in new[] { Col0Btn, Col1Btn, Col2Btn, Col3Btn, Col4Btn, Col5Btn, Col6Btn })
            {
                button.Click -= ColumnButton_Click;// unsubscribe just in case it's subscribed multiple times
                button.Click += ColumnButton_Click;

                // tag buttons to coordinate with column number
                button.Tag = Array.IndexOf(new[] { Col0Btn, Col1Btn, Col2Btn, Col3Btn, Col4Btn, Col5Btn, Col6Btn }, button);
            }

            if (currentPlayer == null)
            {
                CoinToss(0); //who plays first
                if (currentPlayer is AIPlayer) HandleAITurn(); // disable column buttons if AI's turn
            }
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CoinToss(int gametype)
        {
            int randomPlayer = RandomNumberGenerator();
            string strGameMode = "";

            if (randomPlayer == 0)
            {
                player1 = new HumanPlayer("Red Player",Color.Red);
                switch (gameMode)
                {
                    case 0:
                        player2 = new HumanPlayer("Yellow Player", Color.Yellow);
                        strGameMode = "Human v Human";
                        break;
                    case 1:
                        player2 = new AIPlayer("Yellow Player", Color.Yellow);
                        strGameMode = "Human v Easy AI";
                        break;
                    case 2:
                        player2 = new SmartAIPlayer("Yellow Player", Color.Yellow);
                        strGameMode = "Human v Hard AI";
                        break;
                    default:
                        throw new ArgumentException("Invalid game mode specified.");
                }
                MessageBox.Show("Red goes first! " + strGameMode);
                
                
            }
            else
            {
                switch (gameMode)
                {
                    case 0:
                        player2 = new HumanPlayer("Yellow Player", Color.Yellow);
                        strGameMode = "Human v Human";
                        break;
                    case 1:
                        player2 = new AIPlayer("Yellow Player", Color.Yellow);
                        strGameMode = "Human v Easy AI";
                        break;
                    case 2:
                        player2 = new SmartAIPlayer("Yellow Player", Color.Yellow);
                        strGameMode = "Human v Hard AI";
                        break;
                    default:
                        throw new ArgumentException("Invalid game mode specified.");
                }
                MessageBox.Show("Yellow goes first! " + strGameMode);
                player2 = new HumanPlayer("Red Player", Color.Red);
            }
            currentPlayer = player1;
        }

        private void ColumnButton_Click(object sender, EventArgs e)
        {
            
            int column;

            if (currentPlayer is HumanPlayer)
            {
                // get column from the clicked button's tag (human input)
                Button clickedButton = (Button)sender;
                column = Convert.ToInt32(clickedButton.Tag);
                Debug.WriteLine($"Human Player selects column: {column}");
            }
            else if (currentPlayer is AIPlayer aiPlayer)
            {
                // use AI logic to decide the column
                column = aiPlayer.MakeMove(board);
                Debug.WriteLine($"AI selects column: {column}");
            }
            else
            {
                throw new InvalidOperationException("Unknown player type.");
            }


            // do not allow more moves if game is over
            if (IsGameOver) 
            {
                return;
            }

            //try to make a move
            if (!MakeMove(column))
            {
                MessageBox.Show("Column is full. Choose another column.");
                return;
            }

            //check for win or draw
            if (CheckGameState()) return;


            //switch turn if valid move, no winner yet, not even a draw
            currentPlayer = (currentPlayer == player1) ? player2 : player1;


            //branch depending on player class
            if (currentPlayer is AIPlayer)
                HandleAITurn(); //let AI run it's playing algorithm
            else if (currentPlayer is HumanPlayer)
                SetColumnButtonsEnabled(true); //allow human to click to play
            else
                throw new InvalidOperationException("Unknown player type.");

        }

        private async void HandleAITurn()
        {
            if (currentPlayer is AIPlayer aiPlayer)
            {

                // do not allow more moves if game is over
                if (IsGameOver)
                {
                    return;
                }

                SetColumnButtonsEnabled(false); // prevent human from clicking while AI is thinking

                Random random = new Random();
                int delay = random.Next(800, 1800);
                await Task.Delay(delay); // simulate AI thinking

                int column = aiPlayer.MakeMove(board); // let AI decide its move
                Debug.WriteLine($"AI ({currentPlayer.Name}) chooses column {column}.");

                // make the move for the AI
                if (!MakeMove(column))
                {
                    MessageBox.Show("AI attempted an invalid move."); //I don't expect this to happen
                    return;
                }

                //check for win or draw
                if (CheckGameState()) return;

                //switch turn if valid move, no winner yet, not even a draw
                currentPlayer = (currentPlayer == player1) ? player2 : player1;

                //branch depending on player class
                if (currentPlayer is AIPlayer)
                    HandleAITurn(); //let AI run it's playing algorithm
                else if (currentPlayer is HumanPlayer)
                    SetColumnButtonsEnabled(true); //allow human to click to play
                else
                    throw new InvalidOperationException("Unknown player type.");
            }
        }


        private bool MakeMove(int column)
        {
            for (int row = 5; row >= 0; row--) // start from bottom row
            {
                Debug.WriteLine($"Checking Row: {row}, Column: {column}, Color: {board[row, column].BackColor}");
                if (board[row, column].BackColor == Color.Black)
                {
                    Debug.WriteLine($"Filling Row: {row}, Column: {column}");
                    board[row, column].BackColor = currentPlayer.TokenColor;  // fill the spot
                    return true;
                }
            }
            return false; //invalid move; full column
        }


        private bool CheckGameState()
        {
            
            if (CheckWin())
            {
                currentPlayer.Score++;
                MessageBox.Show($"{currentPlayer.Name} wins! Current score: {currentPlayer.Score}.");
                IsGameOver = true;
                return true;
            }

            
            if (CheckDraw())
            {
                MessageBox.Show("It's a draw!");
                IsGameOver = true;
                return true;
            }

            return false;
        }


        private bool CheckWin()
        {
            // please refer to GameLogic static class
            return GameLogic.CheckWin(board, currentPlayer.TokenColor);

        }

        private bool CheckDraw()
        {
            // please refer to GameLogic static class
            return GameLogic.CheckDraw(board);
        }

        private void SetColumnButtonsEnabled(bool isEnabled)
        {
            // enable or disable each button
            foreach (var button in new[] { Col0Btn, Col1Btn, Col2Btn, Col3Btn, Col4Btn, Col5Btn, Col6Btn })
            {
                button.Enabled = isEnabled; 
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

        private void Col6Row3_Click(object sender, EventArgs e)
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



