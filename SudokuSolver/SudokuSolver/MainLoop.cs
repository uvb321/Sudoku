using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this moudule is for the main loop of the program

namespace SudokuSolver
{
    internal class MainLoop
    {
        public static void Main_Loop()
        {
            while (true){
                string sudoku="";
                Messages.Loop_Message();
                int choice = int.Parse(Console.ReadLine());

                //finishing the program
                if (choice == 0)
                    break;

                else if(choice == 1|| choice == 2)
                {
                    if (choice == 1) { }
                        //getting sudoku from console
                        sudoku = Console.ReadLine();

                    if (choice == 2)
                    {
                        //read sudoku from file
                        //to do
                    }

                    Utils.ValidateAndSolveBoard(sudoku);

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
