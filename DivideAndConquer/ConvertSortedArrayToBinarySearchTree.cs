using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.DivideAndConquer
{
    /*
     * Problem Number 108
     * 
     * Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.
     * 
     * A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one.
     */
    internal class ConvertSortedArrayToBinarySearchTree
    {

        public ConvertSortedArrayToBinarySearchTree()
        {

        }

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

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if(nums.Length == 0)
            {
                return null;
            }

            if(nums.Length == 1)
            {
                return new TreeNode(nums[0]);
            }
            
            if(nums.Length == 2)
            {
                TreeNode child = new TreeNode(nums[0]);
                return new TreeNode(nums[1], child);
            }

            if(nums.Length == 3)
            {
                TreeNode leftChild = new TreeNode(nums[0]);
                TreeNode rightChild = new TreeNode(nums[2]);
                return new TreeNode(nums[1], leftChild, rightChild);
            }

            int centerValue = nums[nums.Length / 2];
            int takeLast = (nums.Length % 2 == 0) ? nums.Length / 2 - 1: nums.Length / 2;
            TreeNode left = SortedArrayToBST(nums.Take(nums.Length / 2).ToArray());
            TreeNode right = SortedArrayToBST(nums.TakeLast(takeLast).ToArray());

            TreeNode tree = new TreeNode(centerValue, left, right);

            return tree;

        }
    }
}
