using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListMSDN
{
   public  class _LinkedList<T>
    {
        internal _LinkedListNode<T> _head;
        internal int _count;
        internal int _version;
        const String _VersionName = "Version";
        const String _CountName = "Count";
        const String _ValuesName = "Data";
       

        public void LinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            foreach (T item in collection)
            {
                AddLast(item);
            }
        }
        public int Count
        {
            get { return _count; }
        }
        public _LinkedListNode<T> First
        {
            get { return _head; }
        }
        public _LinkedListNode<T> Last
        {
            get { return _head == null ? null : _head._prev; }
        }
        public _LinkedListNode<T> AddAfter(_LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            _LinkedListNode<T> result = new _LinkedListNode<T>(node._list, value);
            InternalInsertNodeBefore(node._next, result);
            return result;
        }
        public void AddAfter(_LinkedListNode<T> node, _LinkedListNode<T> newNode)
        {
            ValidateNode(node);
            ValidateNewNode(newNode);
            InternalInsertNodeBefore(node._next, newNode);
            newNode._list = this;
        }
        public _LinkedListNode<T> AddBefore(_LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            _LinkedListNode<T> result = new _LinkedListNode<T>(node._list, value);
            InternalInsertNodeBefore(node, result);
            if (node == _head)
            {
                _head = result;
            }
            return result;
        }
        public void AddBefore(_LinkedListNode<T> node, _LinkedListNode<T> newNode)
        {
            ValidateNode(node);
            ValidateNewNode(newNode);
            InternalInsertNodeBefore(node, newNode);
            newNode._list = this;
            if (node == _head)
            {
                _head = newNode;
            }
        }
        public _LinkedListNode<T> AddFirst(T value)
        {
            _LinkedListNode<T> result = new _LinkedListNode<T>(this, value);
            if (_head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(_head, result);
                _head = result;
            }
            return result;
        }
        public void AddFirst(_LinkedListNode<T> node)
        {
            ValidateNewNode(node);

            if (_head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(_head, node);
                _head = node;
            }
            node._list = this;
        }

        public _LinkedListNode<T> AddLast(T value)
        {
            _LinkedListNode<T> result = new _LinkedListNode<T>(this, value);
            if (_head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(_head, result);
            }
            return result;
        }
        public void AddLast(_LinkedListNode<T> node)
        {
            ValidateNewNode(node);

            if (_head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(_head, node);
            }
            node._list = this;
        }
        public void RemoveFirst()
        {
            if (_head == null) { throw new InvalidOperationException(); }
            InternalRemoveNode(_head);
        }

        public void RemoveLast()
        {
            if (_head == null) { throw new InvalidOperationException(); }
            InternalRemoveNode(_head._prev);
        }
        public void Clear()
        {
            _LinkedListNode<T> current = _head;
            while (current != null)
            {
                _LinkedListNode<T> temp = current;
                current = current._Next;   
                temp.Invalidate();
            }

            _head = null;
            _count = 0;
            _version++;
        }
        private void InternalInsertNodeToEmptyList(_LinkedListNode<T> newNode)
        {
            newNode._next = newNode;
            newNode._prev = newNode;
            _head = newNode;
            _version++;
            _count++;
        }
        private void InternalInsertNodeBefore(_LinkedListNode<T> node, _LinkedListNode<T> newNode)
        {
            newNode._next = node;
            newNode._prev = node._prev;
            node._prev._next = newNode;
            node._prev = newNode;
            _version++;
            _count++;
        }
        internal void InternalRemoveNode(_LinkedListNode<T> node)
        {
           
            if (node._next == node)
            {
                _head = null;
            }
            else
            {
                node._next._prev = node._prev;
                node._prev._next = node._next;
                if (_head == node)
                {
                    _head = node._next;
                }
            }
            node.Invalidate();
            _count--;
            _version++;
        }
        internal void ValidateNewNode(_LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (node._list != null)
            {
                throw new InvalidOperationException();
            }
        }
        internal void ValidateNode(_LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (node._list != this)
            {
                throw new InvalidOperationException();
            }
        }
        
    }
    public sealed class _LinkedListNode<T>
    {
        internal _LinkedList<T> _list;
        internal _LinkedListNode<T> _next;
        internal _LinkedListNode<T> _prev;
        T _item;
        public _LinkedListNode(T value)
        {
            _item = value;
        }
        internal _LinkedListNode(_LinkedList<T> list, T item)
        {
            _list = list;
            _item = item;
        }
        public _LinkedList<T> _List
        {
            get
            {
                return _list;
            }
        }
        public _LinkedListNode<T> _Next
        {
            get { return _next == null || _next==_list._head ? null : _next; }
        }
        public _LinkedListNode<T> _Previous
        {
            get { return _prev == null || this == _list._head ? null : _prev; }
        }
        public T Value
        {
            get { return _item; }
            set { _item = value; }
        }
        internal void Invalidate()
        {
            _list = null;
            _next = null;
            _prev = null;
        }

    }
}
