using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney
{
    /*
     * You have a RecentCounter class which counts the number of recent requests within a certain time frame.
     * Implement the RecentCounter class:
     * 
     * RecentCounter() Initializes the counter with zero recent requests.
     * 
     * int ping(int t) Adds a new request at time t, where t represents some time in milliseconds, -->
     * and returns the number of requests that has happened in the past 3000 milliseconds (including the new request).-->
     * Specifically, return the number of requests that have happened in the inclusive range [t - 3000, t].
     * 
     * It is guaranteed that every call to ping uses a strictly larger value of t than the previous call.
     */
    internal class RecentCounter
    {
        private Queue<int> recentCalls;
        private readonly int timePastInterval = 3000;

        public RecentCounter() {
            recentCalls = new Queue<int>();
        }

        public int Ping(int t)
        {
            recentCalls.Enqueue(t);

            // Remove too old calls from recentCalls
            Tuple<int, int> validCallsRange = Tuple.Create(t - timePastInterval, t);
            while(recentCalls.Count > 0 && recentCalls.Peek() < validCallsRange.Item1)
            {
                recentCalls.Dequeue();
            }


            return recentCalls.Count;

        }
    }
}
