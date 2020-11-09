using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.Recursions
{
    public class Fibonacci
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/functional-programming-warmups-in-recursion---fibonacci-numbers/problem
         *      -> It is not available for C#
         * 
         * Strategy
         *      -> F(n) = (n - 1) + (n - 2)
         *      -> F(0) = 0
         *      -> F(1) = 1
         * 
         * NOTES: Helpful Link that explains recursions: https://en.wikipedia.org/wiki/Fibonacci_number
         *                                               https://www.c-sharpcorner.com/UploadFile/19b1bd/calculate-fibonacci-series-in-various-ways-using-C-Sharp/
         *                                               https://www.youtube.com/watch?v=e0CAbRVYAWg
         * 
         * IMPOTANT: Debug your code by talking out loud
         * 
         * Fib(2)
         *  -> return Fib(1) + Fib(0)
         *              1    +  0 = 1
         * We Can make this more efficient by storing the data in a array to save time and not have to call the Fib method all the time
         */

        public Dictionary<double, double> FibonacciSequence = new Dictionary<double, double>();

        public double Fib(double n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fib(n - 1) + Fib(n - 2);
        }

        public double Fib2(double n)
        {
            if (FibonacciSequence.ContainsKey(n))
            {
                return FibonacciSequence[n];
            }

            if (n == 0 || n == 1)
            {
                FibonacciSequence.Add(n, n);
                return n;
            }

            var value = Fib(n - 1) + Fib(n - 2);
            FibonacciSequence.Add(n, value);
            return value;
        }
    }
}
