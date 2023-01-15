using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    /// <summary>
    /// this module represents the algorithm of the program itself, here the board will be solved and turn back into a regular board
    /// </summary>
    internal class DancingLinksAlgo
    {
        /// <summary>
        /// this class represents a node in the spares matrix, it is called a dancing node because of the algorithm "dancing links"
        /// </summary>
        public class DancingNode
        {
            //pointers to the node above, below, to the left and right
            public DancingNode Left, Right, Top, Bottom;
            //pointer to the column node of this node
            public ColumnNode column;

            public DancingNode()
            {
                Left = Right = Top = Bottom = this;
            }

            public DancingNode(ColumnNode c)
            {
                Left = Right = Top = Bottom = this;
                column = c;
            }
            /// <summary>
            /// this function connects a new node down of this node
            /// </summary>
            /// <param name="nodeToConnect"></param>
            /// <returns></returns>
            public DancingNode LinkDown(DancingNode nodeToConnect)
            {
                //connecting a new node down from this node
                nodeToConnect.Bottom = Bottom;
                nodeToConnect.Bottom.Top = nodeToConnect;
                nodeToConnect.Top = this;
                Bottom = nodeToConnect;
                return nodeToConnect;
            }

            /// <summary>
            /// this function connects a node to the right of this node
            /// </summary>
            /// <param name="nodeToConnect"></param>
            /// <returns></returns>
            public DancingNode LinkRight(DancingNode nodeToConnect)
            {
                //connecting a new node to the right of this node   
                nodeToConnect.Right = Right;
                nodeToConnect.Right.Left = nodeToConnect;
                nodeToConnect.Left = this;
                Right = nodeToConnect;
                return nodeToConnect;
            }

            /// <summary>
            /// this function disconnects the node horizontally
            /// </summary>
            public void RemoveLeftRight()
            {
                Right.Left = Left;
                Left.Right = Right;
            }

            /// <summary>
            /// this functions reconnects the node horizontally
            /// </summary>
            public void ReinsertLeftRight()
            {
                Right.Left = this;
                Left.Right = this;
            }
            /// <summary>
            /// this function disconnects this node vertically
            /// </summary>
            public void RemoveTopBottom()
            {
                Bottom.Top = Top;
                Top.Bottom = Bottom;
            }

            /// <summary>
            /// this function reconnects this node vertically
            /// </summary>
            public void ReinsertTopBottom()
            {
                Bottom.Top = this;
                Top.Bottom = this;
            }
        }

        /// <summary>
        /// this class  represents a column node in the spare matrix, in inherits DancingNod because a column node is a form of a DancingNode
        /// </summary>
        public class ColumnNode : DancingNode
        {
            //how many nodes are in the column
            public int size;
            //column name
            public String name;

            public ColumnNode(String n) : base()
            {
                size = 0;
                name = n;
                column = this;
            }

            /// <summary>
            /// this function disconnect a whole column, and the nodes connected to that column, thus eliminating options
            /// </summary>
            public void cover()
            {
               
                RemoveLeftRight();

                for (DancingNode i = Bottom; i != this; i = i.Bottom)
                {
                    for (DancingNode j = i.Right; j != i; j = j.Right)
                    {
                        j.RemoveTopBottom();
                        j.column.size--;
                    }
                }
            }

            /// <summary>
            /// this function reconnects the whole column and the nodes connected to the nodes in the column that is being rediscovered
            /// </summary>
            public void uncover()
            {
                for (DancingNode i = Top; i != this; i = i.Top)
                {
                    for (DancingNode j = i.Left; j != i; j = j.Left)
                    {
                        j.column.size++;
                        j.ReinsertTopBottom();
                    }
                }

                ReinsertLeftRight();
            }
        }

        /// <summary>
        /// this class represents the spares matrix, or the dancing links matrix "DLX"
        /// </summary>
        public class DLX
        {
           

            //points to the start of the data base
            private ColumnNode header;
            //used in the solve func to store temp solutions
            private List<DancingNode> tempSolution = new List<DancingNode>();
            //the final result will be stored here
            public List<DancingNode> result;

            public DLX(int[][] coverMat)
            {
                //creating a dlx matrix out of a cover matrix
                header = createDLXList(coverMat);
            }

            /// <summary>
            /// this function creates the DLX matrix out of the spares matrix, 1's are reprresented, 0's aren't
            /// </summary>
            /// <param name="coverMat">the coverMatrix is the cover matrix that was created from the sudoku board</param>
            /// <returns>returns the header node to the dlx </returns>
            private ColumnNode createDLXList(int[][] coverMat)
            {
                //number of columns
                int numOfCols = coverMat[0].Length;
                //creating the header node, will point to the start of the data base
                ColumnNode headerNode = new ColumnNode("header");
                //a list of nodes that represent the column node of each column
                List<ColumnNode> columnNodes = new List<ColumnNode>();

                //creating column nodes 
                for (int i = 0; i < numOfCols; i++)
                {
                    ColumnNode colNode = new ColumnNode(i + "");
                    columnNodes.Add(colNode);
                    headerNode = (ColumnNode)headerNode.LinkRight(colNode);
                }
                

                //connecting the nodes by the cover mat
                headerNode = headerNode.Right.column;
                foreach (int[] row in coverMat)
                {
                    DancingNode prevNode = null;

                    for (int col = 0; col< numOfCols; col++)
                    {
                        if (row[col] == 1)
                        {
                            ColumnNode colNode = columnNodes[col];
                            DancingNode newNode = new DancingNode(colNode);

                            if (prevNode == null)
                                prevNode = newNode;

                            
                            colNode.Top.LinkDown(newNode);
                            prevNode = prevNode.LinkRight(newNode);
                            colNode.size++;
                        }
                    }
                    
                }

                headerNode.size = numOfCols;

                return headerNode;
            }

            /// <summary>
            /// this func returns the column node that has the least amount of nodes connected to it,it's better for the algorithm
            /// to work with the column that has the least amount of nodes in it, becaues it requires the least amount of disconnections
            /// </summary>
            /// <returns>it returns the column with the least amount of nodes connected to it</returns>
            private ColumnNode SelectMinCol()
            {
                
                // init values.
                int minAmount = int.MaxValue;
                ColumnNode columnNode = null;

                // iterate all columns from the right of the head node.
                for (ColumnNode column = (ColumnNode)header.Right; column != header; column = (ColumnNode)column.Right)
                {
                    // need to found the column with the minimum size.
                    if (column.size < minAmount)
                    {
                        minAmount = column.size;
                        columnNode = column;
                    }
                }
                return columnNode;
            }

            /// <summary>
            /// this function is the main function of the algorithm and it solves the exact cover problem using the DLX 
            /// </summary>
            /// <param name="depth"></param>
            /// <returns>retuens true if solution was found, false otherwise</returns>
            public bool solveDLX(int depth)
            {
                
               //if there are no more columns to check an answer was found
                if (header.Right == header)
                {
                    // End of Algorithm X
                    // Result is copied in a result list
                    result = new List<DancingNode>(tempSolution);
                    // Return immediately, without exploring further branches
                    return true;
                }

                // we choose column c
                ColumnNode colNode = SelectMinCol();
                colNode.cover();

                for (DancingNode node = colNode.Bottom; node != colNode; node = node.Bottom)
                {
                    // We add r line to partial solution
                    tempSolution.Add(node);

                    // We cover columns
                    for (DancingNode nodeConnected = node.Right; nodeConnected != node; nodeConnected = nodeConnected.Right)
                    {
                        //covering the column of the connected node
                        nodeConnected.column.cover();
                    }

                    // recursive call to leverl k + 1
                    //returning true if a sulotion already was found
                    if (solveDLX(depth + 1))
                        return true;

                    // We go back
                    
                    //getting the last solution back to the node and deleting it from the possible solutions list
                    node = tempSolution[tempSolution.Count - 1];
                    tempSolution.Remove(tempSolution[tempSolution.Count - 1]);
                    colNode = node.column;

                    // We uncover columns
                    for (DancingNode nodeConnected = node.Left; nodeConnected != node; nodeConnected = nodeConnected.Left)
                    {
                        //uncovering the column of the connected node
                        nodeConnected.column.uncover();
                    }
                }

                //uncovring the board
                colNode.uncover();
                //couldn't find a solution
                return false;

            }


            /// <summary>
            /// this function converts the result of the dancing links algo back to a sudoku board represented in a matrix
            /// </summary>
            /// <param name="SIZE">size is the size of the board, needed to make the function generic</param>
            /// <returns></returns>
            public int[][] ConvertDLXListToGrid(int SIZE)
            {


                //init to the new solved grid
                int[][] solvedBoard = new int[SIZE][];
                for (int i = 0; i < SIZE; i++)
                {
                    solvedBoard[i] = new int[SIZE];
                }

                foreach (DancingNode node in result)
                {
                    DancingNode rcNode = node;
                    int min = int.Parse(rcNode.column.name);

                    for (DancingNode tmp = node.Right; tmp != node; tmp = tmp.Right)
                    {
                        int val = int.Parse(tmp.column.name);

                        if (val < min)
                        {
                            min = val;
                            rcNode = tmp;
                        }
                    }

                    // we get line and column
                    int answer1 = int.Parse(rcNode.column.name);
                    int answer2 = int.Parse(rcNode.Right.column.name);
                    int r = answer1 / SIZE;
                    int c = answer1 % SIZE;
                    // and the affected value
                    int num = (answer2 % SIZE) + 1;
                    // we affect that on the result grid
                    solvedBoard[r][c] = num;
                }

                return solvedBoard;
            }
        }
    }

}

