using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Leetcode
{
    public class Problem26RemoveDuplicates
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/remove-duplicates-from-sorted-array/
         * For more solutions: https://leetcode.com/problems/remove-duplicates-from-sorted-array/solution/
         */

        public int RemoveDuplicates(int[] nums)
        {
            // In this exercise we are going to use pointers, one pointer that is ahead of the other to find the solution
            // This way we are moving all unique numbers to the front while moving the other numbers to the back
            if (nums.Length == 0)
            {
                return 0;
            }

            var i = 0;

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                }

                nums[i] = nums[j];
            }

            return i + 1;
        }

        public int RemoveDuplicates2(int[] nums)
        {
            // In this exercise we are going to use pointers, one pointer that is ahead of the other to find the solution
            // This way we are moving all unique numbers to the front while moving the other numbers to the back
            // This one performs faster because it doesnt swap all the time
            if (nums.Length == 0)
            {
                return 0;
            }

            var i = 0;

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }
    }
}
