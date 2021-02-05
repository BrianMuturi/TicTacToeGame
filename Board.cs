using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
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
}
