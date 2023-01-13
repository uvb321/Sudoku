using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;



namespace SudokuSolver
{
    /// <summary>
    /// this module is for regular functions that will be used on the sudoku board
    /// </summary>
    internal class Utils
    {

        /// <summary>
        /// this function prints out a sudoku board
        /// </summary>
        /// <param name="board">a matrix that represents a sudoku board</param>
        public static void PrintSudoku(int[][] board)
        {

            bool addZero = board.Length > 9;
            
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    //if the max value is bigger than 10 and the current number is less than 10, 0 needs to be added 
                    //in order to print correctly
                    if(addZero&& board[i][j]<10)
                        Console.Write("| 0" + (board[i][j]) + " |");

                    else
                        Console.Write("| " + (board[i][j]) + " |");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// this function converts a string to a sudoku board
        /// </summary>
        /// <param name="sudoku">a string that represents a sudoku board</param>
        /// <returns>it returns a matrix of int that represents a sudoku board</returns>
        public static int[][] ConvertStringToMat(string sudoku)
        {
            //the size of the sudoku board is the squre root of the length of the string
            int size = (int)Math.Sqrt(sudoku.Length);
            //init to the matrix that will be returned
            int[][] mat = new int[size][];
            for (int i = 0; i < size; i++)
                mat[i] = new int[size];

            //index that represents the current char that needs to be red from the string
            int currentCharToRead = 0;
            
            //double loop on the matrix to put the values in 
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    // doing -'0' to make the char its real value
                    mat[i][j] = sudoku[currentCharToRead]-'0';
                    currentCharToRead++;

                }
            }

            return mat;
        }

       

        /// <summary>
        /// this function is called from the main loop, it gets a string that represents a sudoku board, creates a matrix out of it, validates that matrix to see it got a logical 
        /// sudoku board, and solves that sudoku board
        /// </summary>
        /// <param name="sudoku">a string that represents a sudoku board</param>
        public static void ValidateAndSolveBoard(string sudoku)
        {

            //validating the string first
            Validation.ValidateString(sudoku);

            //converting the string to a matrix
            int[][] board = Utils.ConvertStringToMat(sudoku);

            //validating the sudoku board
            Validation.ValidateBoard(board);

            //creagting an instance of the class Sudoku
            Sudoku s = new Sudoku(board);
            //solving the board
            s.Solve();
        }
    }
}
