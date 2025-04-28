using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connect4UI.Properties;


namespace connect4UI
{


    public partial class Connect4PvP : Form
    {
        private Form titleForm;
        private Button[,] board = new Button[6, 7]; // board array 6 rows, 7 columns
        private bool IsGameOver = false;
        private Player currentPlayer, player1, player2;
        private int gameMode = 0;
        private int fallingCol;
        private int targetRow;
        private int currentRow;
        private Image fallingTokenImage;
        private Image EmptySpaceImage = Resources.EmptySapce;
        private Label TurnText;


        public Connect4PvP(int gameMode)
        {
            InitializeComponent();
            this.gameMode = gameMode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameBoard.Hide();

            if (currentPlayer == null)
            {
                CoinToss(); //who plays first
                if (currentPlayer is AIPlayer) HandleAITurn();
            }

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
                button.Click -= ColumnButton_Click; // unsubscribe just in case it's subscribed multiple times
                button.Click += ColumnButton_Click;

                // tag buttons to coordinate with column number
                button.Tag = Array.IndexOf(new[] { Col0Btn, Col1Btn, Col2Btn, Col3Btn, Col4Btn, Col5Btn, Col6Btn },
                    button);
            }

            if (currentPlayer == null)
            {
                CoinToss(); //who plays first
                if (currentPlayer is AIPlayer) HandleAITurn(); // disable column buttons if AI's turn
            }

            fallTimer = new Timer();
            fallTimer.Interval = 100; // or 50 ms for faster falling
            fallTimer.Tick += FallTimer_Tick;
            GameBoard.Show();
            UpdateTurnText();
        }


        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CoinToss()
        {
            int randomPlayer = RandomNumberGenerator();

            string strGameMode;

            if (randomPlayer == 0)
            {
                player1 = new HumanPlayer("Red Player", Color.Red, Resources.RedToken);
                currentPlayer = player1;


                switch (gameMode)
                {
                    case 0:
                        player2 = new HumanPlayer("Yellow Player", Color.Yellow, Resources.YellowToken);
                        strGameMode = "Human v Human";
                        break;
                    case 1:
                        player2 = new AIPlayer("Yellow Player", Color.Yellow, Resources.YellowToken);
                        strGameMode = "Human v Easy AI";
                        break;
                    case 2:
                        player2 = new SmartAIPlayer("Yellow Player", Color.Yellow, Resources.YellowToken);
                        strGameMode = "Human v Hard AI";
                        break;
                    default:
                        throw new ArgumentException("Invalid game mode specified.");
                }
            }
            else
            {
                player2 = new HumanPlayer("Yellow Player", Color.Yellow, Resources.YellowToken);
                currentPlayer = player1;

                switch (gameMode)
                {
                    case 0:
                        player1 = new HumanPlayer("Red Player", Color.Red, Resources.RedToken);
                        strGameMode = "Human v Human";
                        break;
                    case 1:
                        player1 = new AIPlayer("Red Player", Color.Red, Resources.RedToken);
                        strGameMode = "Human v Easy AI";
                        break;
                    case 2:
                        player1 = new SmartAIPlayer("Red Player", Color.Red, Resources.RedToken);
                        strGameMode = "Human v Hard AI";
                        break;
                    default:
                        throw new ArgumentException("Invalid game mode specified.");
                }
            }
        }

        private void UpdateTurnText()
        {
            if (currentPlayer != null && turnText != null)
            {
                turnText.Text = $"{currentPlayer.Name}'s Turn!";
                turnText.ForeColor = currentPlayer.TokenColor;
            }
        }


        private void ColumnButton_Click(object sender, EventArgs e)
        {
            // Disable column buttons immediately to prevent multiple clicks
            SetColumnButtonsEnabled(false);

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

            // Do not allow moves if game is over
            if (IsGameOver)
            {
                return;
            }

            int availableRow = FindAvailableRow(column);

            if (availableRow == -1)
            {
                MessageBox.Show("Column is full.");
                SetColumnButtonsEnabled(true); // re-enable buttons if column is full
                return;
            }

            // Set up falling token parameters
            fallingCol = column;
            targetRow = availableRow;
            currentRow = 0;
            fallingTokenImage = currentPlayer.TokenImage;

            fallTimer.Start(); // start token fall animation
        }

        private void FallTimer_Tick(object sender, EventArgs e)
        {
            if (currentRow > 0)
            {
                board[currentRow - 1, fallingCol].BackgroundImage = EmptySpaceImage;
                board[currentRow - 1, fallingCol].ForeColor = Color.Black;
            }

            board[currentRow, fallingCol].BackgroundImage = fallingTokenImage;
            board[currentRow, fallingCol].ForeColor = currentPlayer.TokenColor;

            if (currentRow == targetRow)
            {
                fallTimer.Stop();

                // After the token finishes falling, check for a win/draw
                if (CheckGameState()) return;

                // Switch turn after the token lands
                currentPlayer = (currentPlayer == player1) ? player2 : player1;
                UpdateTurnText();

                // Enable buttons for the next player to click
                if (currentPlayer is HumanPlayer)
                {
                    SetColumnButtonsEnabled(true);
                }
                else if (currentPlayer is AIPlayer)
                {
                    HandleAITurn(); // AI's turn to play
                }
            }
            else
            {
                currentRow++;
            }
        }


        private int FindAvailableRow(int column)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, column].ForeColor == Color.Black)
                {
                    return row;
                }
            }

            return -1; // column is full
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

                int column = aiPlayer.MakeMove(board); 
                Debug.WriteLine($"AI ({currentPlayer.Name}) chooses column {column}.");

                int availableRow = FindAvailableRow(column);
                if (availableRow == -1)
                {
                    MessageBox.Show("AI attempted an invalid move."); 
                    SetColumnButtonsEnabled(true); // allow human to play
                    return;
                }

                // Set up fall animation for the AI move
                fallingCol = column;
                targetRow = availableRow;
                currentRow = 0;
                fallingTokenImage = currentPlayer.TokenImage;

                fallTimer.Start(); // start the falling animation
            }
        }


        /*
        private bool MakeMove(int column)
        {
            for (int row = 5; row >= 0; row--) // start from bottom row
            {
                Debug.WriteLine($"Checking Row: {row}, Column: {column}, Color: {board[row, column].ForeColor}");
                if (board[row, column].ForeColor == Color.Black)
                {
                    Debug.WriteLine($"Filling Row: {row}, Column: {column}");
                    board[row, column].ForeColor = currentPlayer.TokenColor;
                    board[row, column].BackgroundImage = currentPlayer.TokenImage;


                    return true;
                }
            }
            return false; //invalid move; full column
        }
        */
        
        private bool CheckGameState()
        {

            if (CheckWin())
            {
                currentPlayer.Score++;

                if (currentPlayer != null && turnText != null)
                {
                    turnText.Text = $"{currentPlayer.Name} Wins!";
                    turnText.ForeColor = currentPlayer.TokenColor;
                }

                IsGameOver = true;
                PlayAgainPrompt();
                return true;
            }


            if (CheckDraw())
            {
                if (currentPlayer != null && turnText != null)
                {
                    turnText.Text = $"It's a draw!";
                    turnText.ForeColor = Color.White;
                }

                IsGameOver = true;
                PlayAgainPrompt();
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

        private void PlayAgainPrompt()
        {
            DialogResult result = MessageBox.Show("Play Again?", "Game Over", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ResetGame();
            }
            else
            {
                // Return to title screen
                this.Close();
            }
        }

        private void SetColumnButtonsEnabled(bool isEnabled)
        {
            foreach (var button in new[] { Col0Btn, Col1Btn, Col2Btn, Col3Btn, Col4Btn, Col5Btn, Col6Btn })
            {
                button.Enabled = isEnabled;
            }
        }

        private void ResetGame()
        {
            // Clear the board
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col].ForeColor = Color.Black;
                    board[row, col].BackgroundImage = Resources.EmptySapce;
                }
            }

            // Reset game state
            IsGameOver = false;

            // New coin toss
            Random rnd = new Random();
            bool redFirst = rnd.Next(2) == 0;

            if (redFirst)
            {
                currentPlayer = player1;
            }
            else
            {
                currentPlayer = player2;
            }

            // Update turn text
            turnText.Text = $"{currentPlayer.Name}'s Turn!";
            turnText.ForeColor = currentPlayer.TokenColor;

            if (currentPlayer is AIPlayer)
            {
                HandleAITurn();
            }
            else
            {
                SetColumnButtonsEnabled(true);
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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Col0Btn_MouseHover(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (currentPlayer.TokenColor == Color.Red)
            {
                btn.BackgroundImage = Resources.RedToken;

            }
            else
            {
                btn.BackgroundImage = Resources.YellowToken;
            }
        }
        private void Col0Btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = Resources.EmptySapce;
        }
        public Connect4PvP(Form titleForm, int gameMode)
        {
            InitializeComponent();
            this.titleForm = titleForm;
            this.gameMode = gameMode;
        }
        private void Connect4PvP_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void Connect4PvP_FormClosed(object sender, FormClosedEventArgs e)
        {
            titleForm.Show();
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
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



