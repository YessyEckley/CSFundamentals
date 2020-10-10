using System;
namespace CSFundamentals.Concepts.Sorts
{
    public class QuickSort
    {
        // QuickSort and MergeSort look very similar

        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }

        public static T[] Sort<T>(T[] array, int lowerIndex, int upperIndex) where T : IComparable
        {
            if (lowerIndex < upperIndex)
            {
                var partition = Partition(array, lowerIndex, upperIndex);
                Sort(array, lowerIndex, partition);
                Sort(array, partition + 1, upperIndex);
            }

            return array;
        }

        private static int Partition<T>(T[] array, int lowerIndex, int upperIndex) where T : IComparable
        {
            var lower = lowerIndex;
            var upper = upperIndex;

            var pivot = array[lowerIndex];
            // or
            //var pivot = array[lowerIndex + upperIndex] / 2;

            do // Hoare partition scheme
            {
                while (array[lower].CompareTo(pivot) < 0)
                {
                    lower++;
                }

                while (array[upper].CompareTo(pivot) > 0)
                {
                    upper--;
                }

                if (lower >= upper)
                {
                    break;
                }

                Swap(array, lower, upper);
            } while (lower <= upper);

            return upper;
        }

        private static void QuickSortUtil<T>(T[] array, int lowerIndex, int upperIndex) where T : IComparable
        {
            if (upperIndex <= lowerIndex)
            {
                return;
            }

            var start = lowerIndex;
            var stop = upperIndex;
            var pivot = array[lowerIndex];

            while(lowerIndex < upperIndex)
            {
                while (array[lowerIndex].CompareTo(pivot) < 0)
                {
                    lowerIndex++;
                }

                while (array[upperIndex].CompareTo(pivot) > 0)
                {
                    upperIndex--;
                }

                if (lowerIndex < upperIndex)
                {
                    Swap(array, upperIndex, lowerIndex);
                }
            }

            Swap(array, upperIndex, start);

            QuickSortUtil(array, start, upperIndex - 1);
            QuickSortUtil(array, upperIndex + 1, stop);
        }

        public static void Swap<T>(T[] array, int first, int second)
        {
            var current = array[first];
            array[first] = array[second];
            array[second] = current;
        }

        public void Display()
        {
            var integerValues = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            QuickSort.Sort<int>(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            var stringValues = new string[] { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            QuickSort.Sort<string>(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }
    }
}
