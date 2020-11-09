using System;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class ArrayMutations<T>
    {
        // TODO: create another version without the Array.Copy
        public T[] AddToStart(T[] a, T aValue)
        {
            var result = new T[a.Count() + 1];

            result[0] = aValue;

            //Array.Copy(a, 0, result, 1, a.Count());
            // The other alternative
            for(var i = 1; i <= a.Count(); i++)
            {
                result[i] = a[i - 1];
            }

            return result;
        }

        public T[] AddToEnd(T[] a, T aValue)
        {
            var result = new T[a.Count() + 1];

            result[a.Count()] = aValue;

            //Array.Copy(a, 0, result, 0, a.Count());
            // The other way
            for(var i = 0; i < a.Count(); i++)
            {
                result[i] = a[i];
            }

            return result;
        }

        public T[] InsertAt(T[] a, int index, T aValue)
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
