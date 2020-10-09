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
}
