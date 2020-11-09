using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem114FlattenBinaryTreeToLinkedList
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
         * For more solutions: https://leetcode.com/problems/flatten-binary-tree-to-linked-list/solution/
         * Resource: https://www.geeksforgeeks.org/flatten-a-binary-tree-into-linked-list/
         * 
         * Input
         *     1
         *    / \
         *   2   5
         *  / \   \
         * 3   4   6
         * 
         * Output
         * 1
         *  \
         *   2
         *    \
         *     3
         *      \
         *       4
         *        \
         *         5
         *          \
         *           6
         */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public void Flatten(TreeNode root)
        {
            FlattenTree(root);
        }

        public TreeNode FlattenTree(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.left == null && node.right == null)
            {
                return node;
            }

            var leftTail = FlattenTree(node.left);
            var rightTail = FlattenTree(node.right);

            if (leftTail != null)
            {
                leftTail.right = node.right;
                node.right = node.left;
                node.left = null;
            }

            return rightTail == null ? leftTail : rightTail;
        }

        public void Flatten2(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            var node = root;

            while (node != null)
            {
                if (node.left != null)
                {
                    var rightMost = node.left;

                    while (rightMost.right != null)
                    {
                        rightMost = rightMost.right;
                    }

                    rightMost.right = node.right;
                    node.right = node.left;
                    node.left = null;
                }

                node = node.right;
            }
        }

        public void Flatten3(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (current.right != null)
                {
                    stack.Push(current.right);
                }

                if (current.left != null)
                {
                    stack.Push(current.left);
                }

                if (stack.Count > 0)
                {
                    current.right = stack.Peek();
                }

                current.left = null;
            }
        }
    }
}