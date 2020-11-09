using System;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class AVeryBigSum
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/a-very-big-sum/problem
         */

        public long AVeryBigSumLogic(long[] ar)
        {
            var result = 0L;

            foreach (var valueToCalculate in ar)
            {
                result += valueToCalculate;
            }

            return result;
        }

        public void AVeryBigSumWorker()
        {
            Console.WriteLine("A Very Big Sum: Enter a size.");
            int arCount = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("A Very Big Sum: Enter a big numbers separated by spaces.");
            long[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt64(arTemp));
            long result = AVeryBigSumLogic(ar);

            Console.WriteLine($"Result: {result}");
        }
    }
}
