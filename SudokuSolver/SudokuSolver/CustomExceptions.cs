using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SudokuSolver
{
    /// <summary>
    /// this module stores all of the Custom Exception of the program
    /// </summary>
    internal class CustomExceptions
    {

    }

    /// <summary>
    /// thrown when the size of the board cannot represent a valid sudoku board
    /// </summary>
    class InvalidBoardSizeException : Exception
    {
        public InvalidBoardSizeException(string msg) :base(msg){ }
    }

    /// <summary>
    /// thrown when there is an invalid char in the string
    /// </summary>
    class InvalidCharException : Exception
    {
        public InvalidCharException(string msg):base(msg) { }
    }

    /// <summary>
    /// thrown when the board isn't legal
    /// </summary>
    class InvalidInputException : Exception
    {
        public InvalidInputException(string msg):base(msg) { }
    }
}
