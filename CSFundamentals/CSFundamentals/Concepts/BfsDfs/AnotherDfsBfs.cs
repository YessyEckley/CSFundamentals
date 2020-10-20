using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.BfsDfs
{
    public class AnotherDfsBfs
    {
        public class Node<T>
        {
            public int Index { get; set; }
            public T Data { get; set; }
            public List<Node<T>> Neighbors { get; set; } = new List<Node<T>>();
            public List<int> Weights { get; set; } = new List<int>();

            public override string ToString()
            {
                return $"Node with index {Index}: {Data}, Neighbors {Neighbors.Count}";
            }
        }



        public class Edge<T>
        {
            public Node<T> From { get; set; }
            public Node<T> To { get; set; }
            public int Weight { get; set; }

            public override string ToString()
            {
                return $"Edge: {From.Data} -> {To.Data}, weight: {Weight}";
            }
        }



        public class Graph<T>
        {
            private bool _isDirected = false;
            private bool _isWeighted = false;
            public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

            public Graph(bool isDirected, bool isWeighted)
            {
                _isDirected = isDirected;
                _isWeighted = isWeighted;
            }

            // Indexer
            public Edge<T> this[int from, int to]
            {
                get
                {
                    var nodeFrom = Nodes[from];
                    var nodeTo = Nodes[to];
                    var i = nodeFrom.Neighbors.IndexOf(nodeTo);

                    if (i >= 0)
                    {
                        var edge = new Edge<T>
                        {
                            From = nodeFrom,
                            To = nodeTo,
                            Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
                        };

                        return edge;
                    }

                    return null;
                }
            }

            public Node<T> AddNode(T value)
            {
                var node = new Node<T> { Data = value };
                Nodes.Add(node);
                UpdateIndices();
                return node;
            }

            public void RemoveNode(Node<T> nodeToRemove)
            {
                Nodes.Remove(nodeToRemove);
                UpdateIndices();

                foreach (var node in Nodes)
                {
                    RemoveEdge(node, nodeToRemove);
                }
            }

            public void AddEdge(Node<T> from, Node<T> to, int weight = 0)
            {
                from.Neighbors.Add(to);

                if (_isWeighted)
                {
                    from.Weights.Add(weight);
                }

                if (!_isDirected)
                {
                    to.Neighbors.Add(from);

                    if (_isWeighted)
                    {
                        to.Weights.Add(weight);
                    }
                }
            }

            public void RemoveEdge(Node<T> from, Node<T> to)
            {
                var index = from.Neighbors.FindIndex(n => n == to);
                if (index >= 0)
                {
                    from.Neighbors.RemoveAt(index);

                    if (_isWeighted)
                    {
                        from.Weights.RemoveAt(index);
                    }
                }
            }

            public List<Edge<T>> GetEdges()
            {
                var edges = new List<Edge<T>>();

                foreach (var from in Nodes)
                {
                    for (int i = 0; i < from.Neighbors.Count; i++)
                    {
                        var edge = new Edge<T>
                        {
                            From = from,
                            To = from.Neighbors[i],
                            Weight = i < from.Weights.Count ? from.Weights[i] : 0
                        };

                        edges.Add(edge);
                    }
                }

                return edges;
            }

            private void UpdateIndices()
            {
                var i = 0;
                Nodes.ForEach(n => n.Index = i++);
            }

            public List<Node<T>> Dfs()
            {
                var isVisited = new bool[Nodes.Count];

                var result = new List<Node<T>>();

                Dfs(isVisited, Nodes[0], result);

                return null;
            }

            private void Dfs(bool[] isVisited, Node<T> node, List<Node<T>> result)
            {
                /*
                 * More information about Depth-first search:
                 *          https://en.wikipedia.org/wiki/Depth-first_search
                 */

                result.Add(node);
                isVisited[node.Index] = true;

                foreach (var neighbor in node.Neighbors)
                {
                    if (!isVisited[neighbor.Index])
                    {
                        Dfs(isVisited, neighbor, result);
                    }
                }
            }

            public List<Node<T>> Bfs()
            {
                return Bfs(Nodes[0]);
            }

            private List<Node<T>> Bfs(Node<T> node)
            {
                /*
                 * For more information:
                 *          https://en.wikipedia.org/wiki/Breadth-first_search
                 */

                var isVisited = new bool[Nodes.Count];
                isVisited[node.Index] = true;

                var result = new List<Node<T>>();
                var queue = new Queue<Node<T>>();

                queue.Enqueue(node);

                while (queue.Count > 0)
                {
                    var next = queue.Dequeue();
                    result.Add(next);

                    foreach (var neighbor in next.Neighbors)
                    {
                        if (!isVisited[neighbor.Index])
                        {
                            isVisited[neighbor.Index] = true;
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                return result;
            }
        }
    }
}
