using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Leetcode
{
    public class Problem3LongestSubstring
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/longest-substring-without-repeating-characters/
         */


        /* Approach #1 -> fast performing 
         * This approach uses a dictionary to find the solution.
         * We need to remember this is a search solution.
         */
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            var charDictionary = new Dictionary<char, int>();
            var returnValue = 0;
            var i = 0;

            for (var j = 0; j < s.Length; j++)
            {
                if (charDictionary.ContainsKey(s[j]))
                {
                    i = Math.Max(charDictionary[s[j]], i);
                    charDictionary[s[j]] = j + 1;
                }
                else
                {
                    charDictionary.Add(s[j], j + 1);
                }

                returnValue = Math.Max(returnValue, j - i + 1);
            }

            return returnValue;
        }


        /* Approach #2 -> fast performing 
         * This approach uses an array to find the solution.
         * We need to remember this is a search solution.
         * We can use the charValue - 'a' logic to assign and find the index of the array
         */
        public int LengthOfLongestSubstring2(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            var charDictionary = new int[256];
            var returnValue = 0;
            var i = 0;

            for (var j = 0; j < s.Length; j++)
            {
                i = Math.Max(charDictionary[s[j]], i);

                charDictionary[s[j]] = j + 1;

                returnValue = Math.Max(returnValue, j - i + 1);
            }

            return returnValue;
        }
    }
}
