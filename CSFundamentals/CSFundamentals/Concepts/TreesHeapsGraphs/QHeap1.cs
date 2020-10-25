using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class QHeap1
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/qheap1/problem
         * 
         * Strategy
         *      -> Rules
         *          -> 1 v -> Add v to the heap
         *          -> 2 v -> Delete v from the heap
         *          -> 3 -> Print min of the v elements
         *      -> v can be a positive or negative number
         * 
         * NOTES: -> I used sorted list -> https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist?view=netcore-3.1
         *        -> Another resource: https://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
         *        -> Need to study heaps a little bit more
         * 
         * IMPOTANT: Debug your code by talking out loud
         */

        public static void QHeap1SolutionWorker()
        {
            var queries = int.Parse(Console.ReadLine());
            var sortedList = new SortedList();

            for (var i = 0; i < queries; i++)
            {
                var input = Console.ReadLine();
                var value = 0;

                switch (input[0])
                {
                    case '1': // Case for insert
                        value = int.Parse(input.Split(' ')[1]);
                        sortedList.Add(value, value);
                        break;
                    case '2': // Case for delete
                        value = int.Parse(input.Split(' ')[1]);
                        sortedList.Remove(value);
                        break;
                    case '3': // case for print min
                        Console.WriteLine(sortedList.GetByIndex(0));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
