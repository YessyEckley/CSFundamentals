using System;
namespace CSFundamentals.Concepts.Sorts
{
    // MergeSort and QuickSort look very similar
    // See page 138 of the Book Problem Solving in Data Structure & Algorithms Using C#

    public class MergeSort
    {
        public MergeSort()
        {
        }

        public void Sort(int[] array)
        {
            var tempArray = new int[array.Length];

            Sort(array, tempArray, 0, array.Length - 1);
        }

        public void Sort(int[] array, int[] tempArray, int leftStart, int rightEnd)
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

        public void MergeHalves(int[] array, int[] tempArray, int leftStart, int rightEnd)
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

        public void Display()
        {
            var integerValues = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            (new MergeSort()).Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            //var stringValues = new string[] { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            //(new MergeSort()).Sort<string>(stringValues);
            //Console.WriteLine(string.Join(" | ", stringValues));

            //(new MergeSort()).Sort2<int>(integerValues);
            //Console.WriteLine(string.Join(" | ", integerValues));

            //(new MergeSort()).Sort2<string>(stringValues);
            //Console.WriteLine(string.Join(" | ", stringValues));
        }
    }
}
