using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
namespace LinkedListMSDN
{
    class Program
    {
        static void Main(string[] args)
        {
            _LinkedList<int> list = new _LinkedList<int>();
            list.AddFirst(25);
            list.AddFirst(36);
            list.AddFirst(95);
            list.AddFirst(16);
            list.AddLast(125);
            list.AddLast(369);
            list.AddLast(852);
            list.AddLast(124);
            list.AddLast(654);
            _LinkedListNode<int> addAfterElement = list.FindLast(16);
            _LinkedListNode<int> addBeforeElement= list.FindLast(852);
            list.AddAfter(addAfterElement, 12345);
            list.AddBefore(addBeforeElement, 11111);

        }
    }
}
