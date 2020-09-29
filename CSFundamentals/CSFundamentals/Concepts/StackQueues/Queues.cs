using System;
namespace CSFundamentals.Concepts.StackQueues
{
    public class Queues
    {
        // FIFO -> First In First Out

        public Node Head { get; set; } // Remove from the begining

        public Node Tail { get; set; } // Add things to the end


        public bool IsEmpty()
        {
            return Head == null;
        }

        public int? Peek()
        {
            return Head?.Data; // You can default to a number that can cause problems, it can invalidate valid data if it is passed
        }

        public void Add(int data)
        {
            var newNode = new Node(data);

            if(Tail != null)
            {
                Tail.Next = newNode;
            }

            Tail = newNode;

            if(Head == null)
            {
                Head = newNode;
            }
        }

        public int Remove()
        {
            // TODO: Needs validation

            var data = Head.Data;

            Head = Head.Next;

            if(Head == null)
            {
                Tail = null;
            }

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
