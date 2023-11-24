using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.Array
{
    /*
     * Problem Number 88
     * 
     * You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
     * 
     * Merge nums1 and nums2 into a single array sorted in non-decreasing order.
     * 
     * The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
     * To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
     * 
     */
    internal class MergeSortedArray
    {
        public MergeSortedArray() { }

        public static void Merge(int[] num1, int m, int[] num2, int n)
        {
            int iteratorNum1 = m - 1;
            int iteratorNum2 = n - 1;
            int iteratorCombined = m + n - 1;
            
            while (iteratorNum1 >= 0 && iteratorNum2 >=0)
            {
                if (num2[iteratorNum2] >= num1[iteratorNum1])
                {
                    num1[iteratorCombined] = num2[iteratorNum2];
                    iteratorNum2--;
                }
                else
                {
                    num1[iteratorCombined] = num1[iteratorNum1];
                    iteratorNum1--;
                }

                iteratorCombined--;
            }
            
            while(iteratorNum2 >= 0)
            {
                num1[iteratorCombined] = num2[iteratorNum2];
                iteratorNum2--;
                iteratorCombined--;
            }

        }
    }
}
