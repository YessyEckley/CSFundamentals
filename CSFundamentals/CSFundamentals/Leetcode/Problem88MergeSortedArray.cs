using System;

namespace CSFundamentals.Leetcode
{
    public class Problem88MergeSortedArray
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/merge-sorted-array/
         * For more solutions: https://leetcode.com/problems/merge-sorted-array/solution/
         * 
         * Input:
         * nums1 = [1,2,3,0,0,0], m = 3
         * nums2 = [2,5,6],       n = 3
         * 
         * Output: [1,2,2,3,5,6]
         * 
         * nums1    
         *              
         *              [1,2,2,3,5,6] -> i + y
         *                      -> need two index pointers to move
         *                      -> what will happen to out of bound and we need to compare -> we can move remaing of other array -> use temp var for insert val
         *                      -> Array.Copy using m as lenght -> a new array of nums1
         *              [1,2,3] 
         *              [2,5,6]
         *              
         * 1. Array.Copy using m as lenght -> of a new array -> of nums1
         * 2. create index i and y -> = 0 
         * 3. loop through the elements -> while (i < m && y < n)
         * 
         * 4. compare elements array1[p1] and nums2[2] -> index of long array is i + y
         * 5. copy the lesser number and move the index to that array
         * 
         * 6. we copy the remaining elements of the longer array to nums1
         */

        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            Array.Copy(nums2, 0, nums1, m, n);
            Array.Sort(nums1);
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            var newNums1 = new int[m];
            var p1 = 0;
            var p2 = 0;
            var p = 0;

            Array.Copy(nums1, newNums1, m);

            while (p1 < m && p2 < n)
            {
                nums1[p++] = newNums1[p1] < nums2[p2] ? newNums1[p1++] : nums2[p2++];
            }

            if (p1 < m)
            {
                Array.Copy(newNums1, p1, nums1, p1 + p2, m + n - p1 - p2);
            }

            if (p2 < n)
            {
                Array.Copy(nums2, p2, nums1, p1 + p2, m + n - p1 - p2);
            }
        }

        public void Merge3(int[] nums1, int m, int[] nums2, int n)
        {
            var newNums1 = new int[m];
            var p1 = 0;
            var p2 = 0;
            var p = 0;

            Array.Copy(nums1, newNums1, m);

            while (p1 < m || p2 < n)
            {
                if (p1 < m && p2 < n)
                {
                    nums1[p++] = newNums1[p1] < nums2[p2] ? newNums1[p1++] : nums2[p2++];
                }
                else
                {
                    if (p1 < m)
                    {
                        nums1[p++] = newNums1[p1++];
                    }

                    if (p2 < n)
                    {
                        nums1[p++] = nums2[p2++];
                    }
                }
            }
        }

        public void Merge4(int[] nums1, int m, int[] nums2, int n)
        {
            var p1 = m - 1;
            var p2 = n - 1;
            var p = nums1.Length - 1;

            while (p1 >= 0 && p2 >= 0)
            {
                nums1[p--] = nums1[p1] > nums2[p2] ? nums1[p1--] : nums2[p2--];
            }

            Array.Copy(nums2, 0, nums1, 0, p2 + 1);
        }
    }
}