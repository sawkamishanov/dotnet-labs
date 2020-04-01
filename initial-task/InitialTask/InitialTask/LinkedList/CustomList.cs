using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InitialTask.LinkedList
{
    public class CustomList<T> : IEnumerable<T>
    {
        private Node<T> Head;
        private Node<T> Tail;
        private int Size;

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data) {Next = Head};
            Head = node;
            if (Size == 0) 
                Tail = Head;
            ++Size;   
        }

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
            if (Head == null)
                Head = node;
            else
                Tail.Next = node;
            Tail = node;
            ++Size;
        }

        public bool Remove(T data)
        {
            Node<T> current = Head;
            Node<T> previous = null;
 
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;
                        if (Head == null)
                            Tail = null;
                    }
                    --Size;
                    return true;
                }
 
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Reverse()
        {
            Node<T> previous = null, current = Head, next = null; 
            while (current != null) { 
                next = current.Next; 
                current.Next = previous; 
                previous = current; 
                current = next; 
            } 
            Head = previous; 
        }
        
        public T Get(int index)
        {
            if (index >= Size || index < 0) throw new ArgumentOutOfRangeException();
            else
            {
                Node<T> current = Head;
                for (int i = 0; i < index; ++i)
                {
                    current = current.Next;
                }

                return current.Data;
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public int GetSize => Size;

        public bool IsEmpty => Size == 0;

        public override string ToString()
        {
            string result = "";
            foreach (var node in this)
            {
                result += $"{node} ";
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}