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
         */

        public static Dictionary<int, Node> NodeDictionary;

        public const int WEIGTH = 6;

        public class Node
        {
            public int Data { get; set; }
            public HashSet<Node> Adjecent { get; set; }
            public int Weight { get; }
            public int Level { get; set; }

            public Node(int data)
            {
                Data = data;
                Adjecent = new HashSet<Node>();
                Weight = 6;
                Level = -1;

            }
        }

        public static void BuildGraph(int n, int[][] edges)
        {
            NodeDictionary = new Dictionary<int, Node>();

            for (int i = 1; i <= n; i++)
            {
                NodeDictionary.Add(i, new Node(i));
            }

            AddEdges(edges);
        }

        public static void AddEdges(int[][] edges)
        {
            for (int i = 0; i < edges.Length; i++)
            {
                if (NodeDictionary.ContainsKey(edges[i][0]))
                {
                    var vertex = NodeDictionary[edges[i][0]];

                    if (vertex.Level == -1)
                    {
                        vertex.Level = 0;
                    }

                    if (!vertex.Adjecent.Any(x => x.Data == edges[i][1]))
                    {
                        var newNodeItem = NodeDictionary[edges[i][1]];

                        newNodeItem.Level = vertex.Level + 1;

                        vertex.Adjecent.Add(newNodeItem);
                    }
                    
                }
            }
        }

        public static int[] Bfs(int n, int m, int[][] edges, int s)
        {
            var queue = new Queue<int>();
            var visitedMinDistance = new Dictionary<int, int>();
            var returnValues = new int[n - 1];
            var returnValuesIndex = 0;
            BuildGraph(n, edges);

            queue.Enqueue(s);
            visitedMinDistance.Add(s, 0);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var node = NodeDictionary[vertex];

                if (node != null)
                {
                    //var index = visitedMinDistance.ContainsKey(vertex) ? visitedMinDistance[vertex] : 0;
                    if (node.Adjecent.Count > 0)
                    {
                        foreach (var child in node.Adjecent)
                        {
                            if (!visitedMinDistance.ContainsKey(child.Data))
                            {
                                queue.Enqueue(child.Data);
                                visitedMinDistance.Add(child.Data, child.Level);
                            }
                            else if (visitedMinDistance[child.Data] > visitedMinDistance[vertex])
                            {
                                visitedMinDistance.Add(child.Data, child.Level);
                            }
                        }
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                if (i != s)
                {
                    if (visitedMinDistance.ContainsKey(i))
                    {
                        returnValues[returnValuesIndex] = visitedMinDistance[i] * 6;
                    }
                    else
                    {
                        returnValues[returnValuesIndex] = -1;
                    }

                    returnValuesIndex++;
                }
            }

            return returnValues;
        }

        public static void Worker()
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



/*

This is the Java solution that  works
import java.io.*;
import java.util.*;

public class Solution {
    private static int mN;
    private static int mM;
    private static Integer mS;
    private static Map<Integer, Set<Integer>> mNodeToNeigh;

    public static void main(String[] args) {
        final Scanner scanner = new Scanner(System.in);
        int numberTests = scanner.nextInt();
        while (numberTests > 0) {
            parseArguments(scanner);
            computeOutput();
            numberTests--;
        }
    }

    private static void computeOutput() {
        Queue<Integer> queue = new LinkedList<Integer>();
        Map<Integer, Integer> visitedMinDis = new HashMap<>();
        visitedMinDis.put(mS, 0);
        queue.add(mS);

        while(!queue.isEmpty()) {
            Integer element = queue.remove();

            if (mNodeToNeigh.get(element) != null) {
                for(Integer neigh : mNodeToNeigh.get(element)) {
                    if(!visitedMinDis.containsKey(neigh)) {
                        queue.add(neigh);
                        visitedMinDis.put(neigh, visitedMinDis.get(element) + 1);
                    } else if(visitedMinDis.get(neigh) > visitedMinDis.get(element) + 1) {
                        visitedMinDis.put(neigh, visitedMinDis.get(element) + 1);
                    }
                }
            }
        }

        for (Integer i = 1; i <= mN; i++) {
            if (!i.equals(mS)) {
                Integer dis = visitedMinDis.get(i);
                if (dis == null) {
                    System.out.print(-1 + " ");
                } else {
                    System.out.print(dis * 6 + " ");
                }
            }
        }
        System.out.println();
    }

    private static void parseArguments(Scanner scanner) {
        mN = scanner.nextInt();
        mM = scanner.nextInt();

        mNodeToNeigh = new HashMap<>(mM);
        int x;
        int y;
        for (int i = 0; i < mM; i++) {
            x = scanner.nextInt();
            y = scanner.nextInt();
            Set<Integer> neighX;
            if(mNodeToNeigh.get(x) == null) {
                neighX = new HashSet<Integer>();
            } else {
                neighX = mNodeToNeigh.get(x);
            }
            neighX.add(y);
            mNodeToNeigh.put(x, neighX);

            Set<Integer> neighY;
            if(mNodeToNeigh.get(y) == null) {
                neighY = new HashSet<Integer>();
            } else {
                neighY = mNodeToNeigh.get(y);
            }
            neighY.add(x);
            mNodeToNeigh.put(y, neighY);
        }
        mS = new Integer(scanner.nextInt());
    }
}
 
 */
