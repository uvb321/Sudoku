using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SudokuSolver
{
    /// <summary>
    /// this class represents a sudoku board
    /// </summary>
    internal class Sudoku
    {
        // Grid size
        private int SIZE;
        // Box size
        private int BOX_SIZE;
        private static int EMPTY_CELL = 0;
        // Values for each cells
        private static int MIN_VALUE = 1;
        private int MAX_VALUE;

        //represents board
        private int[][] board;
        //represents solved board
        private int[][] solvedBoard;

        public Sudoku(int[][] board)
        {
            //init to the attributes 
            //the size of the board is the is how many rows there are in the matrix
            this.SIZE = board.Length;
            //the box size is the square root of the length of the board
            this.BOX_SIZE = (int)Math.Sqrt(SIZE);
            //the max value in the board is as big as the length of the board
            this.MAX_VALUE = SIZE;
            this.board = board;


        }

        /// <summary>
        /// this function prints the board, start a stopwatch, turns the board into a cover matrix, solves the cover natrix,
        //  converts the solved cover matrix back to a regular matrix and prints it
        /// </summary>
        public string Solve()
        {
            //printing the unsolved sudoku
            Utils.PrintSudoku(this.board);

            //creating a stopwatch for the time measurement 
            Stopwatch sw = new Stopwatch();

            //starting the stopwatch here
            sw.Start();
            
            //creating a cover matrix from the board
            int[][] coverMat = ConvertInCoverMatrix();

            //creating a dancing links matrix from the cover matrix
            DancingLinksAlgo.DLX dlx = new DancingLinksAlgo.DLX(coverMat);

            //solving the dancing links matrix
            bool didSolve = dlx.SolveDLX(0);

            //stopping the stopwatch now that all of the solving processes are complete
            sw.Stop();

            Console.WriteLine("-------------------------------\n reached answer in: {0}ms\n-------------------------------", sw.ElapsedMilliseconds);
            //if board was solved
            if (didSolve)
            {
                //converting the answer back to a normal sudoku grid
                this.solvedBoard = dlx.ConvertDLXListToGrid(this.SIZE);

                //printing the solved sudoku grid
                Console.WriteLine("\nsolved board:\n");
                Utils.PrintSudoku(this.solvedBoard);

                //converting the solved board back to a string
                string SolvedSudokuStr = Utils.ConvertMatToString(this.solvedBoard);
                //printing that string
                Console.WriteLine("the string of the solved sudoku board: "+SolvedSudokuStr);

                //returning the solved sudoku string
                return SolvedSudokuStr;

            }
            //else
            else
            {
                Console.WriteLine("\ncouldn't solve the board\n");
                //returning "" if no solution was found
                return "";
            }
        }

      
        /// <summary>
        /// this function returns the relative place in the cover matrix based on the place in the board
        /// </summary>
        /// <param name="row">current row in the board</param>
        /// <param name="column">current column in the board</param>
        /// <param name="num">current value of the cell in the board</param>
        /// <returns></returns>
        private int IndexInCoverMatrix(int row, int column, int num)
        {
            return (row - 1) * SIZE * SIZE + (column - 1) * SIZE + (num - 1);
        }

        /// <summary>
        /// this function builds the cover matrix based on the board 
        /// </summary>
        /// <returns>it returns the cover matrix that was created</returns>
        private int[][] CreateCoverMatrix()
        {
            //init to the cover matrix
            int[][] coverMatrix = new int[SIZE * SIZE * MAX_VALUE][];
            for (int i = 0; i < coverMatrix.Length; i++)
            {
                //there are 4 constrains in a sudoku board: row, column, box and cell
                coverMatrix[i] = new int[SIZE * SIZE * 4];
            }

            int header = 0;
            //creating cell constrains
            header = CreateCellConstraints(coverMatrix, header);
            //creatins row constrains
            header = CreateRowConstraints(coverMatrix, header);
            //creating column constrains
            header = CreateColumnConstraints(coverMatrix, header);
            //creating box constrains
            CreateBoxConstraints(coverMatrix, header);
            //returning the cover matrix
            return coverMatrix;
        }
       /// <summary>
       /// this function creates the box constrains for the cover matrix
       /// </summary>
       /// <param name="coverMatrix">this is the cover matrix that the constrains will work on</param>
       /// <param name="header"></param>
       /// <returns>returns the header</returns>
        private int CreateBoxConstraints(int[][] coverMatrix, int header)
        {
            for (int row = 1; row <= SIZE; row += BOX_SIZE)
            {
                for (int column = 1; column <= SIZE; column += BOX_SIZE)
                {
                    for (int num = 1; num <= SIZE; num++, header++)
                    {
                        for (int rowDelta = 0; rowDelta < BOX_SIZE; rowDelta++)
                        {
                            for (int columnDelta = 0; columnDelta < BOX_SIZE; columnDelta++)
                            {
                                int index = IndexInCoverMatrix(row + rowDelta, column + columnDelta, num);
                                coverMatrix[index][header] = 1;
                            }
                        }
                    }
                }
            }

            return header;
        }
      
        /// <summary>
        /// this function creates the column constrains in the cover matrix
        /// </summary>
        /// <param name="coverMatrix">this is the cover matrix</param>
        /// <param name="header"></param>
        /// <returns>returns the header</returns>
        private int CreateColumnConstraints(int[][] coverMatrix, int header)
        {
            for (int column = 1; column <= SIZE; column++)
            {
                for (int num = 1; num <= SIZE; num++, header++)
                {
                    for (int row = 1; row <= SIZE; row++)
                    {
                        int index = IndexInCoverMatrix(row, column, num);
                        coverMatrix[index][header] = 1;
                    }
                }
            }

            return header;
        }
        /// <summary>
        /// this function creates the row constrains in the cover matrix
        /// </summary>
        /// <param name="coverMatrix">this is the cover matrix</param>
        /// <param name="header"></param>
        /// <returns>returns the header</returns>
        private int CreateRowConstraints(int[][] coverMatrix, int header)
        {
            for (int row = 1; row <= SIZE; row++)
            {
                for (int num = 1; num <= SIZE; num++, header++)
                {
                    for (int column = 1; column <= SIZE; column++)
                    {
                        int index = IndexInCoverMatrix(row, column, num);
                        coverMatrix[index][header] = 1;
                    }
                }
            }

            return header;
        }

        /// <summary>
        /// this function creates the cell constrains for the cover matrix
        /// </summary>
        /// <param name="coverMatrix">this is the cover matrix</param>
        /// <param name="header">header is the start index of each column in the cover matrix</param>
        /// <returns>returns the header</returns>
        private int CreateCellConstraints(int[][] coverMatrix, int header)
        {
            for (int row = 1; row <= SIZE; row++)
            {
                for (int column = 1; column <= SIZE; column++, header++)
                {
                    for (int num = 1; num <= SIZE; num++)
                    {
                        int index = IndexInCoverMatrix(row, column, num);
                        coverMatrix[index][header] = 1;
                    }
                }
            }

            return header;
        }

        /// <summary>
        /// this is the main function, it creates the complete cover matrix 
        /// </summary>
        /// <returns>returns the complete cover matrix</returns>
        private int[][] ConvertInCoverMatrix()
        {
            int[][] coverMatrix = CreateCoverMatrix();
            // Taking into account the values already entered in Sudoku's grid instance
            for (int row = 1; row <= SIZE; row++)
            {
                for (int column = 1; column <= SIZE; column++)
                {
                    int currentValue = this.board[row-1][column-1];

                    //if the current value isn't an empty cell
                    if (currentValue!= EMPTY_CELL)
                    {
                        for (int num = MIN_VALUE; num <= MAX_VALUE; num++)
                        {

                            //if the current num doesn't equal the current value the respective row in the cover matrix should be filled with 0's
                            if (num != currentValue)
                            {
                                //putting zeros to the array if the number doesn't equal the current value
                                int rowToFill = IndexInCoverMatrix(row, column, num);
                                for (int col = 0; col  < coverMatrix[0].Length; col++)
                                {
                                    coverMatrix[rowToFill][col] = 0;
                                }
                            }
                        }
                    }
                }
            }
            //returning the complete cover matrix
            return coverMatrix;
        }
    }
}
