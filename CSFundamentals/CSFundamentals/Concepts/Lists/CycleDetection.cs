using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace CSFundamentals.Concepts.Lists
{
    public class CycleDetection
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle/problem
         * 
         * Link to some explanation: https://www.geeksforgeeks.org/detect-loop-in-a-linked-list/
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

        public void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
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

        public bool HasCycle(SinglyLinkedListNode head)
        {
            // Maybe another solution? This one worked but the recursion creates so many local variables that it overflows the stack
            //var isClycle = false;
            //var current = head;

            //if (current?.next != null && !isClycle)
            //{
            //    isClycle = (current.Equals(current.next.next))
            //    || HasCycle(current.next); // recursion

            //    return isClycle;
            //}

            //return isClycle;

            // Brute force solution - but it is not fast
            //var isClycle = false;
            //var current = head;

            //while (current?.next != null && !isClycle)
            //{
            //    isClycle = (current.Equals(current.next.next));
            //    current = current.next;
            //}

            //return isClycle;

            // This solution uses Floyd’s Cycle-Finding Algorithm 
            var slowNode = head;
            var fastNode = head;

            while (slowNode != null && fastNode?.next != null)
            {
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;

                if (slowNode.Equals(fastNode))
                {
                    return true;
                }
            }

            return false;


            //Solution that uses HashSet
            //var hashSet = new HashSet<SinglyLinkedListNode>();
            //var current = head;

            //while (current != null)
            //{
            //    if (hashSet.Contains(current))
            //    {
            //        return true;
            //    }

            // In C# we need to be careful about adding elements to any collection
            // It's always best practice that we verify before we insert
            //    hashSet.Add(current); 

            //    current = current.next;
            //}

            //return false;
        }

        public void CycleDetectionWorker()
        {
            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(Console.ReadLine());

                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
                SinglyLinkedListNode temp = llist.head;

                for (int i = 0; i < llistCount; i++)
                {
                    if (i == index)
                    {
                        extra = temp;
                    }

                    if (i != llistCount - 1)
                    {
                        temp = temp.next;
                    }
                }

                temp.next = extra;

                bool result = HasCycle(llist.head);

                Console.WriteLine((result ? 1 : 0));
            }
        }
    }
}
