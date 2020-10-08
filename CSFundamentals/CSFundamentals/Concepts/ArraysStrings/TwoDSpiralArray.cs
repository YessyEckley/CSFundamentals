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
         *    TopLeft      TopRight
         *       ____ ____ ____
         *      | >> | >> | >> |
         *      |____|____|____|
         *      |  ^ |  > |  V |
         *      |____|____|____|
         *      | << | << |  V |
         *      |____|____|____|
         *      
         *   BottomLeft    BottomRight
         * 
         * Strategy
         *  -> View this exercise as traversing the outer part of the box and then reducing, or bringing in, the walls of the box
         *  -> Determine the size to the map, in this case it is quadratic n^2, but in in other cases you can get 2 numbers for the size then it will be n * m
         *  -> In the case of coming up with a simple array 
         *   
         */

        // TODO: COMPLETE EXERCISE
        public static int[][] MatrixSpiral(int n)
        {
            var matrixSize = n * n; // Or var matrixSize = Math.Pow(n, 2);
            var counter = 0; // we will need a counter to compare against the matrix size
            var returnMatrix = new int[n][];
            var topLeft = 0;

            while (counter < matrixSize)
            {
                // we will insert the numbers in order on the first array
            }

            return returnMatrix;
        }

        public static int[] SpiralArray(int[][] matrix)

        {
            return null;
        }

        public void TwoDSpiralArrayWorker()
        {
        }
    }
}
