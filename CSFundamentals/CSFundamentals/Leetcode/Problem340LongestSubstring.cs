using System;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Leetcode
{
    public class Problem340LongestSubstring
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
         * For more solutions: https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/solution/
         * 
         * This can provide some help: https://www.geeksforgeeks.org/window-sliding-technique/
         */

        // Approach -> Slidding Window -> in c# we cannot rely on the order of a dictionary
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (k == 0 || s.Length == 0)
            {
                return 0;
            }

            var maxLength = 1;
            var left = 0;
            var right = 0;
            var dictionary = new Dictionary<char, int>(k);

            while (right < s.Length)
            {
                if (dictionary.ContainsKey(s[right]))
                {
                    dictionary.Remove(s[right]);
                }

                dictionary.Add(s[right], right++);

                if (dictionary.Count == k + 1)
                {
                    var leftEntry = dictionary.FirstOrDefault(x => x.Value == dictionary.Values.Min());
                    dictionary.Remove(leftEntry.Key);
                    left = leftEntry.Value + 1;
                }

                maxLength = Math.Max(maxLength, right - left);
            }

            return maxLength;
        }
    }
}
