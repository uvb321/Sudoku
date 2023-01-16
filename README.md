"# Sudoku" 
this is a simple sudoku solving program that uses
the "dancing links" algorithm to solve the puzzle.
I wrote the code on the Visual Studio 2022 IDE.

A sudoku is a logic-based, combinatorial, number-placement puzzle. a classic sudoku puzzle is a 9X9 board and the objective is to fill the board with digits in a way that a digit doesn't appear twice in the same row, column or box. 

for further explenation you can visit:
https://en.wikipedia.org/wiki/Sudoku

My code is able to handle with 1x1, 4x4, 9x9, 16x16 and 25x25 sudoku boards.

My code will recive a sudoku puzzle in two ways:
1. from the console of the visual studio 2022
2. from a text file, please note that the text file path entered needs to be absolute.

the input should be a single string with no spaces or new lines and 0 as empty cells.
for example:
the string - 0000000000000000
represents a 4x4 empty sudoku board with no clues at all looking like this:
-------------
| 0 0 | 0 0 |
| 0 0 | 0 0 |
-------------
| 0 0 | 0 0 |
| 0 0 | 0 0 |
-------------
which to this board the solution would be:
-------------
| 1 2 | 3 4 |
| 3 4 | 1 2 |
-------------
| 2 1 | 4 3 |
| 4 3 | 2 1 |
-------------

*please note that there are a few possible solutions to the board and so the program will return only 1 of them.


boards that are bigger than 10 in size will use the characters after 9 in the ascii table to represent the values.
: - 10
; - 11
< - 12
= - 13
> - 14
and so on

ALGORITHM:
The algorithm used for solving the puzzle is called "Dancing Links" or DLX for short, this algorithm was invented by donald knuth and it is used to solve Exact cover problems. 
A sudoku board can be defined as an exact cover problem because to a valid sudoku board can only be 1 answer.
the algorithm uses a spares matrix to sovle the cover matrix, the efficiency of the algorithm comes from the spares matrix as covering and uncovering whole column of answers takes only O(1) because unlinking or linking are very fast actions.

"Algorithm X is a recursive, nondeterministic, depth-first, backtracking algorithm that finds all solutions to the exact cover problem."



In order to use my Code you need to have visual studio 2022, run the .sln file and make sure that all of the .cs files are in the correct directory.
press run on the program.cs file and follow the instructions.
