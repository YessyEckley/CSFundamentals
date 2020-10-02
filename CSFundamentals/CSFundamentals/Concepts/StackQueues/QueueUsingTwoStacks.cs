using System;
using System.Linq;

namespace CSFundamentals.Concepts.StackQueues
{
    public class QueueUsingTwoStacks
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/queue-using-two-stacks/problem
         * 
         * In C# there is a Stack class but the point to to practice and get used to data structures and how they work.
         * This means I need to build them to get familiar.
         * 
         * Explanation in trying to find a solution
         * 
         * Sample Input
         *      10
         *      1 42
         *      2
         *      1 14
         *      3
         *      1 28
         *      3
         *      1 60
         *      1 78
         *      2
         *      2
         * Sample Output
         *      14
         *      14
         * 
         * We read the line and immediatly process the task
         * 
         * We need to build a queue using two stacks
         *      -> How are we going to use the stacks?
         *      -> Here are some params
         *          -> First input is a number that will determine the numbers of query requests
         *          -> Then the following entries are tasks to be performed on the queue logic
         *              -> This sounds like a switch logic where we compare the first character
         *              -> Here are some concepts
         *                  -> Enqueue (Push): add a new element to the end of the queue -> add to the tail
         *                  -> Dequeue (Pop): remove the element from the front of the queue and return it 
         *                      -> get the value of the top that will be removed and then returned 
         *                      -> reassign the top to the next node
         *              -> Here is what to expect
         *                  -> If the query input for the task is 1 with an int (space delimited) -> enqueue the data
         *                      -> then Push() the int value to the stack enqueueu stack
         *                  -> If the query input for the task is 2 -> dequeue the data
         *                      -> then Pop() the Top element of the enqueueu stack
         *                      -> then Push() the elements to the Dequeue stack
         *                      -> and then Pop() the Top of Dequeue stack
         *                      -> move back to the enqueue stack by Pop() and Push()
         *                  -> If the query input for the task is 3 -> print the data
         *                      -> then Print the Top of the Dequeue stack following the same logic of case 2
         *              -> We want to have 2 stacks to simulate a queue
         *                  -> Stack #1
         *                  -> Stack #2
         *              -> we will insert into one stack in desc insert order -> this is an enqueue
         *              -> when we want to dequeue the first inserted value we will pop from the enqueue stack and into the dequeue stack
         *                  -> This will put at the Top the first inserted int data
         *                  -> The we will eliminate the Top from the Dequeue stack
         *                  
         *                  Stack: Enqueue  ->  Stack: Dequeue (This is just a visualization)
         *                      78      pop     push    42 -> Then we can really dequeue from here
         *                      60      pop     push    14
         *                      28      pop     push    28
         *                      14      pop     push    60
         *                      42      pop     push    78
         *                  This is a two step process where we will insert into one stack
         *                      -> when we want to dequeu then we need to have the data jump over to the other stack to be popped as a FIFO
         */

        public class QueueingStack
        {
            public Node Top { get; set; }


            public bool IsEmpty()
            {
                return Top == null;
            }

            public void EmptyStack()
            {
                Top = null;
            }

            public int Pop()
            {
                var dataValue = Top.Data;

                Top = Top.Next;

                return dataValue;
            }
            public void Push(int data)
            {
                var newTop = new Node(data);

                newTop.Next = Top;

                Top = newTop;
            }

            public int? Peek()
            {
                return Top?.Data;
            }

            public void Print()
            {
                Console.WriteLine(Top.Data);
            }
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

        public void QueueUsingTwoStacksBruteForceSolution()
        {
            // With this approach I was going with always keeping the dequeueStack empty and always re inserting the data back and forth between the stacks
            // This approach works but it is very slow, as it goes linearly along the enqueueStack stack to populate the dequeueStack stack.
            // after doing the Pop(), it will traverse back to re populate the enqueueStack back from the dequeueStack.

            var t = Convert.ToInt32(Console.ReadLine());
            var enqueueStack = new QueueingStack();
            var dequeueStack = new QueueingStack();
            int intData;
            int poppedInt;

            for (int tItr = 0; tItr < t; tItr++)
            {
                var s = Console.ReadLine();

                switch(s[0])
                {
                    case '1':
                        intData = int.Parse(s.Split(' ').Last());
                        enqueueStack.Push(intData);
                        break;
                    case '2':
                        while(!enqueueStack.IsEmpty())
                        {
                            poppedInt = enqueueStack.Pop();
                            dequeueStack.Push(poppedInt);
                        }
                        dequeueStack.Pop();
                        while (!dequeueStack.IsEmpty())
                        {
                            poppedInt = dequeueStack.Pop();
                            enqueueStack.Push(poppedInt);
                        }
                        break;
                    case '3':
                        while (!enqueueStack.IsEmpty())
                        {
                            poppedInt = enqueueStack.Pop();
                            dequeueStack.Push(poppedInt);
                        }
                        dequeueStack.Print();
                        while (!dequeueStack.IsEmpty())
                        {
                            poppedInt = dequeueStack.Pop();
                            enqueueStack.Push(poppedInt);
                        }
                        break;
                    default:
                        throw new Exception("Invalid Input!");
                }
            }
        }

        public void QueueUsingTwoStacksInprovedBruteForceSolution()
        {
            // This is a possible improvement to the brute force solution but it's still not optimized
            // Notice that the enqueueStack is repopulated from the dequeueStack
            // Important to notice these approaches are not optimized for performance and will take some time to perform.
            // These approaches were too focused on keeping one of the stacks always empty.
            // This was doing too much extra work.

            var t = Convert.ToInt32(Console.ReadLine());
            var enqueueStack = new QueueingStack();
            var dequeueStack = new QueueingStack();
            int intData;
            int poppedInt;

            for (int tItr = 0; tItr < t; tItr++)
            {
                var s = Console.ReadLine();

                switch (s[0])
                {
                    case '1':
                        intData = int.Parse(s.Split(' ').Last());
                        while (!dequeueStack.IsEmpty())
                        {
                            poppedInt = dequeueStack.Pop();
                            enqueueStack.Push(poppedInt);
                        }
                        enqueueStack.Push(intData);
                        break;
                    case '2':
                        while (!enqueueStack.IsEmpty())
                        {
                            poppedInt = enqueueStack.Pop();
                            dequeueStack.Push(poppedInt);
                        }
                        dequeueStack.Pop();
                        break;
                    case '3':
                        while (!enqueueStack.IsEmpty())
                        {
                            poppedInt = enqueueStack.Pop();
                            dequeueStack.Push(poppedInt);
                        }
                        dequeueStack.Print();
                        break;
                    default:
                        throw new Exception("Invalid Input!");
                }
            }
        }

        public void QueueUsingTwoStacksWorker()
        {
            // This is the optimized version
            // With this approach case 1 we only worry about pushing data to the enqueueStack
            // In case 2, if the dequeueStack is empty then we Pop() the enqueueStack, get the data that was popped, and Push() the data to the dequeueStack.
            // After we made sure the dequeueStack is not empty, then we Pop() the Top value
            // In case 3, if the dequeueStack is empty then we Pop() the enqueueStack, get the data that was popped, and Push() the data to the dequeueStack.
            // After we made sure the dequeueStack is not empty, then we Print() the Top value

            var t = Convert.ToInt32(Console.ReadLine());
            var enqueueStack = new QueueingStack();
            var dequeueStack = new QueueingStack();
            int intData;
            int poppedInt;

            for (int tItr = 0; tItr < t; tItr++)
            {
                var s = Console.ReadLine();

                switch (s[0])
                {
                    case '1':
                        intData = int.Parse(s.Split(' ').Last());

                        enqueueStack.Push(intData);

                        break;
                    case '2':
                        if (dequeueStack.IsEmpty())
                        {
                            while (!enqueueStack.IsEmpty())
                            {
                                poppedInt = enqueueStack.Pop();

                                dequeueStack.Push(poppedInt);
                            }
                        }

                        dequeueStack.Pop();

                        break;
                    case '3':
                        if (dequeueStack.IsEmpty())
                        {
                            while (!enqueueStack.IsEmpty())
                            {
                                poppedInt = enqueueStack.Pop();

                                dequeueStack.Push(poppedInt);
                            }
                        }

                        dequeueStack.Print();

                        break;
                    default:
                        throw new Exception("Invalid Input!");
                }
            }
        }
    }
}