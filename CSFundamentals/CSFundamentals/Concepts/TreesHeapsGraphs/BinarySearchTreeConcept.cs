using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class BinarySearchTreeConcept
    {
        /*
         * Binary Search Tree Rules:
         *      -> All of the nodes values to the left of the parent node must be smaller than the value
         *      -> All of the nodes values to the right of the parent node must be greater than the value
         *      
         * Here are some helpful links:
         *      -> https://www.geeksforgeeks.org/binary-search-tree-data-structure/
         *      -> https://en.wikipedia.org/wiki/Binary_search_tree
         */

        public class TreeNode<T>
        {
            public T Data { get; set; }
            public List<TreeNode<T>> Children { get; set; }
        }

        public class BinarySearchTreeNode<T> : TreeNode<T>
        {
            public BinarySearchTreeNode() => Children = new List<TreeNode<T>> { null, null };

            public BinarySearchTreeNode<T> Parent { get; set; }
            public BinarySearchTreeNode<T> Left
            {
                get { return (BinarySearchTreeNode<T>)Children[0]; }
                set { Children[0] = value; }
            }
            public BinarySearchTreeNode<T> Right
            {
                get { return (BinarySearchTreeNode<T>)Children[1]; }
                set { Children[1] = value; }
            }

            public int GetHeight()
            {
                var height = 1;
                var current = this;

                while (current.Parent != null)
                {
                    height++;
                    current = current.Parent;
                }

                return height;
            }
        }

        public class BinaryTree<T>
        {
            public BinarySearchTreeNode<T> Root { get; set; }
            public int Count { get; set; }

            // TODO: Try to recreate with recursion
            public void TraversePreOrder()
            { }

            public void TraverseInOrder()
            { }

            public void TraversePostOrder()
            { }
        }

        public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
        {
            public bool Contains(T data) // Can this be done recursively? Let's try it.
            {
                var node = Root;

                while (node != null)
                {
                    var result = data.CompareTo(node.Data);

                    if (result == 0)
                    {
                        return true;
                    }
                    else if (result < 0)
                    {
                        node = node.Left;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }

                return false;
            }

            public bool ContainsRecursive(T data, BinarySearchTreeNode<T> node)
            {
                // By passing the node we can eliminate having to create a node variable
                // First we need our stopping condition
                //  -> We have two exits
                //      -> When we have a null node
                //      -> When the data matches the node's data
                if (node == null)
                {
                    return false;
                }
                if (data.CompareTo(node.Data) == 0)
                {
                    return true;
                }

                // Then we recurse through the nodes to find our comparison
                if (data.CompareTo(node.Data) < 0)
                {
                    return ContainsRecursive(data, node.Left);
                }
                else
                {
                    return ContainsRecursive(data, node.Right);
                }

                // The best strategy for recursions is to start with your stop condition
                // Then plan your recursion
                // and always pass your variables as parameters, as we do not want to possibly overflow the Stack memory
            }


            public void Add(T data)
            {
                var parent = GetParentForNewNode(data);
                var node = new BinarySearchTreeNode<T>
                {
                    Data = data,
                    Parent = parent,
                };

                if (parent == null)
                {
                    Root = node;
                }
                else if (data.CompareTo(parent.Data) < 0)
                {
                    parent.Left = node;
                }
                else
                {
                    parent.Right = node;
                }

                Count++;

            }

            private BinarySearchTreeNode<T> GetParentForNewNode(T data)
            {
                var current = Root;
                BinarySearchTreeNode<T> parent = null;

                while (current != null)
                {
                    parent = current;
                    var result = data.CompareTo(current.Data);

                    if (result == 0)
                    {
                        throw new ArgumentException($"The node {data} already exists.");
                    }
                    else if (result < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }

                return parent;
            }


            public void Remove(T data)
            {
                Remove(Root, data);
            }

            private void Remove(BinarySearchTreeNode<T> node, T data)
            {
                if (node == null)
                {
                    throw new ArgumentException($"The node {data} does not exists.");
                }
                else if (data.CompareTo(node.Data) < 0)
                {
                    Remove(node.Left, data);
                }
                else if (data.CompareTo(node.Data) > 0)
                {
                    Remove(node.Right, data);
                }
                else
                {
                    if (node.Left == null && node.Right == null)
                    {
                        ReplaceInParentNode(node, null);
                        Count--;
                    }
                    else if (node.Right == null)
                    {
                        ReplaceInParentNode(node, node.Left);
                    }
                    else if (node.Left == null)
                    {
                        ReplaceInParentNode(node, node.Right);
                    }
                    else
                    {
                        var successor = FindMinimunInSubtree(node.Right);
                        node.Data = successor.Data;
                        Remove(successor, successor.Data);
                    }
                }
            }

            private void ReplaceInParentNode(BinarySearchTreeNode<T> node, BinarySearchTreeNode<T> newNode)
            {
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = newNode;
                    }
                    else
                    {
                        node.Parent.Right = newNode;
                    }
                }
                else
                {
                    Root = newNode;
                }

                if (newNode != null)
                {
                    newNode.Parent = node.Parent;
                }
            }

            private BinarySearchTreeNode<T> FindMinimunInSubtree(BinarySearchTreeNode<T> node)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }

                return node;
            }


            public void InvertTree(BinarySearchTreeNode<T> root)
            {
                if (root == null)
                {
                    return;
                }

                // We need to swap the nodes in order to create 
                Swap(root);

                // Now we need to recurse to do the same thing to the left and right child nodes
                InvertTree(root.Left);
                InvertTree(root.Right);
            }


            private void Swap(BinarySearchTreeNode<T> node)
            {
                var tempLeftNode = node.Left;
                node.Left = node.Right;
                node.Right = tempLeftNode;
            }


            public bool ValidateBst(BinarySearchTreeNode<T> root)
            {
                // Binary Search Tree Rules: O(n) time and spacial complexity
                //      -> All of the nodes values to the left of the parent node must be smaller than the value
                //      -> All of the nodes values to the right of the parent node must be greater than the value
                // This site offers a really good explanation of validating BST
                //      -> https://www.geeksforgeeks.org/a-program-to-check-if-a-binary-tree-is-bst-or-not/
                //      -> https://www.youtube.com/watch?v=Z_-h_mpDmeg
                //      -> https://en.wikipedia.org/wiki/Binary_search_tree
                return IsValidBst(root, default(T), default(T));
            }

            private bool IsValidBst(BinarySearchTreeNode<T> node, T minData, T maxData)
            {
                if (node == null)
                {
                    return true;
                }
                else if (minData != null && node.Data.CompareTo(minData) <= 0 ||
                    maxData != null && node.Data.CompareTo(maxData) >= 0)
                {
                    return false;
                }

                return IsValidBst(node.Left, minData, node.Data) && IsValidBst(node.Right, node.Data, maxData);
            }
        }
    }
}