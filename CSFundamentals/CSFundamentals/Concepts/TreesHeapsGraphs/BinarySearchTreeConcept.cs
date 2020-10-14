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
            }
        }
    }
}
