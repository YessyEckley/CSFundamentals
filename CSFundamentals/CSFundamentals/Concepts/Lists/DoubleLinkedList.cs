using System;
namespace CSFundamentals.Concepts.Lists
{
    public class DoubleLinkedList<T>
    {
        /*
         * More info: https://www.c-sharpcorner.com/article/linked-list-implementation-in-c-sharp/
         *            https://www.c-sharpcorner.com/article/doubly-linked-list-and-circular-linked-list-in-c-sharp/
         */

        public DoubleLinkedListNode<T> Head { get; set; }

        public DoubleLinkedListNode<T> Tail { get; set; }

        // If we want to know the lenght of the list this will be helpful
        public int Lenght { get; set; } // TODO: Implement

        public DoubleLinkedList(DoubleLinkedListNode<T> head, DoubleLinkedListNode<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        public void Append(T data)
        {
            // TODO: not done

            var newTailNode = new DoubleLinkedListNode<T>(data, null, null);

            if(Head == null)
            {
                Head = newTailNode;

                return;
            }

            var current = Head;

            while(current.NextNode != null)
            {
                current = current.NextNode;
            }

            current.NextNode = newTailNode;
            newTailNode.PreviousNode = current;
            Tail = newTailNode;
        }

        public void Prepend(T data)
        {
            var newHeadNode = new DoubleLinkedListNode<T>(data, Head, null);

            if(Head != null)
            {
                Head.PreviousNode = newHeadNode;
            }

            Head = newHeadNode;
        }

        public void Insert(T data, int location)
        {
        }

        public void Delete(T data)
        {
        }
    }

    public class DoubleLinkedListNode<T>
    {
        public T Data { get; set; }

        public DoubleLinkedListNode<T> NextNode { get; set; }

        public DoubleLinkedListNode<T> PreviousNode { get; set; }

        public DoubleLinkedListNode(T data, DoubleLinkedListNode<T> nextNode, DoubleLinkedListNode<T> previousNode)
        {
            Data = data;
            NextNode = nextNode;
            PreviousNode = previousNode;
        }
    }
}
