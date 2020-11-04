using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Leetcode
{
    public class Problem238ProductArrayExceptSelf
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/product-of-array-except-self/
         * For more solutions: https://leetcode.com/problems/product-of-array-except-self/solution/
         * 
         * -> Elements of nums are positive numbers
         * -> The output for the element is the product of all elements of the array except itself
         * 
         * 1. We create an output int[]
         *      -> and any other variable that is needed (we will need the current nums value)
         * 2. We loop through the int[] nums
         * 3. Get the current value and we start to get the product of all the values of nums with the exception of the of the element of the current index
         *      -> we can use Linq where clause to filter out the current value
         *      -> or
         *      -> we can have another loop that will go through all of the elements
         *      -> or
         *      -> create a temp array where we eliminate the current element
         * 4. Save the product to the current output element
         * 5. Return output
         * 
         * Input:  [1,2,3,4]
         * Output: [24,12,8,6]
         * 
         * output[0] -> nums[0] -> value 1 = 2 * 3 * 4 = 24
         * output[1] -> nums[1] -> value 2 = 1 * 3 * 4 = 12
         * output[2] -> nums[2] -> value 3 = 1 * 2 * 4 = 8
         * output[3] -> nums[3] -> value 4 = 1 * 2 * 3 = 6
         * 
         *    0 1 2 3 -> Index
         * -> 1 2 3 4
         * left 
         * left[0] = 1
         *      left[i] = nums[i - 1] * left[i - 1];
         * left[1] = 1 * 1 = 1
         * left[2] = 2 * 1 = 2
         * left[3] = 3 * 2 = 6
         * 
         * right
         * right[3] = 1
         *      right[i] = nums[i + 1] * right[i + 1];
         * right[2] = 4 * 1 = 4
         * right[1] = 3 * 4 = 12
         * right[0] = 2 * 12 = 24
         * 
         *      output[i] = left[i] * right[i];
         * output[0] = 1 * 24 = 24
         * output[1] = 1 * 12 = 12
         * output[2] = 2 * 4 = 8
         * output[3] = 6 * 1 = 6
         * 
         * Visual
         *  [1]   2    3    4
         *   1   [2]   3    4
         *   1    2   [3]   4
         *   1    2    3   [4]
         */

        public int[] ProductExceptSelf(int[] nums)
        {
            int length = nums.Length;
            var output = new int[length];
            var left = new int[length];
            var right = new int[length];

            left[0] = 1;
            for (int i = 1; i < length; i++)
            {
                left[i] = nums[i - 1] * left[i - 1];
            }


            right[length - 1] = 1;
            for (int i = length - 2; i >= 0; i--)
            {
                right[i] = nums[i + 1] * right[i + 1];
            }

            for (int i = 0; i < length; i++)
            {
                output[i] = left[i] * right[i];
            }

            return output;
        }

        public int[] ProductExceptSelf1(int[] nums)
        {
            var output = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var product = 1;
                var numsToCalc = new List<int>(nums);

                numsToCalc.Remove(current);

                // This is slow and the time complexity is O(nums.Length * numsToCalc.length)
                // There is also the approach to get the product of all elements and then divide by the current element
                // But this approach onlu works for possitive numbers and doesnt handle well the 0
                foreach (var item in numsToCalc)
                {
                    product *= item;
                }

                output[i] = product;
            }

            return output;
        }

        public int[] ProductExceptSelf3(int[] nums)
        {
            var output = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var numsToCalc = new List<int>(nums);

                numsToCalc.Remove(current);

                // Help: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate?view=netcore-3.1
                // This solution is slow
                output[i] = numsToCalc.Aggregate((currentValue, nextValue) => currentValue * nextValue); ;
            }

            return output;
        }
    }
}
