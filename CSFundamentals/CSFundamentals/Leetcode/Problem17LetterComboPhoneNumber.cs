using System.Collections.Generic;
using System.Linq;

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

    public partial class Problem1428LeftmostWithAtleastOne
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/leftmost-column-with-at-least-a-one/
         * For more solutions: https://leetcode.com/problems/leftmost-column-with-at-least-a-one/solution/
         */

        class BinaryMatrix
        {
            // In Leetcode this is already implemented  but we are bring it as a dummy just to be able to use the object and it's functions
            // This is from Leetcode's comments
            // This is BinaryMatrix's API interface.
            // You should not implement it, or speculate about its implementation
            public int Get(int row, int col) { return 0; }
            public IList<int> Dimensions() { return new List<int>(); }
        }

        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {

        }
    }
}
