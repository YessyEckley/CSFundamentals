using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Leetcode
{
    public class Problem15ThreeSum
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/3sum/
         * For more solutions: https://leetcode.com/problems/3sum/solution/
         * 
         * Important: https://en.wikipedia.org/wiki/3SUM
         * 
         * TODO: Find an easy way to implament this
         */

        // Pointer approach
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> returnValue = new List<IList<int>>();

            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    TwoSumII(nums, i, returnValue);
                }
            }

            return returnValue;
        }

        // Pointer approach #2
        private void TwoSumII(int[] nums, int i, IList<IList<int>> returnValue)
        {
            var low = i + 1;
            var hi = nums.Length - 1;

            while (low < hi)
            {
                var sum = nums[i] + nums[low] + nums[hi];

                if (sum < 0)
                {
                    ++low;
                }
                else if (sum > 0)
                {
                    --hi;
                }
                else
                {
                    IList<int> item = new List<int> { nums[i], nums[low++], nums[hi--] };
                    returnValue.Add(item);

                    while (low < hi && nums[low] == nums[low - 1])
                    {
                        ++low;
                    }
                }
            }
        }

        // Approach #2 -> This one gets less test cases to pass
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> returnValue = new List<IList<int>>();

            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    TwoSum(nums, i, returnValue);
                }
            }

            return returnValue;
        }

        private void TwoSum(int[] nums, int i, IList<IList<int>> returnValue)
        {
            var values = new Dictionary<int, int>();

            for (int j = i + 1; j < nums.Length; ++j)
            {
                var compliment = -nums[i] - nums[j];

                if (values.ContainsKey(compliment))
                {
                    IList<int> item = new List<int> { nums[i], nums[j], compliment };
                    returnValue.Add(item);

                    while (j + 1 < nums.Length && nums[j] == nums[j + 1])
                    {
                        ++j;
                    }
                }
            }
        }

        // Approach #3 -> This uses the algorithm from the wikipedia article
        public IList<IList<int>> ThreeSum3(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> returnValue = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    var start = i + 1;
                    var end = nums.Length - 1;

                    while (start < end)
                    {
                        var sum = nums[i] + nums[start] + nums[end];

                        if (sum > 0)
                        {
                            end--;
                        }
                        else if (sum < 0)
                        {
                            start++;
                        }
                        else
                        {
                            IList<int> item = new int[] { nums[i], nums[start], nums[end] };
                            returnValue.Add(item);

                            end--;
                            start++;

                            while (start < end && nums[start] == nums[start - 1])
                            {
                                ++start;
                            }
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}
