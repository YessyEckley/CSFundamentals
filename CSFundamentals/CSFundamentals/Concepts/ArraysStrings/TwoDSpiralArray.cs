using System;
namespace CSFundamentals.Concepts.ArraysStrings
{
    public class TwoDSpiralArray
    {
        /*
         * This is from the page: https://www.facebook.com/careers/life/sample_interview_questions
         * 2D Spiral Array
         * 
         * There are two approaches to this problem
         * #1
         * The first approach if the one that we see on the page:
         * Find the pattern and complete the function:
         *  -> int[][] spiral(int n);
         *  -> where n is the size of the 2D array.
         *  -> This approach it wants you to build the 2D array matrix
         *  input = 3
         *  Output
         *  1 2 3
         *  8 9 4
         *  7 6 5
         *  
         *  input = 4
         *  Output
         *  01 02 03 04
         *  12 13 14 05
         *  11 16 15 06
         *  10 09 08 07
         *  
         *  input = 8
         *  Output
         *  1  2  3  4  5  6  7  8
         *  28 29 30 31 32 33 34 9
         *  27 48 49 50 51 52 35 10
         *  26 47 60 61 62 53 36 11
         *  25 46 59 64 63 54 37 12
         *  24 45 58 57 56 55 38 13
         *  23 44 43 42 41 40 39 14
         *  22 21 20 19 18 17 16 15
         * 
         * #2
         * The second approach, it is dicussed in this video: https://www.youtube.com/watch?v=BdQ2AkaTgOA
         * Given a matrix m * n (m = rows, n = columns), return all the elements of the matrix in spiral order
         * Example #1
         * Input:
         * [1, 2, 3]
         * [4, 5, 6]
         * [7, 8, 9]
         * Output:
         * [1, 2, 3, 6, 9, 8, 7, 4, 5]
         * Example #2
         * Input:
         * [1, 2,  3,  4]
         * [5, 6,  7,  8]
         * [9, 10, 11, 12]
         * Output:
         * [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7]
         * 
         * 
         * Vizualization
         *    Top             Right
         *       ____ ____ ____
         *      | >> | >> | >> |
         *      |____|____|____|
         *      |  ^ |  > |  V |
         *      |____|____|____|
         *      | << | << |  V |
         *      |____|____|____|
         *      
         *   Left            Bottom
         * 
         * Strategy
         *  -> View this exercise as traversing the outer part of the box and then reducing, or bringing in, the walls of the box
         *  -> Determine the size to the map, in this case it is quadratic n^2, but in in other cases you can get 2 numbers for the size then it will be n * m
         *  -> In the case of coming up with a simple array 
         *   
         */

        public static int[][] MatrixSpiral(int n)
        {
            if (n <= 0) // If we don't have a valid number lets exit
            {
                return null;
            }

            // In C# if we have a jagged array we need to instantiate each row
            var returnMatrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                returnMatrix[i] = new int[n];
            }

            var matrixSize = n * n; // Or var matrixSize = Math.Pow(n, 2);
            var counter = 0; // we will need a counter to compare against the matrix size
            var top = 0;
            var left = 0;
            var bottom= n - 1;
            var right = n - 1;

            while (counter < matrixSize)
            {
                // insert the numbers in order while bring in the box
                //  -> insert the first row
                for (int i = left; i <= right && counter < matrixSize; i++) // Think of these values as to the direction you need to traverse
                {
                    returnMatrix[top][i] = counter + 1;
                    counter++;
                }
                top++;
                //  -> insert values on the last column
                for (int i = top; i <= bottom && counter < matrixSize; i++)
                {
                    returnMatrix[i][right] = counter + 1;
                    counter++;
                }
                right--;
                //  -> insert on last row
                for (int i = right; i >= left && counter < matrixSize; i--)
                {
                    returnMatrix[bottom][i] = counter + 1;
                    counter++;
                }
                bottom--;
                //  -> insert on first column
                for (int i = bottom; i >= top && counter < matrixSize; i--)
                {
                    returnMatrix[i][left] = counter + 1;
                    counter++;
                }
                left++; 
            }

            return returnMatrix;
        }

        public static int[] SpiralArray(int[][] matrix)
        {
            // This is assuming that we have the same amount of columns for each row
            var size = matrix.Length * matrix[0].Length;
            var returnIntArray = new int[size];

            if (matrix == null || matrix.Length <= 0)
            {
                return returnIntArray;
            }

            var top = 0;
            var bottom = matrix.Length - 1;
            var left = 0;
            var right = matrix[0].Length - 1;
            var counter = 0;

            while (counter < size)
            {
                for (int i = left; i <= right; i++) // Once again, we can view this as the direction we are going to be filling up
                {
                    returnIntArray[counter] = matrix[top][i]; // This is our mapping, we are looking at the top row
                    counter++;
                }
                top++;
                for (int i = top; i <= bottom; i++)
                {
                    returnIntArray[counter] = matrix[i][right]; // This is our mapping, we are looking at the right column
                    counter++;
                }
                right--;
                for (int i = right; i >= left; i--)
                {
                    returnIntArray[counter] = matrix[bottom][i]; // This is our mapping, we are looking at the bottom row
                    counter++;
                }
                bottom--;
                for (int i = bottom; i >= top; i++)
                {
                    returnIntArray[counter] = matrix[i][left]; // This is our mapping, we are looking at the left column
                    counter++;
                }
                left++;
            }

            return returnIntArray;
        }

        public static void TwoDSpiralArrayWorker()
        {
            var resultMatrix = MatrixSpiral(3);
            Console.WriteLine("Input: 3");
            Console.WriteLine("Output:");
            foreach (var array in resultMatrix)
            {
                Console.WriteLine($"[ {string.Join(", ", array)} ]");
            }
            resultMatrix = MatrixSpiral(4);
            Console.WriteLine("Input: 4");
            Console.WriteLine("Output:");
            foreach (var array in resultMatrix)
            {
                Console.WriteLine($"[ {string.Join(", ", array)} ]");
            }
            resultMatrix = MatrixSpiral(8);
            Console.WriteLine("Input: 8");
            Console.WriteLine("Output:");
            foreach (var array in resultMatrix)
            {
                Console.WriteLine($"[ {string.Join(", ", array)} ]");
            }
        }
    }
}
