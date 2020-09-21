using System;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class RightRotation
    {
        /*
         * This is sample exercise using LeftRotation.cs as an example but the inverse
         * We are going to rotate the array to the right.
         * Meaning that we are taking the last element and moving it to the begining and then moving to the right the rest of the array.
         * Example d = 4 -> the number of rotations
         * [1 2 3 4 5] -> [5 1 2 3 4] -> [4 5 1 2 3] -> [3 4 5 1 2] -> [2 3 4 5 1]
         */

        public static int[] RotRightLogic(int[] a, int d)
        {
            for(var i = 0; i < d; i++)
            {
                var newArray = new int[a.Count()];

                for(var y = 0; y < a.Count() - 1; y++)
                {
                    newArray[y + 1] = a[y];
                }

                newArray[0] = a[a.Count() - 1];

                a = newArray;
            }

            return a;
        }

        public static int[] RotRightFasterLogic(int[] a, int d)
        {
            var newArray = new int[a.Count()];
            var newStartIndex = a.Count() - d;
            var newArrayIndex = 0;

            for (var i = newStartIndex; i < a.Count(); i++)
            {
                newArray[newArrayIndex] = a[i];
                newArrayIndex++;
            }

            for (var y = 0; y < newStartIndex; y++)
            {
                newArray[newArrayIndex] = a[y];
                newArrayIndex++;
            }

            return newArray;
        }

        public static void LeftRotationWorker()
        {
            Console.WriteLine("RightRotation: Enter two numbers separated by a space. First number -> size of the array. Second number -> number of rotations");
            string[] nd = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);


            Console.WriteLine("RightRotation: Enter the numbers of the array separated by a space.");
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = RotRightLogic(a, d);

            Console.WriteLine($"Result: {string.Join(" ", result)}");
        }
    }
}
