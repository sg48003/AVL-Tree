using System;
using System.Collections.Generic;

namespace NASP_AVLStablo
{
    public static class TreePrinter
    {
        class PrintNode
        {
            public Node Node;
            public string Value;

            public PrintNode Parent;
            public PrintNode LeftChild;
            public PrintNode RightChild;

            public int StartPosition;           
            public int EndPosition
            {
                get => StartPosition + Value.Length;
                set => StartPosition = value - Value.Length;
            }
        }

        public static void Print(this Node root)
        {
            if (root == null)
            {
                return;
            }

            int rootTop = Console.CursorTop + 2;
            var last = new List<PrintNode>();
            var nextNode = root;

            for (int depth = 0; nextNode != null; depth++)
            {
                var printNode = new PrintNode
                {
                    Node = nextNode,
                    Value = nextNode.Value.ToString()
                };

                if (depth < last.Count)
                {
                    printNode.StartPosition = last[depth].EndPosition + 1;
                    last[depth] = printNode;
                }
                else
                {
                    printNode.StartPosition = 2;
                    last.Add(printNode);
                }
                if (depth > 0)
                {
                    printNode.Parent = last[depth - 1];
                    if (nextNode == printNode.Parent.Node.LeftChild)
                    {
                        printNode.Parent.LeftChild = printNode;
                        printNode.EndPosition = Math.Max(printNode.EndPosition, printNode.Parent.StartPosition - 1);
                    }
                    else
                    {
                        printNode.Parent.RightChild = printNode;
                        printNode.StartPosition = Math.Max(printNode.StartPosition, printNode.Parent.EndPosition + 1);
                    }
                }
                nextNode = nextNode.LeftChild ?? nextNode.RightChild;

                #region Printing branches

                for (; nextNode == null; printNode = printNode.Parent)
                {
                    int top = rootTop + 2 * depth;
                    PrintBranches(printNode.Value, top, printNode.StartPosition);

                    if (printNode.LeftChild != null)
                    {
                        PrintBranches("/", top + 1, printNode.LeftChild.EndPosition);
                        PrintBranches("_", top, printNode.LeftChild.EndPosition + 1, printNode.StartPosition);
                    }

                    if (printNode.RightChild != null)
                    {
                        PrintBranches("_", top, printNode.EndPosition, printNode.RightChild.StartPosition - 1);
                        PrintBranches("\\", top + 1, printNode.RightChild.StartPosition - 1);
                    }

                    if (--depth < 0)
                    {
                        break;
                    }

                    if (printNode == printNode.Parent.LeftChild)
                    {
                        printNode.Parent.StartPosition = printNode.EndPosition + 1;
                        nextNode = printNode.Parent.Node.RightChild;
                    }
                    else
                    {
                        if (printNode.Parent.LeftChild == null)
                            printNode.Parent.EndPosition = printNode.StartPosition - 1;
                        else
                            printNode.Parent.StartPosition += (printNode.StartPosition - 1 - printNode.Parent.EndPosition) / 2;
                    }
                }

                #endregion

            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void PrintBranches(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0)
            {
                right = left + s.Length;
            }
            while (Console.CursorLeft < right)
            {
                Console.Write(s);
            }
        }
    }
}
