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
    internal class DancingLinksAlgo
    {
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

            public DancingNode LinkDown(DancingNode node)
            {
                //connecting a new node down from this node
                node.Bottom = Bottom;
                node.Bottom.Top = node;
                node.Top = this;
                Bottom = node;
                return node;
            }

            public DancingNode LinkRight(DancingNode node)
            {
                //connecting a new node to the right of this node   
                node.Right = Right;
                node.Right.Left = node;
                node.Left = this;
                Right = node;
                return node;
            }

            public void RemoveLeftRight()
            {
                //disconnecting this node horizontally
                Right.Left = Left;
                Left.Right = Right;
            }

            public void ReinsertLeftRight()
            {
                //connecting this node horizontally
                Right.Left = this;
                Left.Right = this;
            }

            public void RemoveTopBottom()
            {
                //disconnecting this node vertically
                Bottom.Top = Top;
                Top.Bottom = Bottom;
            }

            public void ReinsertTopBottom()
            {
                //connecting this node vertically
                Bottom.Top = this;
                Top.Bottom = this;
            }
        }


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

            public void cover()
            {
                //this func disconnects the whole column
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

            public void uncover()
            {
                //this func connects back this whole column
                for (DancingNode i = Top; i != this; i = i.Top)
                {
                    for (DancingNode j = i.Left; j != i; j = j.Left)
                    {
                        j.column.size--;
                        j.ReinsertTopBottom();
                    }
                }

                ReinsertLeftRight();
            }
        }

        public class DLX
        {
            //a class that represents the dlx matrix

            //points to the start of the data base
            private ColumnNode header;
            //used in the solve func to store temp solutions
            private List<DancingNode> answer = new List<DancingNode>();
            //the final result will be stored here
            public List<DancingNode> result;

            public DLX(int[][] coverMat)
            {
                //creating a dlx matrix out of a cover matrix
                header = createDLXList(coverMat);
            }

            //creating the dlx matrix out of the cover matrix that was created from the recieved grid
            private ColumnNode createDLXList(int[][] coverMat)
            {
                //number of columns
                int nbColumns = coverMat[0].Length;
                //creating the header node, will point to the start of the data base
                ColumnNode headerNode = new ColumnNode("header");
                //a list of nodes that represent the column node of each column
                List<ColumnNode> columnNodes = new List<ColumnNode>();

                for (int i = 0; i < nbColumns; i++)
                {
                    ColumnNode n = new ColumnNode(i + "");
                    columnNodes.Add(n);
                    headerNode = (ColumnNode)headerNode.LinkRight(n);
                }
                

                //connecting the nodes by the cover mat
                headerNode = headerNode.Right.column;
                foreach (int[] aGrid in coverMat)
                {
                    DancingNode prev = null;

                    for (int j = 0; j < nbColumns; j++)
                    {
                        if (aGrid[j] == 1)
                        {
                            ColumnNode col = columnNodes[j];
                            DancingNode newNode = new DancingNode(col);

                            if (prev == null)
                                prev = newNode;

                            
                            col.Top.LinkDown(newNode);
                            prev = prev.LinkRight(newNode);
                            col.size++;
                        }
                    }
                    
                }

                headerNode.size = nbColumns;

                return headerNode;
            }

            private ColumnNode SelectMinCol()
            {
                //this func returns the column node that has the least amount of nodes connected to it,it's better for the algorithm
                //to work with the column that has the least amount of nodes in it
                // init values.
                int min = int.MaxValue;
                ColumnNode columnNode = null;

                // iterate all columns from the right of the head node.
                for (ColumnNode column = (ColumnNode)header.Right; column != header; column = (ColumnNode)column.Right)
                {
                    // need to found the column with the minimum size.
                    if (column.size < min)
                    {
                        min = column.size;
                        columnNode = column;
                    }
                }
                return columnNode;
            }
            public bool process(int k)
            {
                

                //this func tries to find a solution for the dlx matrix, if susceeds return true, else false
                if (header.Right == header)
                {
                    // End of Algorithm X
                    // Result is copied in a result list
                    result = new List<DancingNode>(answer);
                    // Return immediately, without exploring further branches
                    return true;
                }

                // we choose column c
                ColumnNode c = SelectMinCol();
                c.cover();

                for (DancingNode r = c.Bottom; r != c; r = r.Bottom)
                {
                    // We add r line to partial solution
                    answer.Add(r);

                    // We cover columns
                    for (DancingNode j = r.Right; j != r; j = j.Right)
                    {
                        j.column.cover();
                    }

                    // recursive call to leverl k + 1
                    //returning true if a sulotion already was found
                    if (process(k + 1))
                        return true;

                    // We go back
                    r = answer[answer.Count - 1];
                    answer.Remove(answer[answer.Count - 1]);
                    c = r.column;

                    // We uncover columns
                    for (DancingNode j = r.Left; j != r; j = j.Left)
                    {
                        j.column.uncover();
                    }
                }

                c.uncover();
                //couldn't find a solution
                return false;

            }
        }
    }

}

