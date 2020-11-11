namespace CSFundamentals.Leetcode
{
    public class Problem680ValidPalindromeII
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/valid-palindrome-ii/
         * For more solutions: https://leetcode.com/problems/valid-palindrome-ii/solution/
         * 
         * 
         * abca
         * 
         * ebcbb e cecabbacec bbcbe
         */

        // Approach #1
        public bool ValidPalindrome(string s)
        {
            if (s.Length <= 1)
            {
                return true;
            }

            var middle = s.Length / 2;

            for (int i = 0; i < middle; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    var j = s.Length - 1 - i;

                    return IsInRange(s, i + 1, j) || IsInRange(s, i, j - 1);
                }
            }

            return true;
        }

        private bool IsInRange(string s, int i, int j)
        {
            for (int k = i; k <= i + (j - i) / 2; k++)
            {
                if (s[k] != s[j - k + i])
                {
                    return false;
                }
            }

            return true;
        }

        // Approach #2 - this one performs a bit faster
        public bool ValidPalindrome2(string s)
        {
            if (s.Length <= 1)
            {
                return true;
            }

            var lower = 0;
            var upper = s.Length - 1;

            while (lower <= upper)
            {
                if (s[lower] != s[upper])
                {
                    return ValidateSkip(s, lower, upper - 1) || ValidateSkip(s, lower + 1, upper);
                }

                lower++;
                upper--;
            }

            return true;
        }

        private bool ValidateSkip(string s, int lower, int upper)
        {
            while (lower <= upper)
            {
                if (s[lower] != s[upper])
                {
                    return false;
                }

                lower++;
                upper--;
            }

            return true;
        }
    }
}
