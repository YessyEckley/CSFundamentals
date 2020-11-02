using System;
using System.Text;

namespace CSFundamentals.Leetcode
{
    public class Problem67AddBinary
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/add-binary/
         * For more solutions: https://leetcode.com/problems/add-binary/solution/
         */

        public static string AddBinary(string a, string b)
        {
            // This solution will not pass all of the Leetcode's test cases due to the binary being too big and out of scope to be translated
            var aValue = Convert.ToInt64(a, 2);
            var bValue = Convert.ToInt64(b, 2);

            return Convert.ToString(aValue + bValue, 2);
        }

        public static string AddBinary2(string a, string b)
        {
            var sb = new StringBuilder();
            var carry = 0;
            var aIndex = a.Length - 1;
            var bIndex = b.Length - 1;

            while (aIndex >= 0 || bIndex >= 0)
            {
                var binarySum = carry;

                if (aIndex >= 0)
                {
                    binarySum += (a[aIndex] - '0');
                    aIndex--;
                }

                if (bIndex >= 0)
                {
                    binarySum += (b[bIndex] - '0');
                    bIndex--;
                }

                sb.Insert(0, binarySum % 2);
                carry = binarySum / 2;
            }

            if (carry > 0)
            {
                sb.Insert(0, carry);
            }

            return sb.ToString();
        }
    }
}
