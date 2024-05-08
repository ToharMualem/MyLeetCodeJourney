using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.BinaryTree.BinarySearchTree
{
    /*
     * Problem Number 530
     * 
     * Given the root of a Binary Search Tree (BST),
     * return the minimum absolute difference between the values of any two different nodes in the tree.
     * 
     */
    internal class MinimumAbsoluteDifferenceInBST
    {
        public MinimumAbsoluteDifferenceInBST() { }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public int GetMinimumDifference(TreeNode root)
        {
            List<int> elements = new List<int>();
            InOrderTraversal(root, elements);
            if(elements.Count == 0)
            {
                return 0;
            }

            int min = elements[elements.Count - 1];
            for(int i=0; i < elements.Count - 1; i++)
            {
                int diff = elements[i+1] - elements[i];
                if (min >= diff)
                {
                    min = diff;
                }
            }


            return min;
        }

        public void InOrderTraversal(TreeNode root, List<int> elements)
        {
            if(root != null)
            {
                InOrderTraversal(root.left, elements);
                elements.Add(root.val);
                InOrderTraversal(root.right, elements);
            }
        }

    }
}
