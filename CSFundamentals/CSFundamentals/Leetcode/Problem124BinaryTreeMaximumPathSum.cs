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
            _maxSumValue = int.MinValue;

            PathSum(root);

            return _maxSumValue;
        }

        private int _maxSumValue;

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
}