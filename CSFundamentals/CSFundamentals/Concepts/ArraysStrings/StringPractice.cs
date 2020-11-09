using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class StringPractice
    {
        // TODO: KEEP PRACTICING
        public StringPractice()
        {
            var stringArray = new string[]
            {
                "wrt",
                "wrf",
                "er",
                "ett",
                "rftt"
            };

            // Using Linq -> we can always do logic of our strings, treat them as a collection of arrays and query them
            Console.WriteLine(stringArray.Max(max => max.Length));

            // Using Aggregate
            var maxString = stringArray.Aggregate((maxValue, compareValue) => maxValue.Length > compareValue.Length ? maxValue : compareValue);
            Console.WriteLine(maxString.Length);

            // Traversing the string array and picking characters
            var expected = "wertf";
            var actual = VerticalCharacterMutation(stringArray, maxString);
            Console.WriteLine($"Is {expected} == {actual} -> {expected.Equals(actual)}");
            expected = "";
            string[] vs = new string[] { "z",
                                         "x",
                                         "z" };
            stringArray = vs;
            actual = VerticalCharacterMutation(stringArray, maxString);
            Console.WriteLine($"Is {expected} == {actual} -> {expected.Equals(actual)}");
        }

        // This wil traverse throught the charactes of an array vertically
        private string VerticalCharacterMutation(string[] stringArray, string maxString)
        {
            var newString = string.Empty;
            var nextCharIndex = 0;

            for (int i = 0; i < maxString.Length; i++)
            {
                for (int y = 0; y < stringArray.Length; y++)
                {
                    if (i < stringArray[y].Length)
                    {
                        var evalChar = stringArray[y][i];

                        // We can have a variation where we insert all of the characters
                        if (!newString.Contains(evalChar))
                        {
                            newString += evalChar;
                            nextCharIndex++;
                        }
                    }
                }
            }

            return newString;
        }
    }
}
