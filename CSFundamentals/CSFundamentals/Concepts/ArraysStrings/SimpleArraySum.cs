using System;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class SimpleArraySum
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/simple-array-sum/problem
         */

        public static int SimpleArraySumLong(int[] ar)
        {
            var sum = 0;

            foreach (var arVal in ar)
            {
                sum += arVal;
            }

            return sum;
        }

        public static int SimpleArraySumUsingArraySum(int[] ar)
        {
            return ar.Sum(); // But this is using Linq
        }
    }
}
