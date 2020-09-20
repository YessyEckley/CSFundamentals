﻿using System;
using System.IO;
using System.Linq;

namespace CSFundamentals.Concepts.ArraysStrings
{
    public class DesignerPdfViewer
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/designer-pdf-viewer/problem
         */

        // Complete the designerPdfViewer function below.
        public static int DesignerPdfViewerLogic(int[] h, string word)
        {
            if (word.Count() > 10)
            {
                return 0;
            }

            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var topHeight = 1;

            foreach (var letter in word)
            {
                var letterIndex = alphabet.IndexOf(letter);

                // I noticed another solution that uses the ascii dex - 97 as a way to find the index
                // In this case we will not need the alphabet variable
                // Both solutions are not perfect are they brute for a solution for a possibly more complex problem but it works
                // var letterIndex = ((int)letter) - 97;

                if (h[letterIndex] < 1)
                {
                    h[letterIndex] = 1;
                }

                if (h[letterIndex] > 7)
                {
                    h[letterIndex] = 7;
                }

                if (topHeight < h[letterIndex])
                {
                    topHeight = h[letterIndex];
                }
            }

            return word.Count() * topHeight;
        }

        public static void DesignerPdfViewerWorker()
        {
            Console.WriteLine("Designer PDF Viewer: Write 26 lowercase letter heights, separated by a space, between the values 1 and 7.");
            var h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp));

            Console.WriteLine("Designer PDF Viewer: Write a word no longer than 10 characters in lower case.");
            var word = Console.ReadLine();

            var result = DesignerPdfViewerLogic(h, word);

            Console.WriteLine(result != 0 ? $"Highlight box area: {result}mm2" : "Invalid word!");
        }
    }
}
