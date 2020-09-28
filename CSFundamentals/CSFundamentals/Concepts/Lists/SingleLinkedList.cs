using System;
namespace CSFundamentals.Concepts.Lists
{
    public class SingleLinkedList<T>
    {
        /*
         * More info: https://www.c-sharpcorner.com/article/linked-list-implementation-in-c-sharp/
         */

        public SingleLinkedListNode<T> Head { get; set; }

        // If we want to know the lenght of the list this will be helpful
        public int Lenght { get; set; } // TODO: Implement


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

        public void InsertAt(T data, int insertIndex)
        {
            if (Head == null)
            {
                Head = new SingleLinkedListNode<T>(data);

                return;
            }

            var current = Head;
            var newHead = new SingleLinkedListNode<T>(Head.Data);
            var newTail = newHead;

            current = current.NextNode;

            var index = 1;

            while (current != null)
            {
                if(index == insertIndex)
                {
                    var newNode = new SingleLinkedListNode<T>(data);

                    newNode.NextNode = current;

                    current = newNode;
                }

                var tempNode = new SingleLinkedListNode<T>(current.Data);
                newTail.NextNode = tempNode; // This will append to the next node of the tail
                newTail = tempNode; // Now that the old tail's next node has been assigned, we move the reference of the tail to the new node
                current = current.NextNode;

                index++;
            }
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

        // TODO: There is also a recursive approach to reverse
        public void Reverse()
        {
            var current = Head;
            SingleLinkedListNode<T> next = null;
            SingleLinkedListNode<T> prev = null;

            while(current != null)
            {
                next = current.NextNode;
                current.NextNode = prev;
                prev = current;
                current = next;
            }
        }

        public void Copy()
        {
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
