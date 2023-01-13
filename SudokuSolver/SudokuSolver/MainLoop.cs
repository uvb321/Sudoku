using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SudokuSolver.CustomExceptions;


namespace SudokuSolver
{
    /// <summary>
    /// this module is the main loop of the program
    /// </summary>
    internal class MainLoop
    {
        public static void Main_Loop()
        {
            while (true){
                string sudoku="";
                Messages.Loop_Message();
                Console.Write("pleae enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Console.WriteLine("\n\n-------------------------------------------------------------");
                //finishing the program
                if (choice == 0)
                    break;

                else if(choice == 1|| choice == 2)
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("please enter a string that represent a sudoku board below: \n");
                        //getting sudoku from console
                        sudoku = Console.ReadLine();
                    }
                        

                    if (choice == 2)
                    {
                        //read sudoku from file
                        //to do
                    }


                    try
                    {
                        Utils.ValidateAndSolveBoard(sudoku);
                    }
                    catch (InvalidBoardSizeException IBSE)
                    {
                        Console.WriteLine(IBSE.Message);
                    }
                    catch(InvalidCharException ICE)
                    {
                        Console.WriteLine(ICE.Message);
                    }
                    catch(InvalidInputException INE)
                    {
                        Console.WriteLine(INE.Message);
                    }
                   

                    if(choice == 2)
                    {
                        //to do
                        //write back to the file
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
