using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.HashTables
{
    public class ColorfulNumbers
    {
        /*
         * Link to the problem: https://algorithms.tutorialhorizon.com/colorful-numbers/
         *                      https://www.careercup.com/question?id=4863869499473920 -> I actually prefer this explanation becuase it is simple and to the point
         * 
         * Objective: Given a number, find out whether its colorful or not.
         * Colorful Number: When in a given number, product of every digit of a sub-sequence are different. That number is called Colorful Number.
         * 
         * Example:
         * Given Number : 3245
         * Output : Colorful
         * Number 3245 can be broken into parts like 3 2 4 5 32 24 45 324 245.
         * this number is a colorful number, since product of every digit of a sub-sequence are different.
         * That is, 3 2 4 5 (3*2)=6 (2*4)=8 (4*5)=20, (3*2*4)= 24 (2*4*5)= 40
         * 
         * Given Number : 326
         * Output : Not Colorful.
         * 326 is not a colorful number as it generates 3 2 6 (3*2)=6 (2*6)=12.
         * 3
         * 3*2
         * 3*2*6
         * 2
         * 2*6
         * 6
         * 
         * Strategy:
         *  -> We are given a number
         *  -> This number can is a positive number
         *  -> If it's single digit, then it is a Colorful Number
         *  -> We need to return 'Colorful' or 'Not Coloful' as outputs
         */

        // Approach #1 -> Conver unsing Linq
        public string IsColorfulNumbers(int number)
        {
            var colorfulNumberDictionary = new Dictionary<int, string>();
            var numberString = number.ToString();
            var intArray = numberString.Select(s => int.Parse(s.ToString())).ToArray();

            // A loop to iterate through all of the options
            for (int i = 0; i < intArray.Length; i++)
            {
                var movableIndex = i;
                var stringValue = string.Empty;
                var intKey = 0;

                while(movableIndex < intArray.Length)
                {
                    if(i == movableIndex)
                    {
                        stringValue = intArray[i].ToString();
                        intKey = intArray[i];
                    }
                    else
                    {
                        intKey *= intArray[movableIndex];
                        stringValue += $"*{intArray[movableIndex]}";
                    }

                    Console.WriteLine($"{stringValue} = {intKey}");

                    if (!colorfulNumberDictionary.ContainsKey(intKey))
                    {
                        colorfulNumberDictionary.Add(intKey, stringValue);
                    }
                    else
                    {
                        return "Not Colorful";
                    }

                    movableIndex++;
                }
            }
            
            return "Colorful";
        }

        // Approach #2
        // Another option is to calculate each number using modulus
        public string IsColorfulNumbers2(int number)
        {
            if(number < 10)
            {
                return "Colorful";
            }

            var colorfulNumberDictionary = new Dictionary<int, string>();
            var numberString = number.ToString();
            var intArray = new int[numberString.Length];
            var upperIndex = numberString.Length - 1;

            while (number > 0)
            {
                var modNumber = number % 10;
                intArray[upperIndex] = modNumber;
                number = number / 10;
                upperIndex--;
            }

            // A loop to iterate through all of the options
            for (int i = 0; i < intArray.Length; i++)
            {
                var movableIndex = i;
                var stringValue = string.Empty;
                var intKey = 0;

                while (movableIndex < intArray.Length)
                {
                    if (i == movableIndex)
                    {
                        stringValue = intArray[i].ToString();
                        intKey = intArray[i];
                    }
                    else
                    {
                        intKey *= intArray[movableIndex];
                        stringValue += $"*{intArray[movableIndex]}";
                    }

                    Console.WriteLine($"{stringValue} = {intKey}");

                    if (!colorfulNumberDictionary.ContainsKey(intKey))
                    {
                        colorfulNumberDictionary.Add(intKey, stringValue);
                    }
                    else
                    {
                        return "Not Colorful";
                    }

                    movableIndex++;
                }
            }

            return "Colorful";
        }

        public void ColorfulNumbersWorker()
        {
            // This is for quick testing
            Console.WriteLine($"Result: {(new ColorfulNumbers()).IsColorfulNumbers(0)}");
            Console.WriteLine();
            Console.WriteLine($"Result: {(new ColorfulNumbers()).IsColorfulNumbers(3245)}");
            Console.WriteLine();
            Console.WriteLine($"Result: {(new ColorfulNumbers()).IsColorfulNumbers(326)}");
        }
    }
}
