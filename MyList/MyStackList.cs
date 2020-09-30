using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList
{

    public class MyStackList<T> : IEnumerable<T> where T : class
    {
        public Node<T> head;
        public int count;

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Unknown index");
                int i = 0;
                T result = default;
                foreach (var item in this)
                {
                    if (i == index)
                    {
                        result = item;
                        break;
                    }
                    i++;
                }
                return result;
            }
        }

        public delegate bool FilterHandler(T item);

        FilterHandler filterHandler = TrueFunc;
        public static bool TrueFunc(T item)
            {
                return true; //some logic
            }


        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
            if (filterHandler(item))
            {
                Node<T> node = new Node<T>(item);
                node.Next = head;
                head = node;
                count++;
            }
        }

        public delegate void RemoveNodeHandler(T item);
        public event RemoveNodeHandler AddToRemoveList;
        

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is emplty");
            Node<T> previous = head;
            head = head.Next;
            count--;
            AddToRemoveList?.Invoke(previous.Data);
            return previous.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return head.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
