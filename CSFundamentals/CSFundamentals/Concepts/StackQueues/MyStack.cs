using System;

namespace CSFundamentals.Concepts.StackQueues
{
    public class MyStack
    {
        /* 
         * LIFO -> Last In First Out
         * C# has a Stack class that we can use
         * This is for practice
         * 
         * C# Stack class: https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=netcore-3.1
         */

        public Node Top { get; set; } // Remove from the top

        public bool IsEmpty()
        {
            return Top == null;
        }

        public int? Peek()
        {
            return Top?.Data;
        }

        public void Push(int data)
        {
            var newNode = new Node(data);

            newNode.Next = Top;

            Top = newNode;
        }

        public int Pop()
        {
            var data = Top.Data;

            Top = Top.Next;

            return data;
        }


        public class Node
        {
            public int Data { get; set; }

            public Node Next { get; set; }

            public Node(int data)
            {
                Data = data;
            }
        }
    }
}
