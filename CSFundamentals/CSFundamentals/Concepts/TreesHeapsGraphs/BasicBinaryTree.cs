using System;

namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class BasicBinaryTree
    {
        /*
         * Resource: https://www.geeksforgeeks.org/binary-tree-data-structure/
         * 
         * For more information about the where keywork in C#:
         * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
         * 
         * And more information about IComparable:
         * https://docs.microsoft.com/en-us/dotnet/api/system.icomparable?view=netcore-3.1
         */
        public class Node<T> where T : IComparable
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }

            public Node(T data) { Data = data; }

            public void Insert(T value)
            {
                if (value.CompareTo(Data) <= 0)
                {
                    if (Left == null)
                    {
                        Left = new Node<T>(value);
                    }
                    else
                    {
                        Left.Insert(value);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new Node<T>(value);
                    }
                    else
                    {
                        Right.Insert(value);
                    }
                }
            }

            public bool Contains(T value)
            {
                if (value.CompareTo(Data) == 0)
                {
                    return true;
                }
                else if (value.CompareTo(Data) < 0)
                {
                    if (Left == null)
                    {
                        return false;
                    }
                    else
                    {
                        return Left.Contains(value);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        return false;
                    }
                    else
                    {
                        return Right.Contains(value);
                    }
                }
            }

            public void PrintPreOrder()
            {
                Console.WriteLine(Data);

                if (Left != null)
                {
                    Left.PrintPreOrder();
                }

                if (Right != null)
                {
                    Right.PrintPreOrder();
                }
            }

            public void PrintInOrder()
            {
                if (Left != null)
                {
                    Left.PrintInOrder();
                }

                Console.WriteLine(Data);

                if (Right != null)
                {
                    Right.PrintInOrder();
                }
            }

            public void PrintPostOrder()
            {
                if (Left != null)
                {
                    Left.PrintPostOrder();
                }

                if (Right != null)
                {
                    Right.PrintPostOrder();
                }

                Console.WriteLine(Data);
            }
        }
    }
}
