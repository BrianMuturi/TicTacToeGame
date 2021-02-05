using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
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
}
