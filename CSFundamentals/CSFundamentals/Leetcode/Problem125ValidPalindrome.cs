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

            var noCaseString = s.ToLower().Replace(" ", "");
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
    }
}
