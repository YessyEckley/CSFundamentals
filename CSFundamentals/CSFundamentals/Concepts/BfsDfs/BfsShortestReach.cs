using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.Concepts.BfsDfs
{
    public class BfsShortestReach
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/bfsshortreach/problem
         * 
         * Strategy
         *      -> n: the integer number of nodes
         *      -> m: the integer number of edges
         *      -> edges: a 2D array of start and end nodes for edges
         *      -> s: the node to start traversals from
         * 
         * NOTES: Important link: https://docs.microsoft.com/en-us/dotnet/api/system.array.length?view=netcore-3.1
         *                        https://en.wikipedia.org/wiki/Breadth-first_search
         *                        https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
         *                        https://www.geeksforgeeks.org/shortest-path-unweighted-graph/
         *                        https://www.geeksforgeeks.org/hashset-in-c-sharp-with-examples/
         * 
         * IMPOTANT: Debug your code by talking out loud
         * 
         * Here is another example on how to do it.
         *      -> https://www.hackerrank.com/rest/contests/master/challenges/bfsshortreach/hackers/sdgadfgas/download_solution
         * This solution didn't passed all of the test cases
         */

        public Dictionary<int, List<int>> NodeDictionary;

        public const int WEIGTH = 6;

        private void BuildDictionary(int[][] edges)
        {
            NodeDictionary = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.Length; i++)
            {
                int source = edges[i][0];
                int destination = edges[i][1];
                if (!NodeDictionary.ContainsKey(source))
                {
                    NodeDictionary.Add(source, new List<int> { destination });
                }
                else
                {
                    if (!NodeDictionary[source].Contains(destination))
                    {
                        NodeDictionary[source].Add(destination);
                    }
                }

                if (!NodeDictionary.ContainsKey(destination))
                {
                    NodeDictionary.Add(destination, new List<int> { source });
                }
                else
                {
                    if (!NodeDictionary[destination].Contains(source))
                    {
                        NodeDictionary[destination].Add(source);
                    }
                }
            }
        }

        public int[] Bfs(int n, int m, int[][] edges, int s)
        {
            var queue = new Queue<int>();
            var visitedMinDistance = new Dictionary<int, int>();
            var returnValues = new int[n - 1];
            var returnValuesIndex = 0;
            BuildDictionary(edges);

            queue.Enqueue(s);
            visitedMinDistance.Add(s, 0);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var dictionaryEntry = NodeDictionary[vertex];

                if (dictionaryEntry != null)
                {
                    if (dictionaryEntry.Count > 0)
                    {
                        foreach (var child in dictionaryEntry)
                        {
                            if (!visitedMinDistance.ContainsKey(child))
                            {
                                queue.Enqueue(child);
                                visitedMinDistance.Add(child, visitedMinDistance[vertex] + 1);
                            }
                            else if (visitedMinDistance[child] > visitedMinDistance[vertex])
                            {
                                visitedMinDistance.Add(child, visitedMinDistance[vertex] + 1);
                            }
                        }
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                if (i != s)
                {
                    if (!visitedMinDistance.ContainsKey(i))
                    {
                        returnValues[returnValuesIndex] = -1;
                    }
                    else
                    {
                        returnValues[returnValuesIndex] = visitedMinDistance[i] * 6; 
                    }

                    returnValuesIndex++;
                }
            }

            return returnValues;
        }

        public void Worker()
        {
            //int q = Convert.ToInt32(Console.ReadLine());

            //for (int qItr = 0; qItr < q; qItr++)
            //{
            //    string[] nm = Console.ReadLine().Split(' ');

            //    int n = Convert.ToInt32(nm[0]);

            //    int m = Convert.ToInt32(nm[1]);

            //    int[][] edges = new int[m][];

            //    for (int i = 0; i < m; i++)
            //    {
            //        edges[i] = Array.ConvertAll(Console.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
            //    }

            //    int s = Convert.ToInt32(Console.ReadLine());

            //    int[] result = Bfs(n, m, edges, s);

            //    Console.WriteLine(string.Join(" ", result));
            //}

            // TEST CASES
            int n = 4;
            int m = 2;
            int[][] edges = new int[2][]
                {
                    new int[2]{ 1, 2 },
                    new int[2]{ 1, 3 }
                };
            int s = 1;

            int[] result = Bfs(n, m, edges, s);
            Console.WriteLine(string.Join(" ", result));

            n = 3;
            m = 1;
            int[][] edges2 = new int[1][]
                {
                    new int[2]{ 2, 3 }
                };
            s = 2;

            result = Bfs(n, m, edges2, s);
            Console.WriteLine(string.Join(" ", result));

            n = 5;
            m = 3;
            int[][] edges3 = new int[3][]
                {
                    new int[2]{ 1, 2 }, 
                    new int[2]{ 1, 3 },
                    new int[2]{ 3, 4 }
                };
            s = 1;

            result = Bfs(n, m, edges3, s);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}