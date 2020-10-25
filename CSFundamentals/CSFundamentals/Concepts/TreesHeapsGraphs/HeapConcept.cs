using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq;

namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class HeapConcept
    {
        /*
         * This is an example from the book Problem SSolving Data Structures & Algriths Using C#
         * 
         * Concept: https://www.geeksforgeeks.org/binary-heap/
         *          https://simpledevcode.wordpress.com/2015/08/05/the-heap-data-structure-c-java-c/
         *          https://blog.bitsrc.io/implementing-heaps-in-javascript-c3fbf1cb2e65 -> This one has a really good explanation
         *          https://www.programiz.com/dsa/heap-data-structure#:~:text=Heap%20data%20structure%20is%20a,called%20as%20a%20binary%20heap.&text=(for%20min%20heap)%20key%20of,smallest%20among%20all%20other%20nodes.
         *          
         */

        private const int CAPACITY = 16;
        private int size;
        private int[] arr;

        public HeapConcept()
        {
            arr = new int[CAPACITY];
            size = 0;
        }

        public HeapConcept(int[] array)
        {
            size = array.Length;
            arr = new int[array.Length + 1];
            Array.Copy(array, 0, arr, 1, array.Length);

            //Build Heap operation over array
            for (int i = (size / 2); i > 0; i--)
            {
                ProclateDown(i);
            }
        }

        private void ProclateDown(int position)
        {
            var leftChild = 2 * position;
            var rightChild = leftChild + 1;
            var small = -1;
            int temp;

            if (leftChild <= size)
            {
                small = leftChild;
            }

            if (rightChild <= size && (arr[rightChild] - arr[leftChild] < 0))
            {
                small = rightChild;
            }

            if (small != -1 && (arr[small] - arr[position]) < 0)
            {
                temp = arr[position];
                arr[position] = arr[small];
                arr[small] = temp;
                ProclateDown(small);
            }
        }

        private void ProclateUp(int position)
        {
            var parent = position / 2;
            int temp;

            if (parent == 0)
            {
                return;
            }

            if ((arr[parent] - arr[position]) > 0)
            {
                temp = arr[position];
                arr[position] = arr[parent];
                arr[parent] = temp;
                ProclateUp(parent);
            }
        }

        public virtual void Print()
        {
            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine($"Value is:: {arr[i]}");
            }
        }

        public virtual bool IsEmpty()
        {
            return (size == 0);
        }

        public virtual int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            return arr[1];
        }

        public virtual void Add(int value)
        {
            if (size == arr.Length - 1)
            {
                DoubleSize();
            }

            arr[++size] = value;
            ProclateUp(size);
        }

        private void DoubleSize()
        {
            var oldArray = arr;
            arr = new int[arr.Length * 2];
            Array.Copy(oldArray, 1, arr, 1, size);
        }

        public virtual int Remove()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            int value = arr[1];
            arr[1] = arr[size];
            size--;
            ProclateDown(1);
            return value;
        }
    }

    public class HeapConceptGfgConcept
    {
        /*
         * This is the example that is used in the Geeks for Geeks site
         * https://www.geeksforgeeks.org/binary-heap/
         */
    }
}
