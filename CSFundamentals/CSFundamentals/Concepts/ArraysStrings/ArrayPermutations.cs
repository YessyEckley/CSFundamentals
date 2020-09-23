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
         * In this case the reference location will update after the Swap function is returned
         * 
         * https://www.w3resource.com/csharp-exercises/recursion/csharp-recursion-exercise-11.php
         * https://www.chadgolden.com/blog/finding-all-the-permutations-of-an-array-in-c-sharp
         * https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
         * 
         * Permutations are a topic that I've heard about that gets asked, so it is good to study them.
         * 
         * Here are simple example on how recursion work
         * 
         * Sample #1 -> ["a"]
         * Pseudo-Code
         * Permutation(a: ["a"], startIndex: 0, endIndex: 0, List);
         *  if(0 == 0) -> true
         *      List.Add(new copy of ["a"]);
         *  return List;
         *  
         * 
         * Sample #2 -> ["a", "b"] -> ["a", "b"], ["b", "a"]
         * Pseudo-Code
         * Permutation(a: ["a", "b"], startIndex: 0, endIndex: 1, List);
         *  if(0 == 1) -> false
         *  else
         *      for(var i = 0; i <= 1; i++)
         *          -> i = 0
         *          Swap(ref "a", ref "a"); -> we are trying to swap the same element
         *          Permutation(["a", "b"], 1, 1, List);
         *              if(1 == 1) -> true
         *                  List.Add(new copy of ["a", "b"]);
         *              return List;
         *          Swap(ref "a", ref "a"); -> we are trying to swap the same element
         *          -> i = 1
         *          Swap(ref "a", ref "b");
         *          Permutation(["b", "a"], 1, 1, List);
         *              if(1 == 1) -> true
         *                  List.Add(new copy of ["b", "a"]);
         *              return List;
         *          Swap(ref "b", ref "a");
         *  return List;
         * 
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
