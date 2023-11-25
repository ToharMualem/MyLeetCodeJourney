using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.LinkedList
{
    /*
     * Problem Number 2
     * 
     * You are given two non-empty linked lists representing two non-negative integers.
     * The digits are stored in reverse order, and each of their nodes contains a single digit.
     * Add the two numbers and return the sum as a linked list.
     * 
     * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
     */
    internal class AddTwoNumbers
    {
        public AddTwoNumbers() { }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int value, ListNode nextNode = null)
            {
                val = value;
                next = nextNode;
            }
        }

        public ListNode AddTwoNumbersSolution(ListNode l1, ListNode l2)
        {
            string l1StringNum = "";
            ListNode iterator = l1;
            while(iterator != null)
            {
                l1StringNum += iterator.val.ToString();
                iterator = iterator.next;
            }
            l1StringNum = new string(l1StringNum.Reverse().ToArray());
            ulong l1Num = ulong.Parse(l1StringNum);

            string l2StringNum = "";
            iterator = l2;
            while(iterator != null)
            {
                l2StringNum += iterator.val.ToString();
                iterator = iterator.next;
            }
            l2StringNum = new string(l2StringNum.Reverse().ToArray());
            ulong l2Num = ulong.Parse(l2StringNum);

            //Constructing the third linked list
            ulong listNum = l1Num + l2Num;
            string listStringNum = listNum.ToString();
            
            if(listNum == 0)
            {
                return new ListNode(0);
            }

            iterator = new ListNode(int.Parse(listStringNum[0].ToString()));
            for(int i = 1; i<listStringNum.Length; i++)
            {
                ListNode newNode = new ListNode(int.Parse(listStringNum[i].ToString()), iterator);
                iterator = newNode;
            }

            return iterator;
        }
    }
}
