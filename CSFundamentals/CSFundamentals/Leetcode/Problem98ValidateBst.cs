using System;

namespace CSFundamentals.Leetcode
{
    public class Problem98ValidateBst
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/validate-binary-search-tree/
         * For more solutions: https://leetcode.com/problems/validate-binary-search-tree/solution/
         * 
         * Example #1
         *     2
         *    / \
         *   1   3
         * 
         * Input: [2,1,3]
         * Output: true
         * 
         * 
         * Example #2
         *     5
         *    / \
         *   1   4
         *      / \
         *     3   6
         * 
         * Input: [5,1,4,null,null,3,6]
         * Output: false
         * Explanation: The root node's value is 5 but its right child's value is 4.
         * 
         * -> Get the parent root
         *      -> compare the left node is less than the parent
         *      -> compare the right node is greater than the parent
         * -> Continue doing this until we reach the end, which is
         *      -> the node is null
         * -> base case: if we encounter a null we return true
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

        // Approack #1 -> Using Recursions
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }

        public bool IsValidBST(TreeNode root, int? min, int? max)
        {
            if (root == null)
            {
                return true;
            }

            if (min != null && root.val <= min)
            {
                return false;
            }

            if (max != null && root.val >= max)
            {
                return false;
            }

            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }

        // Approack #2 -> Using iteration and stacks
        public bool IsValidBST2(TreeNode root)
        {
            // TODO: Implement at a later time
            throw new NotImplementedException();
        }

        /*
         * Brute Force
         * There is a flaw with this approach and it is not ideal
         * Input: [10,5,15,null,null,6,20]
         *      10
         *     /  \
         *    5   15
         *       /  \
         *      6    20 -> 6 should belong on the other side of the BST
         * Output: true
         * Expected: false
         */

        public bool IsValidBSTBad(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            if (root.left != null && root.val <= root.left.val)
            {
                return false;
            }

            if (root.right != null && root.val >= root.right.val)
            {
                return false;
            }

            return IsValidBST(root.left) && IsValidBST(root.right);
        }
    }
}
