using System;
using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem46Permutations
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/permutations/
         * For more solutions: https://leetcode.com/problems/permutations/solution/
         * 
         * Input: [1,2,3]
         * Output:
         * [
         *   [1,2,3],
         *   [1,3,2],
         *   [2,1,3],
         *   [2,3,1],
         *   [3,1,2],
         *   [3,2,1]
         * ]
         * 
         * [1,2,3] -> we need to go through every element
         *  First element of the array
         *  -> 1, 2, 3
         *  -> 1, 3, 2
         *  second element of the array
         *  -> 2, 1, 3
         *  -> 2, 3, 1
         *  third element of the array
         *  -> 3, 1, 2
         *  -> 3, 2, 1
         */

        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> permuteResult = new List<IList<int>>();
            Permute(nums, 0, nums.Length - 1, permuteResult);
            return permuteResult;
        }

        private void Permute(int[] nums, int start, int end, IList<IList<int>> permuteResult)
        {
            if (nums == null || start >= end)
            {
                var newNums = new int[nums.Length];
                Array.Copy(nums, newNums, nums.Length);
                permuteResult.Add(newNums);
                return;
            }

            for (int i = start; i <= end; i++)
            {
                Swap(ref nums[start], ref nums[i]);
                Permute(nums, start + 1, end, permuteResult);
                Swap(ref nums[start], ref nums[i]);
            }
        }

        private void Swap(ref int val1, ref int val2)
        {
            var temp = val1;
            val1 = val2;
            val2 = temp;
        }
    }
}