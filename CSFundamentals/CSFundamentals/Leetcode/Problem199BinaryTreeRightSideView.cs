using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem199BinaryTreeRightSideView
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/binary-tree-right-side-view/
         * For more solutions: https://leetcode.com/problems/binary-tree-right-side-view/solution/
         * 
         * Note: Watch out on this exercise. It's not what it seems.
         *       It makes you believe that it only wants the right side of the tree but it is not the case.
         *       It wants the rightmost. So the left side can be the rightmost at times.
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

        // Approach DFS
        public IList<int> RightSideView(TreeNode root)
        {
            var returnValue = new List<int>();

            RightSideLook(root, returnValue, 0);

            return returnValue;
        }

        private void RightSideLook(TreeNode root, List<int> returnValue, int level)
        {
            if (root != null)
            {
                // Top
                if (returnValue.Count == level)
                {
                    returnValue.Add(root.val);
                }
                else
                {
                    returnValue[level] = root.val;
                }

                // Left
                RightSideLook(root.left, returnValue, level + 1);

                // Right
                RightSideLook(root.right, returnValue, level + 1);
            }
        }

        // This one is better
        private void RightSideLook2(TreeNode root, List<int> returnValue, int level)
        {
            if (root != null)
            {
                // Top
                if (returnValue.Count == level)
                {
                    returnValue.Add(root.val);
                }

                // Right
                RightSideLook2(root.right, returnValue, level + 1);

                // Left
                RightSideLook2(root.left, returnValue, level + 1);
            }
        }


        // Approach BFS
        public IList<int> RightSideView2(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }
            var returnValue = new List<int>();
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    var current = queue.Dequeue();

                    if (i == levelSize - 1)
                    {
                        returnValue.Add(current.val);
                    }

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
            }

            return returnValue;
        }
    }
}
