using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.CodeDom;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStackList<string> shoppingList = new MyStackList<string>();
            shoppingList.Push("Bread");
            shoppingList.Push("Butter");
            shoppingList.Push("Tea");
            shoppingList.Push("Coffee");
            shoppingList.Push("Sugar");

            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            string header = shoppingList.Peek();
            Console.WriteLine(header);

            Console.WriteLine();
            Console.WriteLine(shoppingList[3]);
        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public Node<T> Next { get; set; }
    }

    public class MyStackList<T> : IEnumerable<T>
    {
        Node<T> head;
        int count;

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new InvalidOperationException("Stack is empty");
                return (this.ToArray()[index]);
            }
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
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is emplty");
            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
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
