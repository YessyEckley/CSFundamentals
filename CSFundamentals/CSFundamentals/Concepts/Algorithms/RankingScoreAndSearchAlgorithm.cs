using System;

namespace CSFundamentals.Concepts.Algorithms
{
    public class RankingScoreAndSearchAlgorithm
    {
        private const int CHAR_MAX = 256;

        public int GetSearchRankScore(string text, string pattern, int bonus = 0)
        {
            var baseRank = 100 + bonus;
            var elementLocation = FuzzySearchString(text.ToLower().Trim(), pattern.ToLower().Trim());

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

        private int FuzzySearchString(string text, string pattern, int levenshteinDistance = 0)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pattern))
                {
                    return -1;
                }

                var m = pattern.Length;
                var R = new int[(levenshteinDistance + 1) * sizeof(int)];
                var patternMask = new int[CHAR_MAX + 1];
                int i;

                if (m > 31)
                {
                    if (text.Length == pattern.Length)
                    {
                        return BitapSearch(text.Substring(0, 31).ToLower().Trim(), pattern.Substring(0, 31).ToLower().Trim());
                    }

                    return -1;
                }

                for (i = 0; i <= levenshteinDistance; i++)
                {
                    R[i] = ~1;
                }

                for (i = 0; i <= CHAR_MAX; i++)
                {
                    patternMask[i] = ~0;
                }

                for (i = 0; i < m; i++)
                {
                    patternMask[pattern[i]] &= ~(1 << i);
                }

                for (i = 0; i < text.Length; i++)
                {
                    var oldR = R[0];

                    R[0] |= patternMask[text[i]];
                    R[0] <<= 1;

                    for (var d = 1; d <= levenshteinDistance; d++)
                    {
                        var tmp = R[d];

                        R[d] = (oldR & (R[d] | patternMask[text[i]])) << 1;
                        oldR = tmp;
                    }

                    if (0 == (R[levenshteinDistance] & (1 << m)))
                    {
                        return (i - m) + 1;
                    }
                }

                return -1;
            }
            catch (Exception e)
            {
                var message = $"FuzzySearchString encountered a problem for Text: {text} - Pattern: {pattern} - {e.Message}";

                return -1;
            }
        }

        private int BitapSearch(string text, string pattern)
        {
            try
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
            catch (Exception e)
            {
                var message = $"BitapSearch encountered a problem for Text: {text} - Pattern: {pattern} - {e.Message}";

                return -1;
            }
        }
    }
}
