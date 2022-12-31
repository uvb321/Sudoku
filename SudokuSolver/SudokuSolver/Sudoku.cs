using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SudokuSolver
{
    internal class Sudoku
    {
        // Grid size
        private int SIZE;
        // Box size
        private int BOX_SIZE;
        private static int EMPTY_CELL = 0;
        // 4 constraints : cell, line, column, boxes
        private static int CONSTRAINTS = 4;
        // Values for each cells
        private static int MIN_VALUE = 1;
        private int MAX_VALUE;
        // Starting index for cover matrix
        private static int COVER_START_INDEX = 1;

        //represents board
        private int[][] grid;
        //represents solved board
        private int[][] gridSolved;

        public Sudoku(int[][] grid)
        {
            
            this.SIZE = grid.Length;
            this.BOX_SIZE = SIZE;
            this.MAX_VALUE = SIZE;

            this.grid = new int[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                this.grid[i] = new int[SIZE];
            }
        
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    this.grid[i][j] = grid[i][j];
        }

        public void Solve()
        {
            Utils.PrintSudoku(this.grid);
            int[][] coverMat = ConvertInCoverMatrix(this.grid);
            DancingLinksAlgo.DLX dlx = new DancingLinksAlgo.DLX(coverMat);
            dlx.process(0);
            this.gridSolved = Utils.ConvertDLXListToGrid(dlx.result, this.SIZE);
            Utils.PrintSudoku(this.gridSolved);
        }

      
        // Index in the cover matrix
        private int IndexInCoverMatrix(int row, int column, int num)
        {
            return (row - 1) * SIZE * SIZE + (column - 1) * SIZE + (num - 1);
        }

        // Building of an empty cover matrix
        private int[][] createCoverMatrix()
        {
            int[][] coverMatrix = new int[SIZE * SIZE * MAX_VALUE][];
            for (int i = 0; i < coverMatrix.Length; i++)
            {
                coverMatrix[i] = new int[SIZE * SIZE * CONSTRAINTS];
            }

            int header = 0;
            header = CreateCellConstraints(coverMatrix, header);
            header = CreateRowConstraints(coverMatrix, header);
            header = CreateColumnConstraints(coverMatrix, header);
            CreateBoxConstraints(coverMatrix, header);

            return coverMatrix;
        }

        private int CreateBoxConstraints(int[][] matrix, int header)
        {
            for (int row = COVER_START_INDEX; row <= SIZE; row += BOX_SIZE)
            {
                for (int column = COVER_START_INDEX; column <= SIZE; column += BOX_SIZE)
                {
                    for (int n = COVER_START_INDEX; n <= SIZE; n++, header++)
                    {
                        for (int rowDelta = 0; rowDelta < BOX_SIZE; rowDelta++)
                        {
                            for (int columnDelta = 0; columnDelta < BOX_SIZE; columnDelta++)
                            {
                                int index = IndexInCoverMatrix(row + rowDelta, column + columnDelta, n);
                                matrix[index][header] = 1;
                            }
                        }
                    }
                }
            }

            return header;
        }

        private int CreateColumnConstraints(int[][] matrix, int header)
        {
            for (int column = COVER_START_INDEX; column <= SIZE; column++)
            {
                for (int n = COVER_START_INDEX; n <= SIZE; n++, header++)
                {
                    for (int row = COVER_START_INDEX; row <= SIZE; row++)
                    {
                        int index = IndexInCoverMatrix(row, column, n);
                        matrix[index][header] = 1;
                    }
                }
            }

            return header;
        }

        private int CreateRowConstraints(int[][] matrix, int header)
        {
            for (int row = COVER_START_INDEX; row <= SIZE; row++)
            {
                for (int n = COVER_START_INDEX; n <= SIZE; n++, header++)
                {
                    for (int column = COVER_START_INDEX; column <= SIZE; column++)
                    {
                        int index = IndexInCoverMatrix(row, column, n);
                        matrix[index][header] = 1;
                    }
                }
            }

            return header;
        }

        private int CreateCellConstraints(int[][] matrix, int header)
        {
            for (int row = COVER_START_INDEX; row <= SIZE; row++)
            {
                for (int column = COVER_START_INDEX; column <= SIZE; column++, header++)
                {
                    for (int n = COVER_START_INDEX; n <= SIZE; n++)
                    {
                        int index = IndexInCoverMatrix(row, column, n);
                        matrix[index][header] = 1;
                    }
                }
            }

            return header;
        }

        // Converting Sudoku grid as a cover matrix
        private int[][] ConvertInCoverMatrix(int[][] grid)
        {
            int[][] coverMatrix = createCoverMatrix();

            // Taking into account the values already entered in Sudoku's grid instance
            for (int row = COVER_START_INDEX; row <= SIZE; row++)
            {
                for (int column = COVER_START_INDEX; column <= SIZE; column++)
                {
                    int n = grid[row - 1][column - 1];

                    if (n != EMPTY_CELL)
                    {
                        for (int num = MIN_VALUE; num <= MAX_VALUE; num++)
                        {
                            if (num != n)
                            {
                                //putting zeros to the array
                                Array.Clear(coverMatrix[IndexInCoverMatrix(row, column, num)], 0, coverMatrix[0].Length);
                            }
                        }
                    }
                }
            }

            return coverMatrix;
        }
    }
}
