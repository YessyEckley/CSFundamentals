using System;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class ArrayPermutations<T>
    {
        /*
         * This is an exercise that deals both in array and recursions.
         * This is based on some online examples and they are a good practice:
         * 
         * MSDN Documentation on ref keyword
         * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref
         * It is important to note that refering to the new value location doesn't happen until the method is returned
         * 
         * https://www.w3resource.com/csharp-exercises/recursion/csharp-recursion-exercise-11.php
         * https://www.chadgolden.com/blog/finding-all-the-permutations-of-an-array-in-c-sharp
         * https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
         * 
         * Permutations are a topic that I've heard about that gets asked, so it is good to study them.
         */

        public static void Swap(ref T aValue, ref T bValue)
        {
            var temp = aValue;

            aValue = bValue;

            bValue = temp;
        }

        public static List<T[]> Permutation(T[] a, int startIndex, int endIndex, List<T[]> returnList)
        {
            if(startIndex == endIndex)
            {
                var newArray = new T[a.Length];

                Array.Copy(a, newArray, a.Length);

                returnList.Add(newArray);
            }
            else
            {
                for(var i = startIndex; i <= endIndex; i++)
                {
                    Swap(ref a[startIndex], ref a[i]);

                    Permutation(a, startIndex + 1, endIndex, returnList);

                    Swap(ref a[startIndex], ref a[i]);
                }
            }

            return returnList;
        }
    }
}
