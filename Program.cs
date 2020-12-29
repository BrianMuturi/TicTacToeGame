using System;
public static class TicTacToeGame
{
    public static bool isPlayer1sTurn = true;
    public static Board board;
    public static int numberOfTurns = 0;
    static void Main()
    {
        //Instructions
        Console.WriteLine("Welcome to TicTacToe Game\n");
        Console.WriteLine("INSTRUCTIONS:\n");
        Console.WriteLine("1. Player can only play once");
        Console.WriteLine("2. Player can only input values 1-3 only\n\n");
        //Arguments

        while (true)
        {
            ResetBoard();
            PlayGame();
        }

        void ResetBoard()
        {
            board = new Board();
            numberOfTurns = 0;
            board.ShowBoard();
        }
        void PlayGame()
        {
            while (true)
            {
                board.ChooseRowThenSpace();
                board.ShowBoard();
                if (CheckForWinner())
                    break;
                isPlayer1sTurn = !isPlayer1sTurn;
                numberOfTurns++;
                if (numberOfTurns >= 9)
                {
                    Console.WriteLine("Invalid choice! Try again!!");
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to play again!!");
            Console.ReadKey(true);
        }
    }
    //Check for winner
    static bool CheckForWinner()
    {
        if (Horizontal() || Vertical() || Diagonal())
            return true;
        else return false;
        bool Horizontal()
        {
            for (int i = 0; i < board.rows.Length; ++i)
            {
                bool hasWon = true;
                bool isX = false;
                int[] spaces = board.rows[i].spaces;
                int checkHorizontal = spaces[0];
                switch (checkHorizontal)
                {
                    case 0:
                        continue;
                    case 1:
                        isX = true;
                        break;
                    case 2:
                        isX = false;
                        break;
                }
                for (int j = 0; j < spaces.Length; ++j)
                {
                    if (spaces[j] != checkHorizontal)
                    {
                        hasWon = false;
                        break;
                    }
                }
                if (hasWon)
                {
                    DisplayWinnerMessage(isX);
                    return true;
                }
            }
            return false;
        }
        bool Vertical()
        {
            bool hasWon = true;
            bool isX = false;
            int[] spaces = board.rows[0].spaces;
            for (int i = 0; i < 3; ++i)
            {
                hasWon = true;
                int checkVertical = spaces[i];
                switch (checkVertical)
                {
                    case 0:
                        continue;
                    case 1:
                        isX = true;
                        break;
                    case 2:
                        isX = false;
                        break;
                }
                for (int j = 0; j < 3; ++j)
                {
                    if (board.rows[j].spaces[i] != checkVertical)
                    {
                        hasWon = false;
                        break;
                    }
                }
                if (hasWon)
                {
                    DisplayWinnerMessage(isX);
                    return true;
                }
            }
            return false;
        }
        bool Diagonal()
        {
            bool hasWon = true;
            bool isX = false;
            int firstSpace = board.rows[0].spaces[0];
            switch (firstSpace)
            {
                case 0:
                    hasWon = false;
                    break;
                case 1:
                    isX = true;
                    break;
                case 2:
                    isX = false;
                    break;
            }
            for (int i = 0; i < 3; ++i)
            {
                if (board.rows[i].spaces[i] != firstSpace)
                {
                    hasWon = false;
                    break;
                }
            }
            if (hasWon)
            {
                DisplayWinnerMessage(isX);
                return true;
            }
            hasWon = true;
            int thirdSpace = board.rows[0].spaces[2];
            switch (thirdSpace)
            {
                case 0:
                    hasWon = false;
                    break;
                case 1:
                    isX = true;
                    break;
                case 2:
                    isX = false;
                    break;
            }
            for (int i = 0; i < 3; ++i)
            {
                if (board.rows[i].spaces[2 - i] != thirdSpace)
                {
                    hasWon = false;
                    break;
                }
            }
            if (hasWon)
            {
                DisplayWinnerMessage(isX);
                return true;
            }
            return false;
        }
        void DisplayWinnerMessage(bool isX)
        {
            string winnerIs = "";
            if (isX)
                winnerIs = " X's";
            else
                winnerIs = " O's";
            Console.WriteLine("The winner is " + winnerIs);
        }
    }
}
//Playing board properties
public class Board
{
    public Row[] rows;
    public Board()
    {
        rows = new Row[3];
        for (int i = 0; i < 3; i++)
            rows[i] = new Row();
    }
    public void ShowBoard()
    {
        for (int i = 0; i < rows.Length; ++i)
            rows[i].DisplayContents();
    }
    //User input
    public void ChooseRowThenSpace()
    {
        string input = "";
        int rowNumber = 0;
        Console.WriteLine("Type a row number from top to bottom (1, 2, or 3)");
        input = Console.ReadLine();
        if (int.TryParse(input, out rowNumber))
        {
            if (rowNumber > 3 || rowNumber < 1)
            {
                Console.WriteLine("Invalid row number. Please try again!!");
                ChooseRowThenSpace();
                return;
            }
            rows[rowNumber - 1].ChooseSpace(TicTacToeGame.isPlayer1sTurn);
        }
        else
        {
            Console.WriteLine("Invalid row number. Try again!!");
            ChooseRowThenSpace();
            return;
        }
    }
}
public class Row
{
    public int[] spaces;

    public void ChooseSpace(bool isX)
    {
        string input;
        int spaceNumber;
        Console.WriteLine("Type a space number from left to right (1, 2, or 3)");
        input = Console.ReadLine();
        if (int.TryParse(input, out spaceNumber))
        {
            if (spaceNumber > 3 || spaceNumber < 1)
            {
                Console.WriteLine("Invalid space number. Please try again!!");
                ChooseSpace(isX);
                return;
            }
            if (spaces[spaceNumber - 1] != 0)
            {
                Console.WriteLine("That space is occupied. Please choose another!!");
                TicTacToeGame.board.ChooseRowThenSpace();
                return;
            }

            if (isX)
                spaces[spaceNumber - 1] = 1;
            else
                spaces[spaceNumber - 1] = 2;
        }
        else
        {
            Console.WriteLine("Invalid space number. Try again!!");
            ChooseSpace(isX);
        }
    }
    //Display results

    public void DisplayContents()
    {
        string lineToWrite = "";
        for (int i = 0; i < spaces.Length; ++i)
        {
            if (spaces[i] == 0)
                lineToWrite += "|   |";
            else if (spaces[i] == 1)
                lineToWrite += "| X |";
            else if (spaces[i] == 2)
                lineToWrite += "| O |";
           
        }

        Console.WriteLine(lineToWrite);
    }

    public Row()
    {
        spaces = new int[3];
    }
}
        Console.WriteLine(lineToWrite);
    }

    public Row()
    {
        spaces = new int[3];
    }
}
