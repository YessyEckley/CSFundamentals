using System;
namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class BinarySearchTreeInsertion
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/binary-search-tree-insertion/problem
         * 
         * Strategy
         *      -> This is just practicing inserting nodes to the binary search tree
         *      -> Are we going to have any repeat data?
         *      -> Are we going to have any null values beig passed?
         *      -> We want to make the tree balance
         *          -> Maybe find a pivot to help balance the tree, sort of like how we do it for quick sort?
         * 
         * NOTES: In HackerRanck I had to submit the problem in Java, as it is the closest when it cames to C#
         * 
         * IMPOTANT: Debug your code by talking out loud
         */

        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        public Node Insert(Node root, int data)
        {
            if (root == null)
            {
                 root = new Node(data);
            }

            if (data != root.Data) // Always use the passing data as main comparison of evaluation
            {
                if (data < root.Data)
                {
                    root.Left = Insert(root.Left, data);
                }
                else
                {
                    root.Right = Insert(root.Right, data);
                }
            }

            return root;
        }
    }
}
