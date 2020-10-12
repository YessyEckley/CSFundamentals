using System;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class BinaryTreeConcept
    {
        public class TreeNode<T>
        {
            public T Data { get; set; }
            public TreeNode<T> Parent { get; set; }
            public List<TreeNode<T>> Children { get; set; }

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

        public class BinaryTreeNode<T> : TreeNode<T>
        {
            public BinaryTreeNode<T> Left
            {
                get { return (BinaryTreeNode<T>)Children[0]; }
                set { Children[0] = value; }
            }

            public BinaryTreeNode<T> Right
            {
                get { return (BinaryTreeNode<T>)Children[1]; }
                set { Children[1] = value; }
            }

            public BinaryTreeNode() => Children = new List<TreeNode<T>> { null, null };
        }

        public class BinaryTree<T>
        {
            public BinaryTreeNode<T> Root { get; set; }
            public int Count { get; set; }

            public enum TraversalEnum
            {
                PREORDER,
                INORDER,
                POSTORDER
            }

            public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
            {
                var nodes = new List<BinaryTreeNode<T>>();

                switch (mode)
                {
                    case TraversalEnum.PREORDER:
                        TraversePreOrder(Root, nodes);
                        break;
                    case TraversalEnum.INORDER:
                        TraverseInOrder(Root, nodes);
                        break;
                    case TraversalEnum.POSTORDER:
                        TraversePostOrder(Root, nodes);
                        break;
                    default:
                        break;
                }

                return nodes;
            }

            public int GetHeight()
            {
                var height = 0;

                foreach (var node in Traverse(TraversalEnum.PREORDER))
                {
                    height = Math.Max(height, node.GetHeight());
                }

                return height;
            }

            private void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
            {
                if (node != null)
                {
                    result.Add(node);
                    TraversePreOrder(node.Left, result);
                    TraversePreOrder(node.Right, result);
                }
            }

            private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
            {
                if (node != null)
                {
                    TraverseInOrder(node.Left, result);
                    result.Add(node);
                    TraverseInOrder(node.Right, result);
                }
            }

            private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
            {
                if (node != null)
                {
                    TraversePostOrder(node.Left, result);
                    TraversePostOrder(node.Right, result);
                    result.Add(node);
                }
            }
        }
    }
}
