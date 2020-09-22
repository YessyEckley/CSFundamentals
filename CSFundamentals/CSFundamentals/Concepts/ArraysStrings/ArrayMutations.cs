using System;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class ArrayMutations<T>
    {
        public static T[] AddToStart(T[] a, T aValue)
        {
            var result = new T[a.Count() + 1];

            Array.Copy(a, 0, result, 1, a.Count());
            result[0] = aValue;

            return result;
        }

        public static T[] AddToEnd(T[] a, T aValue)
        {
            var result = new T[a.Count() + 1];

            Array.Copy(a, 0, result, 0, a.Count());
            result[a.Count()] = aValue;

            return result;
        }

        public static T[] InsertAt(T[] a, int index, T aValue)
        {
            // TODO: Maybe we can simplyfy this

            var result = new T[a.Count() + 1];
            var constIndex = 0;
            
            for(var i = 0; i < a.Count() + 1; i++)
            {
                if(i == index)
                {
                    result[i] = aValue;
                }
                else
                {
                    result[i] = a[constIndex];
                    constIndex++;
                }
            }

            return result;
        }
    }
}
