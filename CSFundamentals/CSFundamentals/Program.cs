﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSFundamentals.Concepts.ArraysStrings;
using CSFundamentals.Concepts.HashTables;

namespace CSFundamentals
{
    class Program
    {
       static void Main(string[] args)
        {
            //Console.WriteLine(Concepts.Algorithms.BitapAlgorithm.BitapSearch("The quick brown fox jumps over the lazy dog", "fox"));

            //Console.WriteLine(Concepts.Algorithms.BitapAlgorithm.GetSearchRank("The quick brown fox jumps over the lazy dog", "fox", 50));
            //Console.WriteLine(Concepts.Algorithms.BitapAlgorithm.GetSearchRank("The quick brown fox jumps over the lazy dog", "the", 50));

            Console.WriteLine(Concepts.Algorithms.BitapAlgorithm.BitapSearch("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", "eu"));
            Console.WriteLine(Concepts.Algorithms.BitapAlgorithm.GetSearchRankScore("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", "eu", 500));

            Console.ReadLine();

            // TODO: We are going to stop using static as it will mess up with some tests

            //Concepts.Sorts.InsertionSort.Display();
            //Concepts.Sorts.QuicksortTwoHrSorting.QuickSort(new int[] { 5, 8, 1, 3, 7, 9, 2 });
            //Concepts.BfsDfs.BfsShortestReach.Worker();
            //Console.WriteLine(Leetcode.Problem8Atoi.MyAtoi("3.145678"));

            // Leetcode class template
            //public class Problem
            //{
            //    /*
            //     * Leetcode problem: 
            //     * For more solutions: 
            //     */
            //}

            //https://leetcode.com/problems/continuous-subarray-sum/
            //https://leetcode.com/problems/subarray-product-less-than-k/
            //https://leetcode.com/problems/find-pivot-index/
            //https://leetcode.com/problems/subarray-sums-divisible-by-k/
            //https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/

        }
    }
}


/*
 * Top 10 Algorithms:
 * 
 * https://www.youtube.com/watch?v=r1MXwyiGi_U
 * https://www.youtube.com/watch?v=zHczhZn-z30
 * 
 *  -> Depth first search -> stack
 *  -> Breadth first search -> queue
 *  -> Matching Parenthesis -> stacks is best
 *  -> Use Hash tables -> searches, Matrix, or multidimentional arrays (keep track of something or a value - caching)
 *  -> Variable/Pointers manipulation -> pointers that travel an array parrallel or at different speeds -> longest palondromic (word that reads the same fowards are backwards) substring in a string
 *  -> Reversing a linked list -> determine if there are cycles and duplicates too
 *  -> Sorting fundamentals -> understand the concepts O(n log n)
 *      -> Quick Search
 *  -> Recursions -> indicator for good problem solving technique
 *  -> Construct custom data structures -> suffix tree-like data structure -> object oriented programming and encapsulation
 *  -> Binary Search -> sorted list where you mid-jump to find a solution O(log n) 
 *  
 */

/*
 * Information:
 * 
 * Possible exercises
 * Exercise #1
 * Array of sorted integer numbers -> Find the sum of two numbers in the array that equals to n, where n is the total sum we are looking for on the list
 * Return the pair of numbers that equal to n, else return nothing
 * One way to solve this algorithm if by evaluating the first and last element of the array.
 * If the sum results into a number smaller than the sum, then move the smaller number element up to the next element
 * If the sum results into a number greater than the sum, then move the bigger number element down to the next element
 * Keep an eye out that the element numbers do not cross, otherwise you will be doing work that has been already done.
 * You will need to check that the lowerBoundIndex is not greater than the upperBoundIndex
 * 
 * Exercise #2
 * It uses the the same type of logic as the previous exercise, find the sum of two numbers, but in this instance we are searching two Arrays of integers
 * https://www.youtube.com/watch?v=GBuHSRDGZBY
 * 
 * Excercise #3
 * This is a good exercise: https://www.youtube.com/watch?v=PIeiiceWe_w
 * 
 * More coding exercises samples: https://www.facebook.com/careers/life/sample_interview_questions
 * Also search for alien alphabet
 * 
 * This is one with a complicated algorithm. It's unlikely to be asked but it's a great watch: https://www.youtube.com/watch?v=qz9tKlF431k
 * 
 * IMPORTANT FOR DATA STRUCTURE INFO: C# System library -> https://docs.microsoft.com/en-us/dotnet/api/system?view=netcore-3.1
 * 
 * Resources
 * https://leetcode.com/
 * https://www.hackerrank.com/
 * https://www.dailycodingproblem.com/
 * https://coderbyte.com/
 * https://edabit.com/challenges
 * https://www.codechef.com/
 * https://www.codewars.com/
 * https://www.freecodecamp.org/learn/
 * https://www.topcoder.com/
 * https://codeforces.com/
 * Google Search Coading challenge sites
 * 
 * Good place to get information on Algoriths and Data Structures
 * https://en.wikipedia.org/wiki/Algorithm
 * https://en.wikipedia.org/wiki/Category:Algorithms
 * https://en.wikipedia.org/wiki/List_of_algorithms
 * https://en.wikipedia.org/wiki/Category:Sorting_algorithms
 * https://en.wikipedia.org/wiki/Sorting_algorithm
 * https://en.wikipedia.org/wiki/Category:Search_algorithms
 * https://en.wikipedia.org/wiki/Computer_science
 * https://en.wikipedia.org/wiki/List_of_data_structures
 * https://en.wikipedia.org/wiki/Time_complexity
 * https://en.wikipedia.org/wiki/Space_complexity
 * https://en.wikipedia.org/wiki/Data_structure
 * https://en.wikipedia.org/wiki/Category:Data_structures
 * https://en.wikipedia.org/wiki/Palindrome
 * https://en.wikipedia.org/wiki/Pseudocode
 * https://en.wikibooks.org/wiki/Algorithm_Implementation
 * 
 * https://www.techiedelight.com/get-subarray-of-array-csharp/
 * 
 * https://www.programmingalgorithms.com
 * 
 * We will not write here to proof concepts, we will use test for that
 * 
 * Coding challenges
 * https://www.hackerrank.com/dashboard
 * https://www.hackerrank.com/challenges/diagonal-difference/problem
 * https://www.hackerrank.com/challenges/utopian-tree/problem
 * https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list/problem
 * https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists/problem
 * https://www.hackerrank.com/challenges/compare-the-triplets/problem
 * 
 * Other Links
 * https://www.facebook.com/careers/swe-prep-techscreen
 * https://www.facebook.com/careers/life/sample_interview_questions
 */