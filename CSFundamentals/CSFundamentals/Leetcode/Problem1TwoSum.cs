using System;
using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem1TwoSum
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/two-sum/ 
         * For more solutions: https://leetcode.com/problems/two-sum/solution/
         */

        public int[] TwoSum1(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var adden = target - nums[i];

                if (dictionary.ContainsKey(adden))
                {
                    return new int[] { dictionary[adden], i };
                }

                if (!dictionary.ContainsKey(nums[i]))
                {
                    dictionary.Add(nums[i], i);
                }
            }

            return null;
        }

        // Brute Force
        public int[] TwoSum2(int[] nums, int target)
        {
            var lower = 0;
            var upper = nums.Length - 1;
            var sortedNums = new int[nums.Length];
            nums.CopyTo(sortedNums, 0);
            Array.Sort(sortedNums);

            while (lower < upper)
            {
                var sum = sortedNums[lower] + sortedNums[upper];

                if (sum == target)
                {
                    return new int[] { Array.IndexOf(nums, sortedNums[lower]), Array.LastIndexOf(nums, sortedNums[upper]) };
                }

                if (sum > target)
                {
                    upper--;
                }

                if (sum < target)
                {
                    lower++;
                }
            }

            return null;
        }
    }
}
