using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

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

        public FilterHandler filterHandler = TrueFunc;
        public static bool TrueFunc(T item)  //some logic
            {
            Thread.Sleep(500);
            Random random = new Random();
            if (random.Next(0, 100) < 50)
            {
                return false;
            }
            return true;
            
        }

        public static MyStackList<T> filter(MyStackList<T>list, FilterHandler filterhandler)
        {
            var filtered = new MyStackList<T>();
            foreach(var item in list)
            {
                if (list.filterHandler(item))
                {
                    filtered.Push(item);
                }
            }
            return filtered;
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
                Node<T> node = new Node<T>(item);
                node.Next = head;
                head = node;
                count++;
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
