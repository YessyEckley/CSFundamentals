using System;
using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem8Atoi
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/string-to-integer-atoi/
         * For more solutions: https://leetcode.com/problems/string-to-integer-atoi/solution/
         * 
         * Important: this exercise is only meant to return an integer
         *      -> If the number has decimal points it should only return the integer value
         *      -> the problem is only asking for integers, so be careful
         */

        // Approach #1
        public static int MyAtoi(string s)
        {
            // We can also iterrate through the string to eliminate the string and ignore the whitespaces
            s = s.Replace(" ", "");
            //s = s.TrimStart(); // This is another option

            if (s.Length == 0)
            {
                return 0;
            }

            var sign = 1;
            var returnIntValue = 0;
            var index = 0;

            if (s[index] == '+' || s[index] == '-')
            {
                sign = s[index++] == '-' ? -1 : 1;
            }

            // Build the result
            while (index < s.Length && s[index] >= '0' && s[index] <= '9')
            {
                if (returnIntValue > int.MaxValue / 10 ||
                    (returnIntValue == int.MaxValue / 10 && s[index] - '0' > int.MaxValue % 10))
                {
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }

                returnIntValue = returnIntValue * 10 + (s[index++] - '0');
            }

            return returnIntValue * sign;
        }
    }
}
