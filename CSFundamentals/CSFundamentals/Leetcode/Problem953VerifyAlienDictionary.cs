using System;

namespace CSFundamentals.Leetcode
{
    public class Problem953VerifyAlienDictionary
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/verifying-an-alien-dictionary/
         * For more solutions: https://leetcode.com/problems/verifying-an-alien-dictionary/solution/
         */

        // Approach #1
        public bool IsAlienSorted1(string[] words, string order)
        {
            if (words.Length == 1)
            {
                return true;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];

                if (word1.Length > word2.Length && word1.StartsWith(word2))
                {
                    return false;
                }

                for (int y = 0; y < Math.Min(word1.Length, word2.Length); y++)
                {
                    if (word1[y] != word2[y])
                    {
                        if (order.IndexOf(word1[y]) > order.IndexOf(word2[y]))
                        {
                            return false;
                        }

                        break;
                    }
                }
            }

            return true;
        }

        // Approach #2 - faster
        public bool IsAlienSorted2(string[] words, string order)
        {
            var orderIndex = new int[26];

            for (int i = 0; i < order.Length; i++)
            {
                orderIndex[order[i] - 'a'] = i;
            }

            if (words.Length == 1)
            {
                return true;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];

                if (word1.Length > word2.Length && word1.StartsWith(word2))
                {
                    return false;
                }

                for (int y = 0; y < Math.Min(word1.Length, word2.Length); y++)
                {
                    if (word1[y] != word2[y])
                    {
                        if (orderIndex[word1[y] - 'a'] > orderIndex[word2[y] - 'a'])
                        {
                            return false;
                        }

                        break;
                    }
                }
            }

            return true;
        }
    }
}
