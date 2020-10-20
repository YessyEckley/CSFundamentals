using System;
namespace CSFundamentals.Concepts.Sorts
{
    public class QuickSortTwo
    {
        /*
         * 
         * Resource: https://en.wikipedia.org/wiki/Quicksort
         *           https://www.geeksforgeeks.org/quick-sort/
         *           https://www.geeksforgeeks.org/quicksort-on-singly-linked-list/
         *           https://www.geeksforgeeks.org/quicksort-for-linked-list/
         *           
         * IMPORTANT: This sort uses the higher index to do the sorting, if we try to do the lower index it will break
         */

        public static void QuickSort(int[] ar)
        {
            if (ar.Length <= 1)
            {
                // We are doing thos because it will handle gracefully arrays with lenght = 0
                Console.WriteLine(string.Join(" ", ar));
            }

            Sort(ar, 0, ar.Length - 1);
        }

        private static int[] Sort(int[] ar, int lowerIndex, int upperIndex)
        {
            if (lowerIndex < upperIndex)
            {
                var partitionIndex = Partition(ar, lowerIndex, upperIndex);

                Sort(ar, lowerIndex, partitionIndex - 1);
                Sort(ar, partitionIndex + 1, upperIndex);
            }

            return ar;
        }

        private static int Partition(int[] ar, int low, int high)
        {
            var pivot = ar[high];

            var i = low;

            for (int j = low; j < high; j++)
            {
                if (ar[j] < pivot)
                {
                    var temp = ar[i];
                    ar[i] = ar[j];
                    ar[j] = temp;

                    i++;
                }
            }

            var temp2 = ar[i];
            ar[i] = ar[high];
            ar[high] = temp2;

            return i;
        }
    }
}
