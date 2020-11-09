using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSFundamentals.Leetcode
{
    public class Problem49GroupAnagrams
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/group-anagrams/
         * For more solutions: https://leetcode.com/problems/group-anagrams/solution/
         */

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> returnValue = new List<IList<string>>();

            if (strs.Length == 1)
            {
                returnValue.Add(new List<string> { strs[0] });
                return returnValue;
            }

            // We need to het the character of the strings -> first one will be enough
            // This will give us the base for our anagram evaluation

            char[] tempSortedWord;
            var wordDictionary = new Dictionary<string, List<string>>();

            // This is not working
            foreach (var item in strs)
            {
                tempSortedWord = item.ToCharArray();
                Array.Sort(tempSortedWord);

                // We can re write this.
                if (wordDictionary.ContainsKey(string.Join("", tempSortedWord)))
                {
                    wordDictionary[string.Join("", tempSortedWord)].Add(item);
                }
                else
                {
                    wordDictionary.Add(string.Join("", tempSortedWord), new List<string> { item });
                }
            }

            foreach (var item in wordDictionary)
            {
                returnValue.Add(item.Value);
            }

            return returnValue;
        }

        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            IList<IList<string>> returnValue = new List<IList<string>>();

            if (strs.Length == 1)
            {
                returnValue.Add(new List<string> { strs[0] });
                return returnValue;
            }

            // We need to het the character of the strings -> first one will be enough
            // This will give us the base for our anagram evaluation

            char[] tempSortedWord;
            var wordDictionary = new Dictionary<string, List<string>>();

            // This is not working
            foreach (var item in strs)
            {
                tempSortedWord = item.ToCharArray();
                Array.Sort(tempSortedWord);

                if (wordDictionary.ContainsKey(string.Join("", tempSortedWord)))
                {
                    wordDictionary[string.Join("", tempSortedWord)].Add(item);
                }
                else
                {
                    List<string> tempList = new List<string> { item };
                    wordDictionary.Add(string.Join("", tempSortedWord), tempList);
                    returnValue.Add(tempList);
                }
            }

            return returnValue;
        }
    }
}
