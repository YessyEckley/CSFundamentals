using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem560SubarraySumEqualsK
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/subarray-sum-equals-k/
         * For more solutions: https://leetcode.com/problems/subarray-sum-equals-k/solution/
         */

        // Brute force approach - it will pass all test but it is slow and not optimized
        public int SubarraySum1(int[] nums, int k)
        {
            var count = 0;

            for (var start = 0; start < nums.Length; start++)
            {
                var sum = 0;

                for (var end = start; end < nums.Length; end++)
                {
                    sum += nums[end];

                    if (sum == k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /* 
         * Approach that is optimized and uses dictionary
         * 
         * This can provide some help: https://www.geeksforgeeks.org/window-sliding-technique/
         */
        public int SubarraySum(int[] nums, int k)
        {
            var sum = 0;
            var counter = 0;
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (dictionary.ContainsKey(sum - k))
                {
                    counter += dictionary[sum - k];
                }

                if (!dictionary.ContainsKey(sum))
                {
                    dictionary.Add(sum, 1);
                }
                else
                {
                    dictionary[sum] += 1;
                }
            }

            return counter;
        }
    }
}
