using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public partial class Problem1428LeftmostWithAtleastOne
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/leftmost-column-with-at-least-a-one/
         * For more solutions: https://leetcode.com/problems/leftmost-column-with-at-least-a-one/solution/
         * 
         * -> when we encounter 1 -> move left (previous column)
         * -> when we encounter 0 -> move down (next row)
         */

        public class BinaryMatrix
        {
            // In Leetcode this is already implemented  but we are bring it as a dummy just to be able to use the object and it's functions
            // This is from Leetcode's comments
            // This is BinaryMatrix's API interface.
            // You should not implement it, or speculate about its implementation
            public int Get(int row, int col) { return 0; }
            public IList<int> Dimensions() { return new List<int>(); }
        }

        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            var dimentions = binaryMatrix.Dimensions();
            var rowIndex = 0;
            var colIndex = dimentions[1] - 1;

            while (colIndex >= 0 && rowIndex < dimentions[0])
            {
                var matrixValue = binaryMatrix.Get(rowIndex, colIndex);

                if (matrixValue == 1)
                {
                    colIndex--;
                }
                else
                {
                    rowIndex++;
                }
            }

            return colIndex == dimentions[1] - 1 ? -1 : colIndex + 1;
        }
    }
}
