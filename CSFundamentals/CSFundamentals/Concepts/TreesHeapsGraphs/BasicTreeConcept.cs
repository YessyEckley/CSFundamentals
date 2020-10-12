using System;
using System.Collections;
using System.Collections.Generic;

namespace CSFundamentals.Concepts.TreesHeapsGraphs
{
    public class BasicTreeConcept
    {
        public class TreeNode<T>
        {
            public T Data { get; set; }
            public TreeNode<T> Parent { get; set; }
            public List<TreeNode<T>> Children { get; set; }

            public int GetHeight()
            {
                int height = 1;
                var current = this;

                while (current.Parent != null)
                {
                    height++;
                    current = current.Parent;
                }

                return height;
            }
        }

        public class Tree<T>
        {
            public TreeNode<T> Root { get; set; }
        }

        public void BasicTreeWorker()
        {
            var tree = new Tree<int>();
            tree.Root = new TreeNode<int> { Data = 100 };

            tree.Root.Children = new List<TreeNode<int>>
            {
                new TreeNode<int>{ Data = 50, Parent = tree.Root },
                new TreeNode<int>{ Data = 1, Parent = tree.Root },
                new TreeNode<int>{ Data = 150, Parent = tree.Root },
            };

            tree.Root.Children[2].Children = new List<TreeNode<int>>
            {
                new TreeNode<int>{ Data = 30, Parent = tree.Root.Children[2] }
            };
        }
    }
}
