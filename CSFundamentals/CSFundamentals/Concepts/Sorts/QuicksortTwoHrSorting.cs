using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Concepts.Sorts
{
    public class QuicksortTwoHrSorting
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/quicksort2/problem
         * 
         * Resource: https://en.wikipedia.org/wiki/Quicksort
         *           https://www.geeksforgeeks.org/quick-sort/
         * 
         * Strategy
         *      -> Array of 1 or less are sorted
         *      -> First element is the pivot
         *      
         *      -> We need to print the subarray after the partition method of the Quicksort finishes
         *      -> Partition the left and then right
         *      -> When merging the pivot goes in between the subarrays
         *      
         * IMPORTANT:
         */

        public static void QuickSort(int[] ar)
        {
            if (ar.Length < 2)
            {
                Console.WriteLine(string.Join(" ", ar));
            }

            Sort(ar, 0, ar.Length - 1);
        }

        private static void Sort(int[] ar, int lowerIndex, int upperIndex)
        {
            if (lowerIndex >= upperIndex)
            {
                return;
            }

            var partition = Partition(ar, lowerIndex, upperIndex);

            Sort(ar, lowerIndex, partition - 1);
            Sort(ar, partition + 1, upperIndex);

            PrintArray(ar, lowerIndex, upperIndex);
        }


        private static void PrintArray(int[] ar, int lowerIndex, int upperIndex)
        {
            for (int i = lowerIndex; i <= upperIndex; i++)
            {
                Console.Write($"{ar[i]} ");
            }

            Console.WriteLine();
        }


        private static int Partition(int[] ar, int lowerIndex, int upperIndex)
        {
            var pivot = ar[lowerIndex];
            var leftList = new List<int>();
            var rightList = new List<int>();

            for (int i = lowerIndex + 1; i <= upperIndex; i++)
            {
                if (ar[i] < pivot)
                {
                    leftList.Add(ar[i]);
                }
                else
                {
                    rightList.Add(ar[i]);
                }
            }

            Copy(leftList, ar, lowerIndex);

            var pivotIndex = leftList.Count + lowerIndex;

            ar[pivotIndex] = pivot;

            Copy(rightList, ar, pivotIndex + 1);

            return pivotIndex;
        }


        private static void Copy(List<int> list, int[] ar, int lowerIndex)
        {
            foreach (var element in list)
            {
                ar[lowerIndex] = element;
                lowerIndex++;
            }
        }
    }
}