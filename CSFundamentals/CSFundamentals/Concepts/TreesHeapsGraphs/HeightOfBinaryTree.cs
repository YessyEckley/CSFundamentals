using System;
namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class HeightOfBinaryTree
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree/problem
         * 
         * Strategy
         *      -> The height of a single node binary tree is 0
         *      -> All possitive number
         *      -> left < root and right > root
         *      
         *      -> *** I'm given a root and I need to determine the max height (depth) of the tree ***
         * 
         * NOTES: https://www.geeksforgeeks.org/iterative-method-to-find-height-of-binary-tree/
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

        public static int Height(Node root)
        {
            if (root == null || (root.Left == null && root.Right == null))
            {
                return 0;
            }

            return Math.Max(Height(root.Left) + 1, Height(root.Right) + 1);
        }

        public static int MaxDepth(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftDepth = MaxDepth(node.Left);
            var rightDepth = MaxDepth(node.Right);

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }
    }
}
