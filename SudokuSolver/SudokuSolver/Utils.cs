using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static SudokuSolver.DancingLinksAlgo;

//this module is to store all of the different functions 

namespace SudokuSolver
{
    internal class Utils
    {

        /*public bool IsInRow(int row, int number, SudokuBoard board)
        {
            //this func returns wether or not a number is already in a row
            for (int i = 0; i < board.board_size; i++)
            {
                if (board.board[row,i] == number)
                    return true;
            }
            return false;
        }

        public bool IsInCol(int col, int number, SudokuBoard board)
        {
            //this func returns wether or not a number is already in a col
            for (int i = 0; i < board.board_size; i++)
            {
                if (board.board[i,col] == number)
                    return true;
            }
            return false;
        }

        public bool IsInBox(int row, int col, int number, SudokuBoard board)
        {
            //a function that returns if a placement of a number in a certain box is valid

            //these two operations are done to place the position at the start of the correct box
            int r = row - row % board.box_size;
            int c = col-col % board.box_size;

            for (int i = r; i < r+ board.box_size; i++)
            {
                for (int j = c; j < c+ board.box_size; j++)
                {
                    if (board.board[i,j] == number)
                        return true;
                }
            }

            return false;
        }

        public bool IsValid(int row, int col, int number, SudokuBoard board)
        {
            //a function that returns if a placement of a certain number in a certain place is valid
            return !IsInBox(row, col, number, board) && !IsInCol(col, number, board) && !IsInRow(row, number, board);
        }*/

        public static void PrintSudoku(int[][] mat)
        {

            bool addZero = mat.Length > 9;
            
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    //if the max value is bigger than 10 and the current number is less than 10, 0 needs to be added 
                    //in order to print correctly
                    if(addZero&& mat[i][j]<10)
                        Console.Write("| 0" + (mat[i][j]) + " |");

                    else
                        Console.Write("| " + (mat[i][j]) + " |");
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
        /// this function converts the result of the dancing links algo back to a sudoku board represented in a mamtix
        /// </summary>
        /// <param name="answer">is a list of dancing nodes that represent the solution</param>
        /// <param name="SIZE">size is the size of the board, needed to make the function generic</param>
        /// <returns></returns>
        public static int[][] ConvertDLXListToGrid(List<DancingNode> answer, int SIZE)
        {
          

            //init to the new solved grid
            int[][] solvedBoard = new int[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                solvedBoard[i] = new int[SIZE];
            }

            foreach (DancingNode node in answer)
            {
                DancingNode rcNode = node;
                int min = int.Parse(rcNode.column.name);

                for (DancingNode tmp = node.Right; tmp != node; tmp = tmp.Right)
                {
                    int val = int.Parse(tmp.column.name);

                    if (val < min)
                    {
                        min = val;
                        rcNode = tmp;
                    }
                }

                // we get line and column
                int ans1 = int.Parse(rcNode.column.name);
                int ans2 = int.Parse(rcNode.Right.column.name);
                int r = ans1 / SIZE;
                int c = ans1 % SIZE;
                // and the affected value
                int num = (ans2 % SIZE) + 1;
                // we affect that on the result grid
                solvedBoard[r][c] = num;
            }

            return solvedBoard;
        }

        /// <summary>
        /// this function is called from the main loop, it gets a string that represents a sudoku board, creates a matrix out of it, validates that matrix to see it got a logical 
        /// sudoku board, and solves that sudoku board
        /// </summary>
        /// <param name="sudoku">a string that represents a sudoku board</param>
        public static void ValidateAndSolveBoard(string sudoku)
        {
            //converting the string to a matrix
            int[][] board = Utils.ConvertStringToMat(sudoku);
            //validating the sudoku board
            Validation.validate(sudoku);
            //creagting an instance of the class Sudoku
            Sudoku s = new Sudoku(board);
            //solving the board
            s.Solve();
        }
    }
}
