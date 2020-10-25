using System.Collections.Generic;

namespace CSFundamentals.Concepts.Recursions
{
    public class Factorial
    {
        /*
         * Strategy
         *      -> F(n)! = n * (n - 1)!
         *      -> F(0) = 1
         *      -> F(1) = 1
         * 
         * NOTES: Helpful Link that explains recursions: https://www.youtube.com/watch?v=B0NtAFf4bvU
         *                                               https://en.wikipedia.org/wiki/Factorial
         * 
         * IMPOTANT: Debug your code by talking out loud
         */

        public static Dictionary<double, double> FactorialSequence = new Dictionary<double, double>();

        public static double Fact(double n)
        {
            if (FactorialSequence.ContainsKey(n))
            {
                return FactorialSequence[n];
            }

            if (n == 0)
            {
                FactorialSequence.Add(n, n);
                return 1;
            }

            double value = n * Fact(n - 1);
            FactorialSequence.Add(n, value);
            return value;
        }
    }
}
