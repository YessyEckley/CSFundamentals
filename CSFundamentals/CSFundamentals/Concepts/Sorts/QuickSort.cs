using System;
namespace CSFundamentals.Concepts.Sorts
{
    public class QuickSort
    {
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
            var i = lowerIndex;
            var j = upperIndex;

            var pivot = array[lowerIndex];
            // or
            //var pivot = array[lowerIndex + upperIndex] / 2;

            do // Hoare partition scheme
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                Swap(array, i, j);
            } while (i <= j);

            return j;
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
