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
            
            //this func prints the sudoku board
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    Console.Write("| " + (mat[i][j]) + " |");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");
        }

        public static int[][] ConvertStringToMat(string s)
        {
           
            //a function that converts a string to a matrix
            int size = (int)Math.Sqrt(s.Length);
            int[][] mat = new int[size][];
            for (int i = 0; i < size; i++)
                mat[i] = new int[size];
            int index = 0;
            
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    mat[i][j] = s[index]-'0';
                    index++;

                }
            }

            return mat;
        }

        public static int[][] ConvertDLXListToGrid(List<DancingNode> answer, int SIZE)
        {
            //this func recieves the answer to the solved sudoku in a list of dancingnodes
            //and converts that list back to a matrix of numbers

            //init to the new solved grid
            int[][] result = new int[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                result[i] = new int[SIZE];
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
                result[r][c] = num;
            }

            return result;
        }
    }
}
