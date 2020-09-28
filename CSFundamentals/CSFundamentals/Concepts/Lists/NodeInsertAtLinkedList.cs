﻿using System;
namespace CSFundamentals.Concepts.Lists
{
    public class NodeInsertAtLinkedList
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list/problem
         */

        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        public class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        public static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }

        public static SinglyLinkedListNode InsertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            if (head == null)
            {
                return new SinglyLinkedListNode(data); ;
            }

            var current = head;
            var newHead = new SinglyLinkedListNode(head.data);
            var newTail = newHead;
            var index = 1;

            current = current.next;

            while (current != null)
            {
                if (index == position)
                {
                    var newInsertNode = new SinglyLinkedListNode(data);

                    newInsertNode.next = current;

                    current = newInsertNode;
                }

                var tempNode = new SinglyLinkedListNode(current.data);
                newTail.next = tempNode;
                newTail = tempNode;
                current = current.next;

                index++;
            }

            return newHead;
        }

        public static void NodeInsertAtLinkedListWorker()
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            int data = Convert.ToInt32(Console.ReadLine());

            int position = Convert.ToInt32(Console.ReadLine());

            SinglyLinkedListNode llist_head = InsertNodeAtPosition(llist.head, data, position);

            PrintSinglyLinkedList(llist_head, " ");
            Console.WriteLine();
        }
    }
}
