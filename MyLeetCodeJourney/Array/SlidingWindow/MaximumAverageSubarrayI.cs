using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney
{
    /*
     * Problem Number 643
     * 
     * You are given an integer array nums consisting of n elements, and an integer k.
     * 
     * Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value.
     * Any answer with a calculation error less than 10-5 will be accepted.
     * 
     */
    internal class MaximumAverageSubarrayI
    {
        public MaximumAverageSubarrayI() { }

        public double FindMaxAverage(int[] nums, int k)
        {
            //We will find the maximum sum and divide it by k. It's also the maximum averge.
            int currentSum = 0;
            int maximumSum = 0;
            
            //Find the sum of first k elements.
            currentSum = nums.Take(k).Sum();
            maximumSum = currentSum;

            //Iterate with two indices through nums in sliding window technique.
            int leftIndex = 0;
            int rightIndex = k;
            while(rightIndex < nums.Length)
            {
                //Adding rightIndex value and substrcacting leftIndex to find the next subarray sum. 
                currentSum -= nums[leftIndex];
                currentSum += nums[rightIndex];
                leftIndex++;
                rightIndex++;

                //In case which currentSum is bigger than maximumSum.
                if(currentSum > maximumSum)
                {
                    maximumSum = currentSum;
                }
            }

            double maximumAverge = (double)maximumSum / (double)k;
            return maximumAverge;
        }
    }
}
