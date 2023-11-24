using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney
{
    /*
     * Problem Number 1768
     * 
     * You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1.
     * If a string is longer than the other, append the additional letters onto the end of the merged string.
     * 
     * Return the merged string.
     */
    internal class MergeStringsAlternately
    {
        public MergeStringsAlternately() { }

        public string Solution(string word1, string word2)
        {
            string mergedWord = "";
            int counter = 0;
            int shorterWordLength = Math.Min(word1.Length, word2.Length);
            
            while(counter < shorterWordLength)
            {
                //Adding Alternately two letters.
                mergedWord += word1[counter];
                mergedWord += word2[counter];

                counter++;
            }

            //Adding the remainder from the long letter.
            int longerWordLength = Math.Max(word1.Length, word2.Length);
            string longerWord = (longerWordLength == word1.Length) ? word1 : word2;
            while(counter < longerWordLength)
            {
                mergedWord += longerWord[counter];
                counter++;
            }

            return mergedWord;
        }
    }
}
