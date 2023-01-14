using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;



namespace SudokuSolver
{
    /// <summary>
    /// this module is for regular functions that will be used on the sudoku board
    /// </summary>
    public class Utils
    {

        /// <summary>
        /// this function prints out a sudoku board
        /// </summary>
        /// <param name="board">a matrix that represents a sudoku board</param>
        public static void PrintSudoku(int[][] board)
        {

            bool addZero = board.Length > 9;
            
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[0].Length; col++)
                {
                    //if the max value is bigger than 10 and the current number is less than 10, 0 needs to be added 
                    //in order to print correctly
                    if(addZero&& board[row][col]<10)
                        Console.Write("| 0" + (board[row][col]) + " |");

                    else
                        Console.Write("| " + (board[row][col]) + " |");
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
            for (int row = 0; row < mat.Length; row++)
            {
                for (int col = 0; col < mat[0].Length; col++)
                {
                    // doing -'0' to make the char its real value
                    mat[row][col] = sudoku[currentCharToRead]-'0';
                    currentCharToRead++;

                }
            }

            return mat;
        }

        /// <summary>
        /// this function recives a board and converts that btoard back to a string
        /// </summary>
        /// <param name="board">a matrix that represents a sudoku board</param>
        /// <returns>returns a string that represents the same sudoku board</returns>
        public static string ConvertMatToString(int[][] board)
        {
            char ch;
            string strToRet = "";
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[0].Length; col++)
                {
                    ch = (char)(board[row][col] + '0');
                    strToRet += ch;
                }
            }

            return strToRet;
        }



        /// <summary>
        /// this function is called from the main loop, it gets a string that represents a sudoku board, creates a matrix out of it, validates that matrix to see it got a logical 
        /// sudoku board, and solves that sudoku board
        /// </summary>
        /// <param name="sudoku">a string that represents a sudoku board</param>
        /// <returns>returns a string that represents the same sudoku board</returns>
        public static string ValidateAndSolveBoard(string sudoku)
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
            sudoku = s.Solve();

            //returning the solved sudoku board
            return sudoku;
        }

        
    }
}
