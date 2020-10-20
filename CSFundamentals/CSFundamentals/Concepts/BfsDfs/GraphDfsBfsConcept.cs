using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.BfsDfs
{
    /*
     * Information about C# HashSets: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=netcore-3.1
     */
    public class GraphDfsBfsConcept
    {
        public class Graph
        {
            Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();

            public class Node
            {
                public int Id { get; private set; }
                public LinkedList<Node> Adjecent { get; set; }

                public Node(int id)
                {
                    Id = id;
                    Adjecent = new LinkedList<Node>();
                }
            }

            public Node GetNode(int id)
            {
                return nodeLookup[id] ?? AddNode(id);
            }

            public Node AddNode(int id)
            {
                var newNode = new Node(id);

                nodeLookup.Add(id, newNode);

                return newNode;
            }

            public void AddEdge(int source, int destination)
            {
                var sourceNode = GetNode(source);
                var destinationNode = GetNode(destination);

                sourceNode.Adjecent.AddLast(destinationNode);
            }

            public bool HasPathDfs(int source, int destination)
            {
                var sourceNode = GetNode(source);
                var destinationNode = GetNode(destination);
                var visited = new HashSet<int>();

                return HasVisitedDfs(sourceNode, destinationNode, visited);
            }

            private bool HasVisitedDfs(Node sourceNode, Node destinationNode, HashSet<int> visited)
            {
                if (visited.Contains(sourceNode.Id))
                {
                    return false;
                }

                visited.Add(sourceNode.Id);

                if (sourceNode == destinationNode)
                {
                    return true;
                }

                foreach (var child in sourceNode.Adjecent)
                {
                    if (HasVisitedDfs(child, destinationNode, visited))
                    {
                        return true;
                    }
                }

                return false;
            }

            public bool HasPathBfs(int source, int destination)
            {
                return HasPathBfs(GetNode(source), GetNode(destination));
            }

            public bool HasPathBfs(Node sourceNode, Node destinationNode)
            {
                var nextToVisit = new Queue<Node>();
                var visited = new HashSet<int>();

                nextToVisit.Enqueue(sourceNode);

                while (nextToVisit.Count > 0)
                {
                    var node = nextToVisit.Dequeue();

                    if (node == destinationNode)
                    {
                        return true;
                    }

                    if (visited.Contains(node.Id))
                    {
                        continue;
                    }

                    visited.Add(node.Id);

                    foreach (var child in node.Adjecent)
                    {
                        nextToVisit.Enqueue(child);
                    }
                }

                return false;
            }
        }
    }
}
