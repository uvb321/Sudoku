using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    /// <summary>
    /// this module is responsible to all of the action on files
    /// </summary>
    internal class FileHandler
    {
        /// <summary>
        /// this function reads a given file a returns its content
        /// </summary>
        /// <param name="txtFile">the name of the file to read</param>
        /// <returns>returns the string inside of a file</returns>
        /// <exception cref="FileException">thrown when there is a problem dealing with a file</exception>
        public static string ReadFile(string txtFile)
        {
            string sudoku = "";
            //trying to read the files data to the sudoku string
            if (File.Exists("../../" + txtFile))
            {
                try
                {
                    sudoku = File.ReadAllText("../../" + txtFile);
                }
                catch (Exception)
                {
                    throw new FileException(string.Format("a problem occurred while dealing with the file {0}", txtFile));
                }

            }
            else
            {
                throw new FileException(string.Format("couldn't locate the {0} file",txtFile));
            }

            return sudoku;
        }

        /// <summary>
        /// this function write the sudoku string to the file
        /// </summary>
        /// <param name="txtFile">name of the file</param>
        /// <param name="sudokuSolution">a strign that represents a sudoku solution</param>
        /// <exception cref="FileException">thrown if a problem occurred while wrtining to the file</exception>
        public static void WriteFile(string txtFile, string sudokuSolution)
        {
            try
            {
                File.AppendAllText("../../" + txtFile, "\n"+sudokuSolution);
            }
            catch (Exception)
            {
                throw new FileException(string.Format("an error occurred when writing to the {0} file", txtFile));
            }

            
        }

    }
}
