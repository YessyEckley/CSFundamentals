using System;
namespace CSFundamentals.Concepts.Lists
{
    public class DoubleLinkedList
    {
        public DoubleLinkedList()
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
