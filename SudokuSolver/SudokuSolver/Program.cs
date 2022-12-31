using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*//main to run
            Messages.Welcome_Message();
            MainLoop.Main_Loop();*/
            string str = "800000070006010053040600000000080400003000700020005038000000800004050061900002000";
            int[][] board = Utils.ConvertStringToMat(str);
            Sudoku s = new Sudoku(board);
            s.Solve();
           
        }

    }
}
