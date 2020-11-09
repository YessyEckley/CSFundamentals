using System.Text;

namespace CSFundamentals.Leetcode
{
    public class Problem273IntegerToEnglish
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/integer-to-english-words/
         * For more solutions: https://leetcode.com/problems/integer-to-english-words/solution/
         * 
         * We need to identify edge cases
         *  -> 0-19 -> have their own case
         *  -> 20-90 (counting by ten) have their own case
         *  -> Hundred (100, 200 ...) -> it will reuse the previous cases
         *                        
         *  possible results 0 to 2,147,483,647
         *                        1,000,000,000 Billion
         *                            1,000,000 Million
         *                                1,000 Thousand
         *                                  100 Hundred
         * 1,000,010
         * 
         * 1234567891 -> 1,234,567,891
         * 
         * 1234567891 / 1000000000 = 1
         * 1234567891 % 1000000000 = 234567891
         *      234567891 / 1000000 = 234
         *      234567891 % 1000000 = 567891
         *          234 / 100 = 2
         *          234 % 100 = 34
         *              34 / 10 = 3
         *              34 % 10 = 4
         *          567891 / 1000 = 567
         *          567891 % 1000 = 891
         *              567 / 100 = 5
         *              567 % 100 = 67
         *                  67 / 10 = 6
         *                  67 % 10 7
         *              891 / 100 = 8
         *              891 % 100 = 91
         *                  91 / 10 = 9
         *                  91 % 10 = 1
         */

        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }
            var sb = new StringBuilder();
            var tempNum = num;

            if (tempNum >= 1000000000)
            {
                sb.Append($"{StringifyingNum(num / 1000000000)} Billion "); // This is safe because we can only go up to two Billion
                tempNum = num % 1000000000;
            }

            if (tempNum >= 1000000)
            {
                CalcHundredOrLess(tempNum / 1000000, sb);
                sb.Append("Million ");
                tempNum = tempNum % 1000000;
            }

            if (tempNum >= 1000)
            {
                CalcHundredOrLess(tempNum / 1000, sb);
                sb.Append("Thousand ");
                CalcHundredOrLess(tempNum % 1000, sb);

            }

            if (tempNum < 1000)
            {
                CalcHundredOrLess(tempNum, sb);
            }

            return sb.ToString().Trim();
        }

        private void CalcHundredOrLess(int num, StringBuilder sb)
        {
            var tempNum = num;

            if (tempNum >= 100)
            {
                sb.Append($"{StringifyingNum(num / 100)} Hundred ");
                tempNum = num % 100;
            }

            if (tempNum >= 10 && tempNum <= 19)
            {
                sb.Append($"{StringifyingTeens(tempNum)} ");
            }
            else if (tempNum >= 20)
            {
                sb.Append($"{StringifyingTenthsOverTwenty(tempNum / 10)} ");
                tempNum = tempNum % 10;
            }

            if (tempNum < 10 && tempNum > 0)
            {
                sb.Append($"{StringifyingNum(tempNum)} ");
            }
        }

        private string StringifyingNum(int num)
        {
            var returnStringValue = string.Empty;

            switch (num)
            {
                case 1:
                    returnStringValue = "One";
                    break;
                case 2:
                    returnStringValue = "Two";
                    break;
                case 3:
                    returnStringValue = "Three";
                    break;
                case 4:
                    returnStringValue = "Four";
                    break;
                case 5:
                    returnStringValue = "Five";
                    break;
                case 6:
                    returnStringValue = "Six";
                    break;
                case 7:
                    returnStringValue = "Seven";
                    break;
                case 8:
                    returnStringValue = "Eight";
                    break;
                case 9:
                    returnStringValue = "Nine";
                    break;
                default:
                    break;
            }

            return returnStringValue;
        }

        private string StringifyingTeens(int num)
        {
            var returnStringValue = string.Empty;

            switch (num)
            {
                case 10:
                    returnStringValue = "Ten";
                    break;
                case 11:
                    returnStringValue = "Eleven";
                    break;
                case 12:
                    returnStringValue = "Twelve";
                    break;
                case 13:
                    returnStringValue = "Thirteen";
                    break;
                case 14:
                    returnStringValue = "Fourteen";
                    break;
                case 15:
                    returnStringValue = "Fifteen";
                    break;
                case 16:
                    returnStringValue = "Sixteen";
                    break;
                case 17:
                    returnStringValue = "Seventeen";
                    break;
                case 18:
                    returnStringValue = "Eighteen";
                    break;
                case 19:
                    returnStringValue = "Nineteen";
                    break;
                default:
                    break;
            }

            return returnStringValue;
        }

        private string StringifyingTenthsOverTwenty(int num)
        {
            var returnStringValue = string.Empty;

            switch (num)
            {
                case 2:
                    returnStringValue = "Twenty";
                    break;
                case 3:
                    returnStringValue = "Thirty";
                    break;
                case 4:
                    returnStringValue = "Forty";
                    break;
                case 5:
                    returnStringValue = "Fifty";
                    break;
                case 6:
                    returnStringValue = "Sixty";
                    break;
                case 7:
                    returnStringValue = "Seventy";
                    break;
                case 8:
                    returnStringValue = "Eighty";
                    break;
                case 9:
                    returnStringValue = "Ninety";
                    break;
                default:
                    break;
            }

            return returnStringValue;
        }
    }
}
