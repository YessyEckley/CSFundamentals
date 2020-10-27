using System;
using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem13RomanInt
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/roman-to-integer/
         * For more solutions: https://leetcode.com/problems/roman-to-integer/solution/
         */


        /* Approach #1
         * This is my original approache to this problem
         * It had a linear time complexity but it still manage to perform over 70% faster than other solutions
         */
        public static int RomanToInt(string s)
        {
            var romanInteger = 0;

            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'I':
                        if (i + 1 < s.Length && (s[i + 1] == 'V' || s[i + 1] == 'X'))
                        {
                            romanInteger += -1;
                        }
                        else
                        {
                            romanInteger += 1;
                        }
                        break;
                    case 'V':
                        romanInteger += 5;
                        break;
                    case 'X':
                        if (i + 1 < s.Length && (s[i + 1] == 'L' || s[i + 1] == 'C'))
                        {
                            romanInteger += -10;
                        }
                        else
                        {
                            romanInteger += 10;
                        }
                        break;
                    case 'L':
                        romanInteger += 50;
                        break;
                    case 'C':
                        if (i + 1 < s.Length && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                        {
                            romanInteger += -100;
                        }
                        else
                        {
                            romanInteger += 100;
                        }
                        break;
                    case 'D':
                        romanInteger += 500;
                        break;
                    case 'M':
                        romanInteger += 1000;
                        break;
                    default:
                        break;
                }
            }

            return romanInteger;
        }

        /* Approach #2
         * This approach uses a dictionary to do the search
         */
        public static Dictionary<string, int> RomanValues2 => new Dictionary<string, int>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 },
        };

        public static int RomanToInt2(string s)
        {
            var romanInteger = 0;
            var indexCounter = 0;

            while (indexCounter < s.Length)
            {
                if (indexCounter < s.Length - 1)
                {
                    var doubleSymbol = s.Substring(indexCounter, indexCounter + 2);

                    // Check if this is the length-2 symbol
                    if (RomanValues2.ContainsKey(doubleSymbol))
                    {
                        romanInteger += RomanValues2[doubleSymbol];
                        indexCounter += 2;
                        continue;
                    }
                }

                //Otherwise, it must be the lenght-1 sybol case
                var singleSymbol = s.Substring(indexCounter, indexCounter + 1);
                romanInteger += RomanValues2[singleSymbol];
                indexCounter += 1;
            }

            return romanInteger;
        }

        /* Approach #3
         * This approach uses a dictionary to do the search
         * This is yet another approach
         */
        public static Dictionary<string, int> RomanValues3 => new Dictionary<string, int>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
        };

        public static int RomanToInt3(string s)
        {
            var romanInteger = 0;
            var indexCounter = 0;

            while (indexCounter < s.Length)
            {
                var currentSymbol = s.Substring(indexCounter, indexCounter + 1);
                var currentValue = RomanValues3[currentSymbol];
                var nextValue = 0;

                if (indexCounter + 1 < s.Length)
                {
                    var nextSymbol = s.Substring(indexCounter + 1,  indexCounter + 2);
                    nextValue = RomanValues3[nextSymbol];
                }

                if (currentValue < nextValue)
                {
                    romanInteger += (nextValue - currentValue);
                    indexCounter += 2;
                }
                else
                {
                    romanInteger += currentValue;
                    indexCounter += 1;
                }
            }

            return romanInteger;
        }
    }
}
