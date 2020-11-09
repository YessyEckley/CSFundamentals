using System;
namespace CSFundamentals.Concepts.Sorts
{
    public class InsertionSortHrPartTwo
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/insertionsort2/problem
         * 
         * Strategy
         *      -> We need to iterrate through n number of elements of the array
         *      -> Before we beging, we need to print the Array that was passed
         *      -> Print each sort swap
         * 
         * IMPOTANT: Debug your code by talking out loud
         */

        public void InsertionSort2(int n, int[] arr)
        {
            for (var i = 1; i < n; i++)
            {
                var countdown = i;

                while (countdown > 0 && arr[countdown] < arr[countdown - 1])
                {
                    // Swap values
                    var tempValue = arr[countdown];
                    arr[countdown] = arr[countdown - 1];
                    arr[countdown - 1] = tempValue;

                    // decrement the countdown
                    countdown--;
                }

                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
