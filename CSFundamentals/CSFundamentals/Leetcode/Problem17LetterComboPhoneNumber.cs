using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem17LetterComboPhoneNumber
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/letter-combinations-of-a-phone-number/
         * For more solutions: https://leetcode.com/problems/letter-combinations-of-a-phone-number/solution/
         * Resource: https://en.wikipedia.org/wiki/Backtracking
         * 
         * digits.length is between 0 and 4
         * The range of the individual digits is between 2 and 9
         */

        public Dictionary<int, string> NumberToChar = new Dictionary<int, string>()
        {
            { 2, "abc" },
            { 3, "def" },
            { 4, "ghi" },
            { 5, "jkl" },
            { 6, "mno" },
            { 7, "pqrs" },
            { 8, "tuv" },
            { 9, "wxyz" }
        };

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> returnValue = new List<string>();

            if (digits.Length == 0)
            {
                return returnValue;
            }

            LetterCombination(digits, "", returnValue);

            return returnValue;
        }

        private void LetterCombination(string nextDigits, string combination, IList<string> values)
        {
            if (nextDigits.Length == 0)
            {
                values.Add(combination);
                return;
            }

            var numberValues = NumberToChar[nextDigits[0] - '0'];

            foreach (var letter in numberValues)
            {
                LetterCombination(nextDigits.Substring(1), combination + letter, values);
            }
        }
    }

    public class Problem76MinimumWindowSubstring
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/minimum-window-substring/
         * For more solutions: https://leetcode.com/problems/minimum-window-substring/solution/
         * 
         * This can provide some help: https://www.geeksforgeeks.org/window-sliding-technique/
         */

        public string MinWindow(string s, string t)
        {
            var result = "";

            return result;
        }
    }
}
