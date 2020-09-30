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
            // Option #1
            if(Head == null)
            {
                Head = new SingleLinkedListNode<T>(data);

                return;
            }

            var current = Head;
            var index = 1;

            while(current.NextNode != null && index < insertIndex)
            {
                current = current.NextNode;
                index++;
            }

            var newInsertNode = new SingleLinkedListNode<T>(data); // We create the new node with the data that was passed
            newInsertNode.NextNode = current.NextNode; // We assigin the newInsetNode.NextNode to the next node from the previous node

            // Another way
            //var newInsertNode = new SingleLinkedListNode<T>(data) { NextNode = current.NextNode };

            current.NextNode = newInsertNode; // Now the current next node can be assign the new node

            // Option #2
            //if (Head == null)
            //{
            //    Head = new SingleLinkedListNode<T>(data);

            //    return;
            //}

            //var current = Head;
            //var newHead = new SingleLinkedListNode<T>(Head.Data);
            //var newTail = newHead;

            //current = current.NextNode;

            //var index = 1;

            //while (current != null)
            //{
            //    if (index == insertIndex)
            //    {
            //        var newNode = new SingleLinkedListNode<T>(data);

            //        newNode.NextNode = current;

            //        current = newNode;
            //    }

            //    newTail.NextNode = new SingleLinkedListNode<T>(current.Data); // This will append to the next node of the tail
            //    newTail = newTail.NextNode; // Now that the old tail's next node has been assigned, we move the reference of the tail to the new node
            //    current = current.NextNode;

            //    index++;
            //}
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

        public SingleLinkedList<T> Copy() // This will return a new single linked list
        {
            var newSingleLinkList = new SingleLinkedList<T>();

            newSingleLinkList.Head = CreateNewHead();

            return newSingleLinkList;
        }

        // This is a practice on how to solve a problem -> need to look for opportunities to discuss your solutions out loud
        public SingleLinkedListNode<T> CreateNewHead() // This will return a new head
        {
            // Verify if Head is null -> return null if it is -> O(1)
            var current = Head;

            if (current == null)
            {
                return null;
            }

            // Create a new head -> this will take the data from the head
            var newHead = new SingleLinkedListNode<T>(current.Data);
            // Create a pointer to the current node -> Head next node
            current = current.NextNode;
            var newTempNode = newHead; // this is pointing to the same memory reference

            // Loop though the next nodes while it is not null O(n) -> time
            while(current != null)
            {
                // assing the next node to the new head -> we want to new this up
                newTempNode.NextNode = new SingleLinkedListNode<T>(current.Data); // O(n) -> spacial
                // change the current to the next node
                current = current.NextNode;
                // move the temp node to the next node
                newTempNode = newTempNode.NextNode;
            }

            return newHead; // After done, always make sure to ask for feedback and tell that you're don
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
