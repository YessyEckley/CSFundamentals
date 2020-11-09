using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.StackQueues
{
    public class BalancedBrackets
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/balanced-brackets/problem
         * 
         * In C# there is a Stack class but the point to to practice and get used to data structures and how they work.
         * This means I need to build them to get familiar.
         */

        public class BalancedBracketsStack
        {
            public Node Top { get; set; }


            public void Push(char data) // This doesnt iterrate, it just adds to the top space complexity O(1)
            {
                if (Top == null)
                {
                    Top = new Node(data);
                    return;
                }

                var newTop = new Node(data);
                newTop.Next = Top;
                Top = newTop;
            }

            public char Peek() // space complexity O(1)
            {
                return Top.Data;
            }

            public void Pop() // space complexity O(1)
            {
                Top = Top.Next;
            }

            public bool IsEmpty()
            {
                return Top == null;
            }
        }

        public class Node
        {
            public char Data { get; set; }

            public Node Next { get; set; }

            public Node(char data)
            {
                Data = data;
            }
        }

        public string IsBalanced(string s)
        {
            /*
             * In this example we will use stacks to find our solution
             * Sample Data
             * {(([])[])[]}
             * {(([])[])[]]}
             * {(([])[])[]}[]
             * Sample Output
             * YES
             * NO
             * YES
             * 
             * Explanation:
             * The string that gets passed has the folloing characters -> '{', '}', '(', ')', '[', ']' <-
             *      -> the string can be null
             *          -> "YES" is balanced???
             * ??? Need a flag for the return, but then again we can just return the string and save having to create a flag
             * We need to go through each Char of the string and insert into a stack (LIFO)
             *      -> We are going to need a loop to go through each chracter of the string
             *      -> If the character is an opening bracket, -> '{', '(', '[' <-, push into the stack
             *      -> If the character is a closing bracket, -> '}', ')', ']' <-, then peek into the stack with the matching opening bracket, -> '{', '(', '[' <-
             *         (a match of the closing bracket should immediately correspond to the top of the stack)
             *          -> If the peek matches the opening pair of the closing bracket
             *              -> Pop the value out to give way to the next char in line
             *              -> We keep looping through the characters
             *          -> If the peek doesn't match the pair of the closing bracket
             *             *** Room for improvement: we need to check that the stack is not empty when also evaluating 
             *              -> then return "NO" and exit the function -> the brackets are not balanced
             *      *** Room for improvement: I also forgot toevaluate the end return. We always want to make sure we evaluate that the stack is empty to make sure it is completely balanced.
             *      If there are still nodes left in the stack, then the string of brackets is not balanced
             */

            if (string.IsNullOrWhiteSpace(s))
            {
                return "YES";
            }

            // Another way to not do too much work, because we are working with pairs, we can check that we are dealing with an even numbered string
            // If not then exit early. Chances are pretty high that we are dealing with an unbalanced bracket string, as there will always be one character left in the stack
            if((s.Length % 2) != 0)
            {
                return "NO";
            }

            var stack = new BalancedBracketsStack();

            for (var i = 0; i < s.Length; i++) // O(n) time and O(n) space
            {
                switch (s[i])
                {
                    case '{':
                    case '(':
                    case '[':
                        stack.Push(s[i]);
                        break;
                    case '}':
                        if (stack.IsEmpty() || stack.Peek() != '{')
                        {
                            return "NO";
                        }

                        stack.Pop();
                        break;
                    case ')':
                        if (stack.IsEmpty() || stack.Peek() != '(')
                        {
                            return "NO";
                        }

                        stack.Pop();
                        break;
                    case ']':
                        if (stack.IsEmpty() || stack.Peek() != '[')
                        {
                            return "NO";
                        }

                        stack.Pop();
                        break;
                    default:
                        break;
                }
            }

            return stack.IsEmpty() ? "YES" : "NO";
        }

        public string IsBalancedUsingStack(string s)
        {
            /*
             * In this example we will use stacks to find our solution
             * Sample Data
             * {(([])[])[]}
             * {(([])[])[]]}
             * {(([])[])[]}[]
             * Sample Output
             * YES
             * NO
             * YES
             * 
             * Explanation:
             * The string that gets passed has the folloing characters -> '{', '}', '(', ')', '[', ']' <-
             *      -> the string can be null
             *          -> "YES" is balanced???
             * ??? Need a flag for the return, but then again we can just return the string and save having to create a flag
             * We need to go through each Char of the string and insert into a stack (LIFO)
             *      -> We are going to need a loop to go through each chracter of the string
             *      -> If the character is an opening bracket, -> '{', '(', '[' <-, push into the stack
             *      -> If the character is a closing bracket, -> '}', ')', ']' <-, then peek into the stack with the matching opening bracket, -> '{', '(', '[' <-
             *         (a match of the closing bracket should immediately correspond to the top of the stack)
             *          -> If the peek matches the opening pair of the closing bracket
             *              -> Pop the value out to give way to the next char in line
             *              -> We keep looping through the characters
             *          -> If the peek doesn't match the pair of the closing bracket
             *             *** Room for improvement: we need to check that the stack is not empty when also evaluating 
             *              -> then return "NO" and exit the function -> the brackets are not balanced
             *      *** Room for improvement: I also forgot toevaluate the end return. We always want to make sure we evaluate that the stack is empty to make sure it is completely balanced.
             *      If there are still nodes left in the stack, then the string of brackets is not balanced
             */

            if (string.IsNullOrWhiteSpace(s))
            {
                return "YES";
            }

            // Another way to not do too much work, because we are working with pairs, we can check that we are dealing with an even numbered string
            // If not then exit early. Chances are pretty high that we are dealing with an unbalanced bracket string, as there will always be one character left in the stack
            if ((s.Length % 2) != 0)
            {
                return "NO";
            }

            var stack = new Stack<char>();

            for (var i = 0; i < s.Length; i++) // O(n) time and O(n) space
            {
                switch (s[i])
                {
                    case '{':
                    case '(':
                    case '[':
                        stack.Push(s[i]);
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Peek() != '{')
                        {
                            return "NO";
                        }

                        stack.Pop();
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Peek() != '(')
                        {
                            return "NO";
                        }

                        stack.Pop();
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Peek() != '[')
                        {
                            return "NO";
                        }

                        stack.Pop();
                        break;
                    default:
                        break;
                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }

        public string IsBalancedNoneStackSymetrical(string s)
        {
            /*
             * Sample Input
             * 3
             * {[()]} -> Are these even numbered???
             * {[(])}
             * {{[[(())]]}}
             * 
             * Sample Output
             * YES
             * NO
             * YES
             * 
             * 
             * Explanation of my logic -> this is not using stacks and it is a brute force approach as I saw a pattern and stuck with it
             * -> this overal works but it assumes that the whole string is one containing unit.
             * -> If it's not a single unit then we have a problem
             * Compare the elements of the string 
             * -> In this case we are trying to compare the opening and closing of the brackets and make sure they match and are the same
             *     -> in light of opening and closing logic, we can deduce that we can take the first element and the last element of the string and compare 
             *     -> we can compare that the ASII character that the opening and closing match '{' is closed by '}'  and '{' is not closed by ']'
             *     Sample of comparison
             *     In a while loop that compares the indexes making sure the lower index is < than the upper index
             *     {_ _ _ _} -> compare elements 0 and string.Lenght -1 (5) to see if they close each other -> create lower bound and upper bound indexes -> change indexes lower + 1, upper - 1
             *     _[_ _]_ -> compare element 1 and 4 to see if they close each other -> change indexes lower + 1, upper - 1
             *     _ _()_ _ -> compare element 2 and 3 to see if they close each other -> change indexes lower + 1, upper - 1
             * 
             *     lower 3 and 2 -> get out of the loop
             * 
             *      with this we will need a string flag -> that will say YES or NO -> we can default to YES and as soon as I get a unmatch, exit the function/method
             */

            var flag = "YES";
            var lowerIndex = 0;
            var upperIndex = s.Length - 1;

            while (lowerIndex < upperIndex)
            {
                switch (s[lowerIndex])
                {
                    case '{':
                        if ('}' != s[upperIndex])
                        {
                            flag = "NO";
                        }
                        break;
                    case '[':
                        if (']' != s[upperIndex])
                        {
                            flag = "NO";
                        }
                        break;
                    case '(':
                        if (')' != s[upperIndex])
                        {
                            flag = "NO";
                        }
                        break;
                    default:
                        flag = "NO";
                        break;

                }

                lowerIndex++;
                upperIndex--;
            }

            return flag;
        }
    }
}
