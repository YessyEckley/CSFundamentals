using System;
using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem124BinaryTreeMaximumPathSum
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/binary-tree-maximum-path-sum/
         * For more solutions: https://leetcode.com/problems/binary-tree-maximum-path-sum/solution/
         * 
         * Resources: https://www.geeksforgeeks.org/find-maximum-path-sum-in-a-binary-tree/
         *            https://www.youtube.com/watch?v=mOdetMWwtoI
         * 
         * Input: root = [1,2,3]
         * Output: 6
         * 
         * Input: root = [-10,9,20,null,null,15,7]
         * Output: 42
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

        public int MaxPathSum(TreeNode root)
        {
            PathSum(root);

            return _maxSumValue;
        }

        private int _maxSumValue = int.MinValue;

        private int PathSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var left = Math.Max(0, PathSum(root.left));
            var right = Math.Max(0, PathSum(root.right));

            _maxSumValue = Math.Max(_maxSumValue, left + right + root.val);

            return Math.Max(left, right) + root.val;
        }

        // This solution does not pass all of the test cases
        public int MaxPathSumBruteForce(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var maxValue = root.val;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var sum = current.val;

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                    maxValue = Math.Max(current.left.val, maxValue);
                    maxValue = Math.Max(current.left.val + current.val, maxValue);
                    sum += current.left.val;
                    maxValue = Math.Max(sum, maxValue);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                    maxValue = Math.Max(current.right.val, maxValue);
                    maxValue = Math.Max(current.right.val + current.val, maxValue);
                    sum += current.right.val;
                    maxValue = Math.Max(sum, maxValue);
                }

                if (sum < maxValue)
                {
                    continue;
                }
            }

            return maxValue;
        }
    }

    public class Problem426BinaryTreeToSortedDoubleLinkedList
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/
         * For more solutions: https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/solution/
         * 
        Input: root = [4,2,5,1,3]
        Output: [1,2,3,4,5]
        Explanation: The figure below shows the transformed BST. 
                     The solid line indicates the successor relationship, while the dashed line means the predecessor relationship.

        -> The output looks like an In-Order traversal
        -> the results are put in a doubly linked list
                -> we can use the binary tree as the main structure
                    -> the left will be the previous and the right will be the next
                    -> the previous of the first element is the last element, and the next of the last element is the first element
        -> transform in place -> do not create a new data structure
        ->

        Input: root = [2,1,3]
        Output: [1,2,3]
        
        Input: root = []
        Output: []
        Explanation: Input is an empty tree. Output is also an empty Linked List.
        
        Input: root = [1]
        Output: [1]
         */

        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
                left = null;
                right = null;
            }

            public Node(int _val, Node _left, Node _right)
            {
                val = _val;
                left = _left;
                right = _right;
            }
        }

        public Node Head { get; set; } = null;
        public Node Tail { get; set; } = null;

        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
            {
                return null;
            }

            TraverseHelper(root);

            Head.left = Tail;
            Tail.right = Head;

            return Head;
        }

        public void TraverseHelper(Node root)
        {
            if (root != null)
            {
                // In order traversale travels
                //left
                TraverseHelper(root.left);

                //root
                if (Tail != null)
                {
                    Tail.right = root;
                    root.left = Tail;
                }
                else
                {
                    Head = root;
                }

                Tail = root;

                //right
                TraverseHelper(root.right);
            }
        }
    }
}