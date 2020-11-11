using System.Collections.Generic;
using System.Text;

namespace CSFundamentals.Leetcode
{
    public class Problem1249MinRemove
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
         * For more solutions: 
         */

        public string MinRemoveToMakeValid(string s)
        {
            var parenthesisIndexStack = new Stack<int>();
            var sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ')')
                {
                    if (s[i] == '(')
                    {
                        parenthesisIndexStack.Push(i);
                    }

                    sb.Append(s[i]);
                }
                else if (s[i] == ')' && parenthesisIndexStack.Count > 0)
                {
                    parenthesisIndexStack.Pop();

                    sb.Append(s[i]);
                }
                else
                {
                    sb.Append(' ');
                }
            }

            if (parenthesisIndexStack.Count > 0)
            {
                foreach (var index in parenthesisIndexStack)
                {
                    sb[index] = ' ';
                }
            }

            return sb.ToString().Replace(" ", "");
        }
    }
}
