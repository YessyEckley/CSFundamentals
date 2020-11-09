using System;
namespace CSFundamentals.Concepts.ArraysStrings
{
    public class MoveZerosInOnePass
    {
        public MoveZerosInOnePass()
        {
        }

        public int[] MoveAllZerosToEnd(int[] a)
        {
            var backMovingIndex = a.Length - 1;
            var forwardMovingIndex = 0;
            var returnArray = new int[a.Length];

            for(var i = 0; i < a.Length; i++)
            {
                if(a[i] == 0)
                {
                    returnArray[backMovingIndex] = a[i];

                    backMovingIndex--;
                }
                else
                {
                    returnArray[forwardMovingIndex] = a[i];

                    forwardMovingIndex++;
                }
            }

            return returnArray;
        }

        public int[] MoveAllZerosToBegining(int[] a)
        {
            var backmovingIndex = a.Length - 1;
            var forwardMovingIndex = 0;
            var returnArray = new int[a.Length];

            for(var i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] == 0)
                {
                    returnArray[forwardMovingIndex] = a[i];

                    forwardMovingIndex++;
                }
                else
                {
                    returnArray[backmovingIndex] = a[i];

                    backmovingIndex--;
                }
            }

            return returnArray;
        }
    }
}
