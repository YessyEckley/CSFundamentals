using System;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class LeftRotation
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem
         * 
         * Important to study Array rotations and manipulation.
         * Practice more rotations and insertion and deletion of arrays.
         * Come up with your own exercises or look online for more Array exercises.
         * This is a good practive for more complex data structures.
         * 
         */

        public int[] RotLeftLogic(int[] a, int d)
        {
            for (int i = 0; i < d; i++)
            {
                // Rule of thumb: Always create a new variable to arrange data.
                // This guarantees that we are inserting into a clean variable.
                // Eventhough, this works, it didn't passed performance test with larger arrays.
                // Find a way to make it efficient as this is a brute force option.
                var newArray = new int[a.Count()];

                for (int y = 1; y <= a.Count(); y++)
                {
                    if (y != a.Count())
                    {
                        newArray[y - 1] = a[y];
                    }
                    else
                    {
                        newArray[y - 1] = a[0];
                    }
                }

                // Just and idea: gather all of the elements, index 1 and so on, and then add the first to the end, instead of doing the for loop.

                //Do not forget to change the original array
                a = newArray;
            }

            return a;
        }

        public int[] RotLeftFasterLogic(int[] a, int d)
        {
            // Rule of thumb: Always create a new variable to arrange data as it guarantees that we are inserting into a clean variable.
            // This is a faster way to the result as we are spliting the array right on the new starting point and making insertions from that point on.
            // It prevents nested for loops.

            var index = 0;
            var newArray = new int[a.Count()];

            for (int i = d; i < a.Count(); i++)
            {
                newArray[index] = a[i];
                index++;
            }

            for (int y = 0; y < d; y++)
            {
                newArray[index] = a[y];
                index++;
            }

            return newArray;
        }

        public int[] RotLeftAnotherForLogic(int[] a, int d)
        {
            for (int i = 0; i < d; i++)
            {
                // Rule of thumb: Always create a new variable to arrange data.
                // This guarantees that we are inserting into a clean variable.
                // Eventhough, this works, it didn't passed performance test with larger arrays.
                // Find a way to make it efficient as this is a brute force option.

                var newArray = new int[a.Count()];

                for (int y = 0; y < a.Count() - 1; y++)
                {
                    newArray[y] = a[y + 1];
                }

                newArray[a.Count() - 1] = a[0];

                a = newArray;
            }

            return a;
        }

        public int[] RotLeftCopyLogic(int[] a, int d)
        {
            for (int i = 0; i < d; i++)
            {
                // Rule of thumb: Always create a new variable to arrange data.
                // This guarantees that we are inserting into a clean variable.
                // Eventhough, this works, it didn't passed performance test with larger arrays.
                // Find a way to make it efficient as this is a brute force option.

                var newArray = new int[a.Count()];

                Array.Copy(a, 1, newArray, 0, a.Count() - 1);
                newArray[a.Count() - 1] = a[0];

                a = newArray;
            }

            return a;
        }

        public void LeftRotationWorker()
        {
            Console.WriteLine("LeftRotation: Enter two numbers separated by a space. First number -> size of the array. Second number -> number of rotations");
            string[] nd = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);


            Console.WriteLine("LeftRotation: Enter the numbers of the array separated by a space.");
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = RotLeftLogic(a, d);

            Console.WriteLine($"Result: {string.Join(" ", result)}");
        }
    }
}
