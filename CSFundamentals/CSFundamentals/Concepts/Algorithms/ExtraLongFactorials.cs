using System;
using System.Numerics;

namespace CSFundamentals.Concepts.Algorithms
{
    public class ExtraLongFactorials
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/extra-long-factorials/problem
         */

        public static BigInteger ExtraLongFactorialsCalculate(int n)
        {
            var factorial = new BigInteger(n);

            for (var i = n - 1; i > 0; i--)
            {
                factorial = factorial * i;
            }

            return factorial;
        }

        public static void ExtraLongFactorialsWorker() 
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(ExtraLongFactorialsCalculate(n));
        }

        public static BigInteger ExtraLongFactorialsRecursive(int n)
        {
            var factorial = new BigInteger(1);

            if (n == 1)
            {
                return n;
            }

            factorial = n * ExtraLongFactorialsRecursive(n - 1);

            return factorial;
        }

        // There is another way to do the big integer algorithm using strings
        // Here are some explanations on how to do it
        // https://www.geeksforgeeks.org/multiply-large-numbers-represented-as-strings/
        // https://www.geeksforgeeks.org/sum-two-large-numbers/
    }
}
