using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace SudokuSolver
{
    /// <summary>
    /// this module is the main loop of the program
    /// </summary>
    internal class MainLoop
    {
        public static void Main_Loop()
        {
            //these following three lines enables the program to recieve more than 254 chars from the console
            int READLINE_BUFFER_SIZE = 700;
            Stream inputStream = Console.OpenStandardInput(READLINE_BUFFER_SIZE);
            Console.SetIn(new StreamReader(inputStream));

            //init to params
            string sudoku;
            string txtFile;
            int choice;

            while (true){
                sudoku = "";
                txtFile = "";

                Console.WriteLine("\n\n");
                Messages.Loop_Message();
                
                choice = -1;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch(FormatException FE) { }

                Console.WriteLine("-------------------------------------------------------------");
                //finishing the program
                if (choice == 0)
                    break;

                else if(choice == 1|| choice == 2)
                {
                    //if input by hand chosen
                    if (choice == 1)
                    {
                        Console.WriteLine("please enter a string that represent a sudoku board below: \n");
                        //getting sudoku from console
                        sudoku = Console.ReadLine();

                    }
                       
                    try
                    {
                        //if input from file chosen
                        if (choice == 2)
                        {
                            //reading the name of the text file
                            Console.WriteLine("please enter the text file to read the board from below, please make sure to add .txt at the end: \n");
                            txtFile = Console.ReadLine();
                            sudoku = FileHandler.ReadFile(txtFile);

                        }

                        //solving and printing the sudoku
                        sudoku = Utils.ValidateAndSolveBoard(sudoku);

                        //if choice was reading from file and the sudoku board isn't empty
                        if (choice == 2)
                        {
                            if(sudoku!="")
                                //writing back the solution string to the file
                                FileHandler.WriteFile(txtFile, sudoku);

                        }

                    }
                    //catching all of the different exceptions
                    catch (InvalidBoardSizeException IBSE)
                    {
                        Console.WriteLine(IBSE.Message);
                    }
                    catch(InvalidCharException ICE)
                    {
                        Console.WriteLine(ICE.Message);
                    }
                    catch(InvalidBoardException INE)
                    {
                        Console.WriteLine(INE.Message);
                    }
                    catch(FileException FE)
                    {
                        Console.WriteLine(FE.Message);
                    }

                }


                else
                {
                    Console.WriteLine("Invlid Input, try again");
                }
              

            }


            Console.WriteLine("\n\nclosing program");
        }

    }
}
