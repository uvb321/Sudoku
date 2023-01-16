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
    public class FileHandler
    {
        /// <summary>
        /// this function reads a given file a returns its content
        /// </summary>
        /// <param name="txtFilePath">the absolute path of the .txt file to read</param>
        /// <returns>returns the string that represents the sudoku board inside of the given path</returns>
        /// <exception cref="FileException">thrown when there is a problem dealing with a file</exception>
        public static string ReadFile(string txtFilePath)
        {
            //checking if path is null
            if (txtFilePath == null)
                throw new FileException("Can't get null as a file path");

            //checking if path is empty
            if (txtFilePath == "")
                throw new FileException("Can't get empty string as file path");

            //string to return
            string sudoku = "";

            if (!txtFilePath.EndsWith(".txt"))
                throw new FileException(String.Format("The file {0} isn't a txt file", txtFilePath));

           
            
            //trying to read the files data to the sudoku string
            
            if (File.Exists(txtFilePath))
            {
                try
                {
                    sudoku = File.ReadAllText(txtFilePath);
                }
                catch (Exception)
                {
                    throw new FileException(string.Format("a problem occurred while dealing with the file {0}", txtFilePath));
                }

            }
            else
            {
                throw new FileException(string.Format("couldn't locate the {0} file",txtFilePath));
            }

            return sudoku;
        }

        /// <summary>
        /// this function write the sudoku string to the file
        /// </summary>
        /// <param name="txtFilePath">absolute path of the .txt file</param>
        /// <param name="sudokuSolution">a string that represents a sudoku solution</param>
        /// <exception cref="FileException">thrown if a problem occurred while writing to the file</exception>
        public static void WriteFile(string txtFilePath, string sudokuSolution)
        {
            try
            {
                File.WriteAllText(txtFilePath, sudokuSolution);
            }
            catch (Exception)
            {
                throw new FileException(string.Format("an error occurred when writing to the {0} file", txtFilePath));
            }

            
        }

    }
}
