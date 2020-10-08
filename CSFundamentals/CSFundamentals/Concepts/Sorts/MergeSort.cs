using System;
namespace CSFundamentals.Concepts.Sorts
{
    public class MergeSort
    {
        public MergeSort()
        {
        }

        public static void Sort(int[] array)
        {
            var tempArray = new int[array.Length];

            Sort(array, tempArray, 0, array.Length - 1);
        }

        public static void Sort(int[] array, int[] tempArray, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
            {
                return;
            }

            var middle = (leftStart + rightEnd) / 2;

            Sort(array, tempArray, leftStart, middle);
            Sort(array, tempArray, middle + 1, rightEnd);

            MergeHalves(array, tempArray, leftStart, rightEnd);
        }

        public static void MergeHalves(int[] array, int[] tempArray, int leftStart, int rightEnd)
        {
            var leftEnd = (leftStart + rightEnd) / 2;
            var rightStart = leftEnd + 1;
            var size = rightEnd - leftStart + 1;

            var leftIndex = leftStart;
            var rightIndex = rightStart;
            var index = leftStart;

            while (leftIndex <= leftEnd && rightIndex <= rightEnd)
            {
                if (array[leftIndex] <= array[rightIndex])
                {
                    tempArray[index] = array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    tempArray[index] = array[rightIndex];
                    rightIndex++;
                }

                index++;
            }

            Array.Copy(array, leftIndex, tempArray, index, leftEnd - leftIndex + 1);
            Array.Copy(array, rightIndex, tempArray, index, rightEnd - rightIndex + 1);

            Array.Copy(tempArray, leftStart, array, leftStart, size);
        }
    }

    public class SelectionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
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

        public static void Swap<T>(T[] array, int first, int second)
        {
            var current = array[first];
            array[first] = array[second];
            array[second] = current;
        }

        public void Display()
        {
            var integerValues = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            SelectionSort.Sort<int>(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            var stringValues = new string[] { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            SelectionSort.Sort<string>(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }
    }
}
