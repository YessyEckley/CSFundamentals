using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem167TwoSumII
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
         * For more solutions: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/solution/
         */

        public int[] TwoSum(int[] numbers, int target)
        {
            var p1 = 0;
            var p2 = numbers.Length - 1;

            while (p1 < p2)
            {
                var sum = numbers[p1] + numbers[p2];

                if (sum == target)
                {
                    return new int[] { p1 + 1, p2 + 1 };
                }

                if (sum > target)
                {
                    p2--;
                }
                if (sum < target)
                {
                    p1++;
                }
            }

            return null;
        }

        public int[] TwoSum2(int[] numbers, int target)
        {
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var adden = target - numbers[i];

                if (dictionary.ContainsKey(adden))
                {
                    return new int[] { dictionary[adden], i + 1 };
                }

                dictionary.Add(adden, i + 1);
            }

            return null;
        }
    }
}
