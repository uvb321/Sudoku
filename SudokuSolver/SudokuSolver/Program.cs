using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SudokuSolver
{
    /// <summary>
    /// this is the main program that the whole sudoku solver will be ran from
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //main to run
            Messages.Welcome_Message();
            MainLoop.Main_Loop();
        }

    }
}
