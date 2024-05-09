using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.DP_1D
{
    internal class N_thTribonacciNumber
    {
        /*
        * Problem Number 1137
        * 
        * The Tribonacci sequence Tn is defined as follows: 
        * T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.
        * 
        * Given n, return the value of Tn.
        */
        public N_thTribonacciNumber() { }

        public int Tribonacci(int n)
        {
            int n_thNum = 0;
            int n_plusOneNum = 1;
            int n_plusTwoNum = 1;

            for(int i = 1; i <= n; i++)
            {
                int n_plusThreeNum = n_thNum + n_plusOneNum + n_plusTwoNum;
                n_thNum = n_plusOneNum;
                n_plusOneNum = n_plusTwoNum;
                n_plusTwoNum = n_plusThreeNum;
            }

            return n_thNum;
        }
        
    }
}
