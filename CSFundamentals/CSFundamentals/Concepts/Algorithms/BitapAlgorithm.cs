using System;
using System.Collections;

namespace CSFundamentals.Concepts.Algorithms
{
    public class BitapAlgorithm
    {
        /*
         * Resource: https://en.wikipedia.org/wiki/Bitap_algorithm
         *           https://www.programmingalgorithms.com/algorithm/bitap-algorithm/
         * 
         * Other: https://stackoverflow.com/questions/19569441/returning-most-relevant-search-results-using-linq-where-take
         *        https://en.wikipedia.org/wiki/Approximate_string_matching
         *        https://en.wikipedia.org/wiki/String-searching_algorithm
         *        https://www.codeproject.com/Articles/36869/Fuzzy-Search
         *        https://docs.microsoft.com/en-us/sql/relational-databases/system-functions/containstable-transact-sql?view=sql-server-ver15
         */

        public const int CHAR_MAX = 127;

        public static int BitapSearch(string text, string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                return -1;
            }

            var m = pattern.Length;

            if (m > 31)
            {
                return -1;
            }

            var patternMask = new int[CHAR_MAX + 1];
            var R = ~1;

            for (int i = 0; i <= CHAR_MAX; i++)
            {
                patternMask[i] = ~0;
            }

            for (int i = 0; i < m; i++)
            {
                patternMask[pattern[i]] &= ~(1 << i);
            }

            for (int i = 0; i < text.Length; i++)
            {
                R |= patternMask[text[i]];
                R <<= 1;

                if (0 == (R & (1 << m)))
                {
                    return (i - m) + 1;
                }
            }

            return -1;
        }

        public static int GetSearchRankScore(string text, string pattern, int baseRank)
        {
            var elementLocation = BitapSearch(text.ToLower(), pattern.ToLower());

            if (elementLocation == 0)
            {
                if (text.Length == pattern.Length)
                {
                    baseRank += 100;
                }
                else
                {
                    baseRank += 10;
                }
            }
            else if (elementLocation > 0)
            {
                baseRank -= elementLocation;
            }
            else
            {
                baseRank -= 100;
            }

            return baseRank;
        }
    }
}
