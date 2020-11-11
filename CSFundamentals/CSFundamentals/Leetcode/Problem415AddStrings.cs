using System;
using System.Text;

namespace CSFundamentals.Leetcode
{
    //public class Problem560SubarraySumIsK
    //{
    //    /*
    //     * Leetcode problem: https://leetcode.com/problems/subarray-sum-equals-k/
    //     * For more solutions: https://leetcode.com/problems/subarray-sum-equals-k/solution/
    //     */
    //}

    public class Problem415AddStrings
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/add-strings/
         * For more solutions: https://leetcode.com/problems/add-strings/solution/
         * 
         * 5 + 10 -> 05 + 10
         */

        public string AddStrings1(string num1, string num2)
        {
            var maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');
            var carry = 0;
            var sb = new StringBuilder();

            for (int i = maxLength - 1; i >= 0; i--)
            {
                carry = (num1[i] - '0') + (num2[i] - '0') + carry;

                sb.Insert(0, carry % 10);

                carry = carry / 10;
            }

            if (carry > 0)
            {
                sb.Insert(0, carry);
            }

            return sb.ToString();
        }

        public string AddStrings2(string num1, string num2)
        {
            var num1Pointer = num1.Length - 1;
            var num2Pointer = num2.Length - 1;
            var carry = 0;
            var sb = new StringBuilder();

            while (num1Pointer >= 0 || num2Pointer >= 0)
            {
                carry = (num1Pointer >= 0 ? (num1[num1Pointer] - '0') : 0) +
                        (num2Pointer >= 0 ? (num2[num2Pointer] - '0') : 0) +
                        carry;

                sb.Insert(0, carry % 10);

                carry = carry / 10;

                num1Pointer--;
                num2Pointer--;
            }

            if (carry > 0)
            {
                sb.Insert(0, carry);
            }

            return sb.ToString();
        }
    }
}
