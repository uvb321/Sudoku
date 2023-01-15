using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SudokuSolver
{
    /// <summary>
    /// this module is for printing different messages to the screen
    /// </summary>
    internal class Messages
    {
        /// <summary>
        /// prints the welcome message to the screen
        /// </summary>
        public static void Welcome_Message()
        {
            Console.WriteLine("welcome to sudoku solver, you can enter a sudoku puzzle in two ways:\n" +
                "1: by hand, writing a string with 0 for empty cells.\n" +
                "2: by file, passing a file to the program to read. the result will also be stored in the file" +
                "");
        }

        /// <summary>
        /// prints the loop message to the screen
        /// </summary>
        public static void Loop_Message()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("please enter according to the following instructions:\n" +
                "1. input 1 to input a puzzle by hand.\n" +
                "2. input 2 to input a puzzle by file.\n" +
                "0. input 0 to close the program.");
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("pleae enter your choice: ");

        }


    }
}
