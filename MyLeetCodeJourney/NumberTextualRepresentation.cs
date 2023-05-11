using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney
{
    internal class NumberTextualRepresentation
    {
        private readonly Dictionary<int, string> namedNumbers = new()
        {
            {0, "Zero" }, {1, "One"}, {2 , "Two"}, {3, "Three"}, {4, "Four" }, {5, "Five"}, {6 , "Six"}, {7, "Seven"}, {8, "Eight" }, {9, "Nine"}, {10 , "Ten"},
            {11, "Eleven"}, {12 , "Twelve"}, {13, "Thirteen"}, {14, "Fourteen" }, {15, "Fifteen"}, {16 , "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen" }, {19, "Nineteen"},
            {20, "Twenty" }, {30, "Thirty" }, {40, "Forty"}, {50, "Fifty"}, { 60, "Sixty" }, { 70, "Seventy" }, { 80, "Eighty" }, { 90, "Ninety"}
        };

        private readonly Dictionary<int, string> divideNumbers = new() { { 1000000000, "Billion" }, { 1000000, "Million" }, { 1000, "Thousand" }, { 100, "Hundred" } };

        public NumberTextualRepresentation() { }

        /// <summary>
        /// Returns a text name of a given number.
        /// </summary>
        /// <param name="number">a number between 0 - 1 Billion</param>
        /// <returns></returns>
        public string NumberToString(int number)
        {
            string constructedName = string.Empty;
            foreach(var divider in divideNumbers.Keys)
            {

                if(number / divider  != 0)
                {
                    constructedName += NumberToString(number / divider) + divideNumbers[divider];
                    number %= divider;
                }
            }

            // in case that number is less than 100.
            if (number != 0)
            {
                constructedName += UnderOneHundredString(number);
            }

            return constructedName;
            
        }

        private string UnderOneHundredString(int number)
        {
            if (namedNumbers.TryGetValue(number, out var name))
            {
                return name;
            }

            string constructedName = string.Empty;
            constructedName += namedNumbers[number - number % 10];
            if(number % 10 != 0)
            {
                constructedName += namedNumbers[number % 10];
            }


            return constructedName;
        }
    }
}
