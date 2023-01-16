using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SudokuSolver
{
    /// <summary>
    /// this module stores all of the functions that validate the input from the user
    /// </summary>
    internal class Validation
    {
        /// <summary>
        /// this function validates the sudoku board using a hash set of string and comparing every value with each constraint
        /// </summary>
        /// <param name="board">a matrix that represents a sudoku board</param>
        public static void ValidateBoard(int[][] board)
        {
            //a hashset that will tell if a number is conflicted
            HashSet<string> seenVals = new HashSet<string>();

            int boxSize = (int)Math.Sqrt(board.Length);

            //loop on the rows of the board
            for (int row = 0; row < board.Length; row++)
            {
                //loop on the cols of each board
                for (int col = 0; col < board.Length; col++)
                {
                    int currentVal = board[row][col];
                    //if the item isn't an empty cell
                    if (currentVal != 0)
                    {
                        if(!seenVals.Add(currentVal + " found in row " + row))
                            throw new InvalidBoardException(string.Format("can't have more than one {0} in the same row, row number: {1}", currentVal, row + 1));
                        else if(!seenVals.Add(currentVal + " found in col " + col))
                            throw new InvalidBoardException(string.Format("can't have more than one {0} in the same column, column number: {1}", currentVal, col + 1));
                        else if(!seenVals.Add(currentVal + " in block " + row / boxSize + "-" + col / boxSize))
                            throw new InvalidBoardException(string.Format("can't have more than one {0} in the same box, box: {1}-{2}", currentVal, (row / boxSize) + 1, (col / boxSize) + 1));


                    }
                }
            }
        }

        
        /// <summary>
        /// this function validates the string that reprsents the sudoku board
        /// </summary>
        /// <param name="sudoku">a string that represents a sudoku board</param>
        /// <exception cref="InvalidBoardSizeException"></exception>
        public static void ValidateString(string sudoku)
        {
            //if string is empty
            if (sudoku == null)
                throw new InvalidCharException("Can't get null as input");

            //if empty string
            if (sudoku == "")
                throw new InvalidBoardSizeException("can't get an empty board as input");


            //if the length of the string is bigger than 625 than throw an exception
            if (sudoku.Length > 625)
                throw new InvalidBoardSizeException("can't get a board larger than 25X25");


            //finding the length of the board
            double size = Math.Sqrt(sudoku.Length);
            //if it contains a dot in it, it is not a natural number, therefore it is an invalid board
            bool isValid =  !(size.ToString().Contains("."));
            if (!isValid)
                throw new InvalidBoardSizeException("recievd a board with illegal size");

            //a max value in a sudoku board is as large as the size of the sudoku board
            int maxValue = (int)size +'0';

            //checking for illegal chars
            foreach(char currChar in sudoku) 
            {
                //checking if a char in the string is bigger than the max value or smaller than '0'
                if (currChar > maxValue || currChar < '0')
                    throw new InvalidCharException(string.Format("the char {0} is not legal in this sudoku board",currChar));
            }
        }

    }
}
