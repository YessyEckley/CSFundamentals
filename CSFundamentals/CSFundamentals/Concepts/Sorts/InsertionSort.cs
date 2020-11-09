using System;
namespace CSFundamentals.Concepts.Sorts
{
    public class InsertionSort
    {
        /*
         * Resources: https://en.wikipedia.org/wiki/Insertion_sort
         *            
         */
        public void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }

        public void Swap<T>(T[] array, int first, int second)
        {
            var current = array[first];
            array[first] = array[second];
            array[second] = current;
        }

        public void Display()
        {
            var integerValues = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            (new InsertionSort()).Sort<int>(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            var stringValues = new string[] { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            (new InsertionSort()).Sort<string>(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }
    }
}
