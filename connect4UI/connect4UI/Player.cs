using System;
using System.Drawing;
using System.Windows.Forms;
using connect4UI;


public interface IPlayer
{
    string Name { get; }
    Color TokenColor { get; }
    int Score { get; set; }
    int MakeMove(Button[,] board); //return column player wants to put their token
}


public abstract class Player : IPlayer
{
    public string Name { get; }
    public Color TokenColor { get; }
    public int Score { get; set; }

    protected Player(string name, Color col) 
    {
        Name = name;
        TokenColor = col;
        Score = 0; // no need for score, it will be set to 0 by default
    }

    public abstract int MakeMove(Button[,] board); //need abstract so human and AI can implement their different logic
}


public class HumanPlayer : Player
{
    public HumanPlayer(string name, Color col) : base(name, col) { }

    public override int MakeMove(Button[,] board)
    {
        throw new NotImplementedException("Human moves are handled by UI event."); //handled by button click event handler
    }
}

public class AIPlayer : Player
{
    public AIPlayer(string name, Color col) : base(name, col) { }

    public override int MakeMove(Button[,] board)
    {

        int randomColumn = new Random().Next(7);
        return randomColumn; // simplest AI move is random pick
    }
}

public class SmartAIPlayer : AIPlayer
{
    private static Random rnd = new Random(); // Reuse a single Random instance

    public SmartAIPlayer(string name, Color col) : base(name, col) { }

    public override int MakeMove(Button[,] board)
    {
        // Define opponent color
        Color opponentColor = (TokenColor == Color.Red) ? Color.Yellow : Color.Red;

        // Prioritize winning, blocking, or random moves
        int column = FindWinningMove(board, TokenColor) ??
                     FindWinningMove(board, opponentColor) ??
                     ChooseRandomColumn(board);

        return column;
    }

    private int? FindWinningMove(Button[,] board, Color color) //? indicates int can be null, useful to return null if no winning move is found
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            if (IsValidMove(board, col) && SimulateMove(board, col, color))
            {
                return col;
            }
        }
        return null;
    }

    private bool SimulateMove(Button[,] board, int column, Color color)
    {
        for (int row = board.GetLength(0) - 1; row >= 0; row--)
        {
            if (board[row, column].BackColor == Color.White)
            {
                board[row, column].BackColor = color; // simulate move 
                bool isWinningMove = CheckWin(board, color); //check if it’s a winning move
                board[row, column].BackColor = Color.White; // undo move and report back result
                return isWinningMove;
            }
        }
        return false;
    }

    private bool IsValidMove(Button[,] board, int column)
    {
        return board[0, column].BackColor == Color.White; // make sure column isn’t full
    }

    private int ChooseRandomColumn(Button[,] board)
    {
        int column;
        do
        {
            column = rnd.Next(board.GetLength(1));
        } while (!IsValidMove(board, column));
        return column;
    }



    private bool CheckWin(Button[,] board, Color color)
    {
        return GameLogic.CheckWin(board, color);
    }
}



