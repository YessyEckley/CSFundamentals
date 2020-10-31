using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem31NextPermutation
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/next-permutation/
         * For more solutions: https://leetcode.com/problems/next-permutation/solution/
         */

        public void NextPermutation(int[] nums)
        {
            var i = nums.Length - 2;

            while (i >= 0 && nums[i + 1] <= nums[i])
            {
                i--;
            }

            if (i >= 0)
            {
                var j = nums.Length - 1;

                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }

                SwapValues(nums, i, j);
            }

            Reverse(nums, i + 1);
        }

        private void Reverse(int[] nums, int startIndex)
        {
            var i = startIndex;
            var j = nums.Length - 1;

            while (i < j)
            {
                SwapValues(nums, i, j);
                i++;
                j--;
            }
        }

        private static void SwapValues(int[] nums, int firstIndex, int secondIndex)
        {
            var temp = nums[firstIndex];
            nums[firstIndex] = nums[secondIndex];
            nums[secondIndex] = temp;
        }
    }
}
