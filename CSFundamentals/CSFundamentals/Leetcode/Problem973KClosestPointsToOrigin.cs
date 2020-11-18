using System;

namespace CSFundamentals.Leetcode
{
    public class Problem973KClosestPointsToOrigin
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/subarray-sum-equals-k/
         * For more solutions: https://leetcode.com/problems/subarray-sum-equals-k/solution/
         * 
         * Resource: https://en.wikipedia.org/wiki/Euclidean_distance
         *           https://en.wikipedia.org/wiki/Min-max_heap
         *           https://www.geeksforgeeks.org/binary-heap/
         *           
         * K -> is how ever many points we want
         */

        public int[][] KClosest(int[][] points, int K)
        {
            var returnValue = new int[K][];
            var distances = new int[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                distances[i] = FindDistance(points[i]);
            }

            Array.Sort(distances);
            var topDistance = distances[K - 1];
            var returnValueIndex = 0;

            for (int i = 0; i < points.Length; i++)
            {
                if (FindDistance(points[i]) <= topDistance)
                {
                    returnValue[returnValueIndex++] = points[i];
                }
            }

            return returnValue;
        }

        private int FindDistance(int[] point)
        {
            return (point[0] * point[0]) + (point[1] * point[1]);
        }
    }
}
