using System;
namespace CSFundamentals.Concepts.Sorts
{
    public class SelectionSort
    {
        // Approach #1
        public void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;
                var minValue = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                Swap(array, i, minIndex);
            }
        }

        // Approach #2
        public void Sort2<T>(T[] array) where T : IComparable
        {
            var size = array.Length;
            int max;

            for (int i = 0; i < size - 1; i++)
            {
                max = 0;
                for (int j = 1; j < size - 1 - i; j++)
                {
                    if (array[j].CompareTo(array[max]) > 0)
                    {
                        max = j;
                    }
                }
                Swap(array, i, max);
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
            (new SelectionSort()).Sort<int>(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            var stringValues = new string[] { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            (new SelectionSort()).Sort<string>(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));

            (new SelectionSort()).Sort2<int>(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            (new SelectionSort()).Sort2<string>(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }
    }
}
