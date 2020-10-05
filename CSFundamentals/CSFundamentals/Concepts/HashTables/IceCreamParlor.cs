using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.HashTables
{
    public class IceCreamParlor
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/icecream-parlor/problem
         * 
         * Support docs:
         * https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
         * https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable?view=netcore-3.1
         * 
         * Sample Input
         * 
         * 2 -> t -> trips to ice cream parlor
         * 
         * -> This is trip #1 <-
         * 4 -> amount of money pooled to buy ice cream -> we will need to spend it all
         * 5 -> number of flavors
         * 1 4 5 3 2 -> cost of each flavor -> It looks like it will not be ordered
         * 
         * -> This is trip #2 <-
         * 4 -> amount of money pooled to buy ice cream -> we will need to spend it all
         * 4 -> number of flavors
         * 2 2 4 3 -> cost of each flavor -> It looks like it will not be ordered
         * 
         * Sample Output -> print two space-separated integers denoting the indices of the two flavors purchased, in ascending order
         * 1 4 -> This are the 1-based index of the first trip
         * 1 2 -> This are the 1-based index of the second trip
         * 
         * According to the sample, we already have the loop that will iterate through the visits
         *  -> But we can eventually have a method that deals with the trips, total money, and array of proces
         *  -> REMEMBER THIS IS A 1 BASED INDEX
         *  -> We return the indexes (1-based) not the prices
         *  
         *  -> We need to create a Hastable -> we will use the .NET class Hashtable (need the collections class)
         *  -> Need to add the prices to the Hashtable *** MAKING SURE IT STARTS WITH ONE
         *  -> Then we need to find the sum of two numbers that will equal to m
         *      -> When using the Hashtable class from c#, we do have access to several thing that will help us to accomplish this tasl
         *      -> We can loop through the price array and use the Hashtable Add() to add the prices 
         *          -> Or will the constructor allow passing the array and that will allow to avoid the loop?????
         *      -> Once the Hashtable is filled, then we proceed to find the sum
         *          -> Can we use Linq for this? *** Not sure if it will be worth it as we will need to write an embede function to acomplish this
         *          -> Brute force solution
         *              -> Loop through the Hashtable to see which pair will sum to m
         *                  -> [i1,1] + [i2,4]
         *                  -> [i1,1] + [i3,5]
         *                  -> [i1,1] + [i4,3]
         *                  -> [i1,1] + [i5,2]
         *                  
         *                  -> [i2,4] + [i3,5]
         *                  -> [i2,4] + [i4,3]
         *                  -> [i2,4] + [i5,2]
         *                  -> and keep moving to the next without having to worry about comparing te previous indexies as they have been compared
         *              -> Plan of Attack
         *                  -> we can do the loop in order of the indexes
         *                  -> and then compare to the other values of the hashtable
         *                  -> as we move to the next index the number of comparisons will get smaller
         *                  -> we can have an embede for loop to handle the subsequent comparisons
         *                  
         *          
         *          *** THIS APPROACH WILL NOT WORK BECAUSE THE NUMBERS ARE NOT ORDERED, IF THEY WEERE ORDERED IT WOULD WORK ***
         *          -> We can do this approach but...
         *              -> This will be on a while loop
         *              -> Need to create an upper an lower index that move
         *              -> need to order the original array
         *              -> then use Linq to find the hashtable values
         *          -> THE EXAMPLE OF THIS WILL BE OFF WITH THE FIX, SORT OF FIX
         *          -> Another option, is to go one price at a time and compare
         *              -> We can use the sumation algorithm that will compare the lower and upper values
         *                  -> Here is an example (it will be writen as an array of array but its only meant to demo the [ [index, pice], ...])
         *                      -> [ [i1,1], [i2,4], [i3,5], [i4,3], [i5,2] ] and let keep track of the price m = 4
         *                  -> We first compare the first and last price
         *                      -> Try a summation attempt [i1,1] + [i5,2] is it == 4 (1 + 2 = 3 != 4)
         *                          -> In this case because the number is lower than the supposed sum we move the lower values comparison
         *                      -> So our nex comparison will be [i2,4] + [i5,2] is it == 4 (4 + 2 = 6 != 4)
         *                          -> In this other case the number is greater than what we are looing for, then we will move the upper bound
         *                      -> Now we try [i2,4] + [i4,3] is it == 4 (4 + 3 = 7 != 4)
         *                      -> [i2,4] + [i3,5] is it == 4 (4 + 5 = 9 != 4)
         *                      -> [i2,4] + Arrrrrggg!!! (we are reapeting this is bad) 
         *                          -> we can salvage this that if the upper and lower are the same then we can do some resetting but so far this approach is nt working
         */

        public static int[] IceCreamParlorCalculateEmbededForLoop(int m, int[] arr)
        {
            // This is a brute force approach just sticking with the array
            // The time complexity is O(n^2), according to some, I would debate that it is O(arr.Length - 1 * arr.Length - 2) but basically it is similar

            var returnArray = new int[2];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int y = i + 1; y < arr.Length; y++)
                {
                    if ((arr[i] + arr[y]) == m)
                    {
                        returnArray[0] = i + 1;
                        returnArray[1] = y + 1;

                        return returnArray;
                    }
                }
            }

            return returnArray;
        }

        public static int[] IceCreamParlorCalculateHashtableEmbededForLoop(int m, int[] arr)
        {
            // This was my original try that I wasn't happy about
            // Too much computational overhead with the many looks, speecially the embeded one
            // Time complexity is still O(n^2)

            var hashtable = new Hashtable();
            var returnArray = new int[2];

            for (int i = 1; i <= arr.Length; i++)
            {
                hashtable.Add(i, arr[i - 1]);
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                for (int y = i + 1; y <= arr.Length; y++)
                {
                    if (((int)hashtable[i] + (int)hashtable[y]) == m)
                    {
                        returnArray[0] = i;
                        returnArray[1] = y;

                        return returnArray;
                    }
                }
            }

            return returnArray;
        }

        // The hackerrank.com problem has a test case that will not pass with this logic
        // It is the test case with a lot of data
        public static int[] IceCreamParlorCalculateHashtableLinkListSearch(int m, int[] arr)
        {
            // In my original solution I went with the option of using the index as my key
            // But there is the option of using the price as the key and store the index as the value
            // Many suggest to use Linked List to prevent coalitions
            //  -> A good game plan is to make that value always the same type, it is easier to deal with the same type than mixed types
            //  -> Add to the linked list

            // Reason why i don't assign a lenght to the Hashtable is because in C# these types tend to resize once they reach their size limit
            var hashtable = new Hashtable();
            LinkedList<int> indexList;
            var firstIndex = 0;
            var secondIndex = 0;

            for (int i = 1; i <= arr.Length; i++)
            {
                // we can easily get a colision, as we can see on the example Trip #2
                // so we need to verify that the keys do not colide, you get a constraint exception for trying to add an existing key
                // and add to a liked list, which is found in the System.Collections.Generic
                // Practice C#'s LinkedLists, I don't know how to use them

                if (hashtable.ContainsKey(arr[i - 1]))
                {
                    indexList = (LinkedList<int>)hashtable[arr[i - 1]];

                    indexList.AddLast(i);

                    hashtable[arr[i - 1]] = indexList;
                }
                else
                {
                    indexList = new LinkedList<int>();
                    indexList.AddLast(i);

                    hashtable.Add(arr[i - 1], indexList);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                // Now we can search by the remaining price
                // m = price1 + price2
                // m - price1 = price2
                var lookupPrice = m - arr[i];

                if (hashtable.ContainsKey(lookupPrice))
                {
                    firstIndex = i + 1;
                    indexList = (LinkedList<int>)hashtable[lookupPrice];
                    secondIndex = indexList.First.Value;

                    if (firstIndex == secondIndex && indexList.Count > 1)
                    {
                        secondIndex = indexList.Find(firstIndex).Next.Value;
                    }

                    return new int[] { firstIndex, secondIndex};
                }
            }

            return new int[2];
        }

        // This example uses Dictionary
        // We can avoid having to cast
        public static int[] IceCreamParlorCalculateDictionaryLinkListSearch(int m, int[] arr)
        {
            // In my original solution I went with the option of using the index as my key
            // But there is the option of using the price as the key and store the index as the value
            // Many suggest to use Linked List to prevent coalitions
            //  -> A good game plan is to make that value always the same type, it is easier to deal with the same type than mixed types
            //  -> Add to the linked list

            // Reason why i don't assign a lenght to the Hashtable is because in C# these types tend to resize once they reach their size limit
            var dictionary = new Dictionary<int, List<int>>();
            List<int> indexList;
            var firstIndex = 0;
            var secondIndex = 0;

            for (int i = 1; i <= arr.Length; i++)
            {
                // we can easily get a colision, as we can see on the example Trip #2
                // so we need to verify that the keys do not colide, you get a constraint exception for trying to add an existing key
                // and add to a liked list, which is found in the System.Collections.Generic
                // Practice C#'s LinkedLists, I don't know how to use them

                if (dictionary.ContainsKey(arr[i - 1]))
                {
                    indexList = dictionary[arr[i - 1]];

                    indexList.Add(i);

                    dictionary[arr[i - 1]] = indexList;
                }
                else
                {
                    indexList = new List<int>();
                    indexList.Add(i);

                    dictionary.Add(arr[i - 1], indexList);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                // Now we can search by the remaining price
                // m = price1 + price2
                // m - price1 = price2
                var lookupPrice = m - arr[i];

                if (dictionary.ContainsKey(lookupPrice))
                {
                    firstIndex = i + 1;
                    indexList = dictionary[lookupPrice];
                    secondIndex = indexList[0];

                    if (firstIndex == secondIndex && indexList.Count > 1)
                    {
                        secondIndex = indexList[1];
                    }

                    return new int[] { firstIndex, secondIndex };
                }
            }

            return new int[2];
        }

        public static int[] IceCreamParlorCalculateHashtableListSearch(int m, int[] arr)
        {
            // In my original solution I went with the option of using the index as my key
            // But there is the option of using the price as the key and store the index as the value
            // Many suggest to use Linked List to prevent coalitions
            //  -> A good game plan is to make that value always the same type, it is easier to deal with the same type than mixed types
            //  -> Add to the linked list

            // Reason why i don't assign a lenght to the Hashtable is because in C# these types tend to resize once they reach their size limit
            var hashtable = new Hashtable();
            List<int> indexList;
            var firstIndex = 0;
            var secondIndex = 0;

            for (int i = 1; i <= arr.Length; i++)
            {
                // we can easily get a colision, as we can see on the example Trip #2
                // so we need to verify that the keys do not colide, you get a constraint exception for trying to add an existing key
                // and add to a liked list, which is found in the System.Collections.Generic
                // Practice C#'s LinkedLists, I don't know how to use them

                if (hashtable.ContainsKey(arr[i - 1]))
                {
                    indexList = (List<int>)hashtable[arr[i - 1]];

                    indexList.Add(i);

                    hashtable[arr[i - 1]] = indexList;
                }
                else
                {
                    indexList = new List<int>(new int[] { i });

                    hashtable.Add(arr[i - 1], indexList);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                // Now we can search by the remaining price
                var lookupPrice = m - arr[i];

                if (hashtable.ContainsKey(lookupPrice))
                {
                    firstIndex = i + 1;
                    indexList = (List<int>)hashtable[lookupPrice];
                    secondIndex = indexList[0];

                    if (firstIndex == secondIndex)
                    {
                        secondIndex = indexList[1];
                    }

                    return new int[] { firstIndex, secondIndex };
                }
            }

            return new int[2];
        }

        // https://www.youtube.com/watch?v=7sEHjHef2zo
        // This solution uses the explanation given in this video
        // Basically we eliminate one of the loops and insert the array element that was ebing evaluate into the Hashtable or dictionary
        // We have to remember that the key/value pair will be key=(int)price and value=index in the array
        // becuase we will be saving that way and array indexes are 0-based, we have to add one to conver it to 1-base indexes
        public static int[] IceCreamParlorCalculateHashtableListSearch2(int m, int[] arr)
        {
            // For some reason this is worst
            // Two test from Hackerrank do not pass
            // The example is done in Java and it passes the tests -> I tested the code
            var hashtable = new Hashtable();
            var result = new int[2];
            var lookupPrice = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                lookupPrice = m - arr[i];

                if (hashtable.ContainsKey(lookupPrice))
                {
                    result[0] = 1 + (int)hashtable[lookupPrice];
                    result[1] = i + 1;

                    return result;
                }

                hashtable.Add(arr[i], i);
            }

            return result;
        }

        public static int[] IceCreamParlorCalculateHashtableListSearch3(int m, int[] arr)
        {
            var dictionary = new Dictionary<int, int>();
            var result = new int[2];
            var lookupPrice = 0;
            var currentPrice = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentPrice = arr[i];
                lookupPrice = m - currentPrice;

                if (dictionary.ContainsKey(lookupPrice))
                {
                    result[0] = dictionary[lookupPrice] + 1;
                    result[1] = i + 1;

                    return result;
                }

                // Finally got all of the test to pass
                // The problem was that in C#, if we try to insert the same key to the dictionary, it will throw and exception
                // In this case, we want to save the first instance in the Dictionary
                // With Hashtable we can adopt the same idea but slightly modified to accomodate the class
                // The outer loop will loop through all of the necesary results
                // For more information:
                // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add?view=netcore-3.1
                // https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable?view=netcore-3.1
                if (!dictionary.ContainsKey(currentPrice)) 
                {
                    dictionary.Add(currentPrice, i);
                }
            }

            return result;
        }

        public static int[] IceCreamParlorCalculateHashtableListSearch4(int m, int[] arr)
        {
            var dictionary = new Dictionary<int, List<int>>();
            var result = new int[2];

            for (int i = 0; i < arr.Length; i++)
            {
                int currentPrice = arr[i];
                int lookupPrice = m - currentPrice;

                if (dictionary.ContainsKey(lookupPrice))
                {
                    result[0] = dictionary[lookupPrice][0] + 1;
                    result[1] = i + 1;

                    return result;
                }

                // Now if we want to keep track of all of our values, in case they need to be used, then the logic changes
                if (!dictionary.ContainsKey(currentPrice))
                {
                    dictionary.Add(currentPrice, new List<int> { i });
                }
                else
                {
                    var modifiedList = dictionary[currentPrice];

                    modifiedList.Add(i);

                    dictionary[currentPrice] = modifiedList;
                }
            }

            return result;
        }

        public static void IceCreamParlorWorker()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int m = Convert.ToInt32(Console.ReadLine());

                int n = Convert.ToInt32(Console.ReadLine());

                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
                ;
                int[] result = IceCreamParlorCalculateEmbededForLoop(m, arr);

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
