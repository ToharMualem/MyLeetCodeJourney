using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.Array
{
    /*
     * Problem Number 27
     * 
     * Given an integer array nums and an integer val, remove all occurrences of val in nums in-place.
     * The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
     * 
     * Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
     * Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.
     * 
     * Return k.
     */
    internal class RemoveElement
    {
        public RemoveElement() { }

        public static int RemoveElementSolution(int[] nums, int val)
        {
            int k = nums.Length;
            int replaceIndex = nums.Length - 1;
            for (int iterator = 0; iterator < nums.Length; iterator++)
            {
                if (nums[iterator] == val)
                {
                    while (replaceIndex >= 0 && nums[replaceIndex] == val)
                    {
                        replaceIndex--;
                    }

                    if (replaceIndex >= 0)
                    {
                        nums[iterator] = nums[replaceIndex];
                        replaceIndex--;
                    }
                    k--;
                }
            }

            return k;
        }
    }
}
