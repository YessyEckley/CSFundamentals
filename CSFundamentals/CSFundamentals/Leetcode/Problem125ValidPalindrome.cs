using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Leetcode
{
    public class Problem125ValidPalindrome
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/valid-palindrome/
         * For more solutions: https://leetcode.com/problems/valid-palindrome/solution/
         */

        public static bool IsPalindrome(string s)
        {
            if (s.Length == 0)
            {
                return true;
            }

            var noCaseString = s.ToLower();
            //var noCaseString = s.ToLower().Replace(" ", ""); // If we add the replace it seems to perform slower
            var upperIndex = noCaseString.Length - 1;
            var lowerIndex = 0;

            while (lowerIndex <= upperIndex)
            {
                if (!char.IsLetterOrDigit(noCaseString[upperIndex]))
                {
                    upperIndex--;
                    continue;
                }

                if (!char.IsLetterOrDigit(noCaseString[lowerIndex]))
                {
                    lowerIndex++;
                    continue;
                }

                if (noCaseString[upperIndex] != noCaseString[lowerIndex])
                {
                    return false;
                }

                upperIndex--;
                lowerIndex++;
            }

            return true;
        }

        // Approach #2 using Linq but it didn't perform that good
        public static bool IsPalindrome2(string s)
        {
            var newString = string.Join("", s.Where(x => char.IsLetterOrDigit(x)).Select(s => char.ToLower(s)));

            return newString.Equals(string.Join("", newString.Reverse()));
        }
    }
}
