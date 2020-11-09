using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSFundamentals.Concepts.BfsDfs
{
    public class SnakesAndLadders
    {
        /*
         * Link to the problem: https://www.hackerrank.com/challenges/the-quickest-way-up/problem
         * 
         * Strategy
         *      -> 
         * 
         * NOTES: 
         * 
         * IMPOTANT: Debug your code by talking out loud
         */

        public class Node
        {
            public int Data { get; set; }
            public Dictionary<int, string> Destination { get; set; }

            public Node(int data)
            {
                Data = data;
                Destination = new Dictionary<int, string>();
            }
        }

        public class SnakesAndLaddersGraph
        {
            public Dictionary<int, Node> Snakes { get; set; }
            public Dictionary<int, Node> Ladders { get; set; }
            public Dictionary<int, int> VisitedSquareRoll { get; set; }

            public SnakesAndLaddersGraph(int[][] ladders, int[][] snakes)
            {
                Snakes = new Dictionary<int, Node>();
                Ladders = new Dictionary<int, Node>();
                VisitedSquareRoll = new Dictionary<int, int>();

                BuildDictionaries(Snakes, snakes);
                BuildDictionaries(Ladders, ladders);
            }

            private void BuildDictionaries(Dictionary<int, Node> property, int[][] infoArray)
            {
                for (int i = 0; i < infoArray.Length; i++)
                {
                    if (!property.ContainsKey(infoArray[i][0]))
                    {
                        var newNode = new Node(infoArray[i][0]);
                        newNode.Destination.Add(infoArray[i][1], infoArray[i][1].ToString());

                        property.Add(infoArray[i][0], newNode);
                    }
                    else
                    {
                        if (property[infoArray[i][0]].Destination[infoArray[i][1]] != null)
                        {
                            property[infoArray[i][0]].Destination.Add(infoArray[i][1], infoArray[i][1].ToString());
                        }
                    }
                }
            }

            /* This was the first attempt but then I found a way to make it generic an reusable

            private void BuildSnakes(int[][] snakes)
            {
                for (int i = 0; i < snakes.Length; i++)
                {
                    if (!Snakes.ContainsKey(snakes[i][0]))
                    {
                        var newNode = new Node(snakes[i][0]);
                        newNode.Destination.Add(snakes[i][1]);

                        Snakes.Add(snakes[i][0], newNode);
                    }
                    else
                    {
                        if (!Snakes[snakes[i][0]]?.Destination.Contains(snakes[i][1]) ?? false)
                        {
                            Snakes[snakes[i][0]].Destination.Add(snakes[i][1]);
                        }
                    }
                }
            }

            private void BuildLadders(int[][] ladders)
            {
                for (int i = 0; i < ladders.Length; i++)
                {
                    if (!Ladders.ContainsKey(ladders[i][0]))
                    {
                        var newNode = new Node(ladders[i][0]);
                        newNode.Destination.Add(ladders[i][1]);

                        Ladders.Add(ladders[i][0], newNode);
                    }
                    else
                    {
                        if (!Ladders[ladders[i][0]]?.Destination.Contains(ladders[i][1]) ?? false)
                        {
                            Ladders[ladders[i][0]].Destination.Add(ladders[i][1]);
                        }
                    }
                }
            } */
        }

        public int QuickestWayUp(int[][] ladders, int[][] snakes)
        {
            var snakesAndLaddersGraph = new SnakesAndLaddersGraph(ladders, snakes);
            var queue = new Queue<int>();

            queue.Enqueue(1);
            snakesAndLaddersGraph.VisitedSquareRoll.Add(1, 0);

            while (queue.Count > 0)
            {
                var roll = queue.Dequeue();

                if (roll == 100)
                {
                    return snakesAndLaddersGraph.VisitedSquareRoll[100];
                }

                for (int i = 1; i <= 6; i++)
                {
                    var newRollSum = roll + i;

                    if (snakesAndLaddersGraph.Ladders.ContainsKey(newRollSum))
                    {
                        newRollSum = snakesAndLaddersGraph.Ladders[newRollSum].Destination.Keys.Max();
                    }
                    else if (snakesAndLaddersGraph.Snakes.ContainsKey(newRollSum))
                    {
                        newRollSum = snakesAndLaddersGraph.Snakes[newRollSum].Destination.Keys.Min();
                    }

                    if (!snakesAndLaddersGraph.VisitedSquareRoll.ContainsKey(newRollSum))
                    {
                        snakesAndLaddersGraph.VisitedSquareRoll.Add(newRollSum, snakesAndLaddersGraph.VisitedSquareRoll[roll] + 1);
                        queue.Enqueue(newRollSum);
                    }
                    else if (snakesAndLaddersGraph.VisitedSquareRoll[newRollSum] > snakesAndLaddersGraph.VisitedSquareRoll[roll] + 1)
                    {
                        snakesAndLaddersGraph.VisitedSquareRoll[newRollSum] = snakesAndLaddersGraph.VisitedSquareRoll[roll] + 1;
                    }
                }
            }

            return -1;
        }
    }
}
