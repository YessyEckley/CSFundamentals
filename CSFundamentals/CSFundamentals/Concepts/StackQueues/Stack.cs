using System;
namespace CSFundamentals.Concepts.StackQueues
{
    public class Stack
    {
        // LIFO -> Last In First Out

        public Node Top { get; set; } // Remove from the top

        public bool Empty()
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
        { }


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
