using System;
using System.Collections.Generic;

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
            _LinkedListNode<int> addBeforeElement = list.FindLast(852);
            list.AddAfter(addAfterElement, 12345);
            list.AddBefore(addBeforeElement, 11111);
            list.RemoveFirst();
            list.RemoveLast();

            Stack<string> stack = new Stack<string>();
            stack.Push("xxxx");
            stack.Push("zzzz");
            stack.Push("yyyy");
            stack.Push("oooo");
            stack.Push("llll");
            var poppedElement = stack.Pop();
            var peekedElement = stack.Peek();



            Queue<string> queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            queue.Enqueue("three");
            queue.Enqueue("four");
            queue.Enqueue("five");
            queue.Enqueue("six");
            Queue<string> copiedQueue = new Queue<string>();
            foreach (var item in queue)
            {
                copiedQueue.Enqueue(item);
            }
            string firstElementRemoved = queue.Dequeue();
            queue.Clear();
            string firstElementReturned = copiedQueue.Peek();
            string[] arr = new string[6];
            arr = copiedQueue.ToArray();
        }
    }
}
