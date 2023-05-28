using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney
{
    /*
     * Problem Number 700
     * 
     * You are given the root of a binary search tree (BST) and an integer val.
     * 
     * Find the node in the BST that the node's value equals val and return the subtree rooted with that node.
     * If such a node does not exist, return null.
     * 
     */
    internal class SearchInABinarySearchTree
    {
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

        public SearchInABinarySearchTree() { }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            //If root is null, there is no such a value.
            if(root == null)
            {
                return root;
            }

            //Value is found, return root.
            if(root.val == val) return root;

            //If value is smaller than root's value, search the left subtree. else, search the right one.
            if(val <= root.val)
            {
                return SearchBST(root.left, val);
            }
            else
            {
                return SearchBST(root.right, val);
            }
        }
    }
}
