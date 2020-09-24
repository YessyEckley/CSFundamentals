using System;
namespace CSFundamentals.Concepts.Lists
{
    public class SingleLinkedList<T>
    {
        public SingleLinkedListNode<T> Head { get; set; }

        public void Append(T data)
        {
            if(Head == null)
            {
                Head = new SingleLinkedListNode<T>(data);

                return;
            }

            var currentNode = Head;

            while(currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.NextNode = new SingleLinkedListNode<T>(data);
        }

        public void Prepend(T data)
        {
            var newHead = new SingleLinkedListNode<T>(data);

            newHead.NextNode = Head;

            Head = newHead;
        }

        public void Delete(T data)
        {
            if(Head == null)
            {
                return;
            }

            if(Head.Data.Equals(data))
            {
                Head = Head.NextNode;
            }

            var currentNode = Head;

            while(currentNode.NextNode != null)
            {
                if(currentNode.NextNode.Data.Equals(data))
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;

                    return;
                }

                currentNode = currentNode.NextNode;
            }
        }
    }

    public class SingleLinkedListNode<T>
    {
        public T Data { get; set; }

        public SingleLinkedListNode<T> NextNode { get; set; }

        public SingleLinkedListNode(T data)
        {
            Data = data;
        }
    }
}
