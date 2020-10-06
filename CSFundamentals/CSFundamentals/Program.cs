using System;
using System.Linq;
using CSFundamentals.Concepts.ArraysStrings;
using CSFundamentals.Concepts.HashTables;

namespace CSFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // For unit testing
            //Console.WriteLine($"Result: {ColorfulNumbers.IsColorfulNumbers(0)}");
            //Console.WriteLine();
            //Console.WriteLine($"Result: {ColorfulNumbers.IsColorfulNumbers(3245)}");
            //Console.WriteLine();
            //Console.WriteLine($"Result: {ColorfulNumbers.IsColorfulNumbers(326)}");
        }
    }
}

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
 * https://en.wikipedia.org/wiki/List_of_algorithms
 * https://en.wikipedia.org/wiki/Computer_science
 * https://en.wikipedia.org/wiki/List_of_data_structures
 * https://en.wikipedia.org/wiki/Time_complexity
 * https://en.wikipedia.org/wiki/Space_complexity
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
 */
