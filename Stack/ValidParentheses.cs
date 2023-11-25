using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.Stack
{
    internal class ValidParentheses
    {
        public ValidParentheses() { }

        public bool IsValid(string s)
        {
            Stack<char> openBrackets = new Stack<char>();
            List<char> openBracketsOptions = new List<char>() { '(', '[', '{' };
            List<char> closeBracketsOptions = new List<char>() { ')', ']', '}' };
            
            foreach (char c in s)
            {
                if(openBracketsOptions.Contains(c))
                {
                    openBrackets.Push(c);
                }
                else if(closeBracketsOptions.Contains(c))
                {
                    if (openBrackets.Count == 0)
                        return false;
                    char pop = openBrackets.Pop();
                    if(closeBracketsOptions.IndexOf(c) == -1 || openBracketsOptions.IndexOf(pop) == -1
                        || closeBracketsOptions.IndexOf(c) != openBracketsOptions.IndexOf(pop))
                    {
                        return false;
                    }
                }

            }

            if(openBrackets.Count > 0)
            {
                return false;
            }



            return true;
        }
    }
}
