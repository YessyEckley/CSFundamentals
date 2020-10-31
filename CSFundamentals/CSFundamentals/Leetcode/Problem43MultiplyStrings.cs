namespace CSFundamentals.Leetcode
{
    public class Problem43MultiplyStrings
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/multiply-strings/
         */

        public static string Multiply(string num1, string num2)
        {
            /*
             * Good strategy is to not panic.
             * This exercise is a recreation of how we do this computation in paper
             * 
             * -> We create an array that is double the size of the length of the two strings
             * -> Then we create a loop for num1 and we nest the loop for num2
             * -> Our product is the multiplication of our numbers at a particular index plus the sum of any carry over
             * -> Then we assign the modulus to our farthest element we are evaluating and we add our carry over to the closest element
             * -> Then we just need to join the results and trim any leading 0
             */

            if (string.IsNullOrWhiteSpace(num1) || string.IsNullOrWhiteSpace(num2) || num1.Equals("0") || num2.Equals("0"))
            {
                return "0";
            }

            var result = new int[num1.Length + num2.Length];

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int y = num2.Length - 1; y >= 0; y--)
                {
                    var product = (num1[i] - '0') * (num2[y] - '0') + result[i + y + 1];

                    result[i + y + 1] = product % 10;
                    result[i + y] += product / 10;
                }
            }

            var returnString = string.Join("", result);
            return returnString.TrimStart('0');
        }
    }
}
