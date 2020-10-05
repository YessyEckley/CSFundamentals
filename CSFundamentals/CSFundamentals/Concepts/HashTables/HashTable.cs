using System;

namespace CSFundamentals.Concepts.HashTables
{
    public class HashTable
    {
        /*
         * In C# there is a HashTable and Dictionary classes that we can use.
         * We can either use our own implementation or use these clases to implement our logic.
         * 
         * This is from the book 'Problem Solving in Data Structures & Algorithms using C#' by Hemant Jain
         * 
         * The main purpose of this practice is to understand how Hashtables work
         */
        public int TableSize { get; set; }

        public HashTable()
        {
        }

        public int ComputeHash(int key)
        {
            var hashValue = key;

            return hashValue % TableSize; // The modulo is used to create the index of the Hastable
        }

        internal virtual int LinearResolverFunction(int index)
        {
            return index;
        }

        internal virtual int QuadraticResolverFunction(int index)
        {
            return index * index;

            // Here is another solution that uses the Math class, but you will need to cast the result.
            // It will be fine to lose the precision if dealing with integer indexes
            // return (int)Math.Pow(index, 2);
        }
    }
}
