using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class DancingLinksAlgo
    {
        public class DancingNode
        {
            public DancingNode Left, Right, Top, Bottom;
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
                node.Bottom = Bottom;
                node.Bottom.Top = node;
                node.Top = this;
                Bottom = node;
                return node;
            }

            public DancingNode LinkRight(DancingNode node)
            {
                
                node.Right = Right;
                node.Right.Left = node;
                node.Left = this;
                Right = node;
                return node;
            }

            public void RemoveLeftRight()
            {
                Left.Right = Right;
                Right.Left = Left;
            }

            public void ReinsertLeftRight()
            {
                Left.Right = this;
                Right.Left = this;
            }

            public void RemoveTopBottom()
            {
                Top.Bottom = Bottom;
                Bottom.Top = Top;
            }

            public void ReinsertTopBottom()
            {
                Top.Bottom = this;
                Bottom.Top = this;
            }
        }


        public class ColumnNode : DancingNode
        {
            public int size;
            public String name;

            public ColumnNode(String n) : base()
            {
                size = 0;
                name = n;
                column = this;
            }

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

        public class DLX
        {

            private ColumnNode header;
            private List<DancingNode> answer = new List<DancingNode>();
            public List<DancingNode> result;

            public DLX(int[][] cover)
            {
                header = createDLXList(cover);
            }

            private ColumnNode createDLXList(int[][] grid)
            {
                int nbColumns = grid[0].Length;
                ColumnNode headerNode = new ColumnNode("header");
                List<ColumnNode> columnNodes = new List<ColumnNode>();

                for (int i = 0; i < nbColumns; i++)
                {
                    ColumnNode n = new ColumnNode(i + "");
                    columnNodes.Add(n);
                    headerNode = (ColumnNode)headerNode.LinkRight(n);
                }
                
                headerNode = headerNode.Right.column;
                int cnt = 0;
                foreach (int[] aGrid in grid)
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
                // Set the initial minimum column to the first column in the Dancing Links structure.
                ColumnNode minCol = header.Right.column;
                int minSize = minCol.size;

                // Iterate over the columns in the Dancing Links structure.
                ColumnNode col = minCol;
                while (col != header)
                {
                    // If the current column has a smaller size than the current minimum, store it as the new minimum.
                    if (col.size < minSize)
                    {
                        minCol = col;
                        minSize = col.size;
                    }

                    col = col.Right.column;
                }

                // Return the column with the smallest size.
                return minCol;
            }



            public void process(int k)
            {
                if (header.Right == header)
                {
                    // End of Algorithm X
                    // Result is copied in a result list
                    result = new List<DancingNode>(answer);
                }
                else
                {
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
                        process(k + 1);

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
                }
            }




        }


    }

}

