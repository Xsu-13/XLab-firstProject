using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyCollections
{
    public class Node<T>
    {
        public T value;
        public Node<T> next;
        public Node<T> prev;

        public Node(T value, Node<T> prev, Node<T> next)
        {
            this.value = value;
            this.next = next;
            this.prev = prev;
        }

        public bool Compare(T newVal)
        {
            return value.GetHashCode() == newVal.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    public class ListEnum<T> : IEnumerator<Node<T>>
    {
        Node<T> head;
        Node<T> node;
        public ListEnum(Node<T> n)
        {
            head = n;
            node = null;
        }

        public Node<T> Current
        {
            get
            {
                return node;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (node == null)
                node = head;
            else
                node = node.next;
            return node != null;
        }

        public void Reset()
        {
            node = head;
        }

        public void Dispose()
        {

        }
    }

    public class MyLinkedList<T> : IEnumerable
    {
        Node<T> head;
        Node<T> tail;
        Node<T> currentNode;
        public int Count { get; private set; }

        

        public MyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        
        public void AddLast(T value)
        {
            if(head == null)
            {
                head = new Node<T>(value, null, tail);
                tail = head;
            }
            else if(head == tail)
            {
                tail = new Node<T>(value, head, null);
                head.next = tail;
            }
            else
            {
                var newNode = new Node<T>(value, tail, null);
                tail.next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void AddLast(IEnumerable<T> values)
        {
            foreach (var val in values)
                AddLast(val);
        }

        public void AddAfter(T compareValue, T value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if(currentNode.Compare(compareValue))
                {
                    Node<T> newNode = new(value, currentNode, currentNode.next);

                    if (currentNode.next != null)
                    {
                        currentNode.next.prev = newNode;
                    }
                    else
                    {
                        tail = newNode;
                    }
                    currentNode.next = newNode;
                    Count++;
                }
                currentNode = currentNode.next;
            }
        }

        public void AddBefore(T compareValue, T value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Compare(compareValue))
                {
                    Node<T> newNode = new(value, currentNode.prev, currentNode);
                    if (currentNode.prev != null)
                    {
                        currentNode.prev.next = newNode;
                    }
                    else
                    {
                        head = newNode;
                    }
                    currentNode.prev = newNode;
                    Count++;
                }
                currentNode = currentNode.next;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void RemoveValues(T value)
        {
            if (Count == 0)
                return;

            var currentNode = head;
            while (currentNode != null)
            {
                if(currentNode.Compare(value))
                {
                    var prev = currentNode.prev;
                    prev.next = currentNode.next;
                    currentNode.next.prev = prev;
                    Count--;
                }
                currentNode = currentNode.next;
            }
        }

        public bool Contains(T value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Compare(value))
                {
                    return true;
                }
                currentNode = currentNode.next;
            }
            return false;
        }

        public Node<T> Find(T value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Compare(value))
                {
                    return currentNode;
                }
                currentNode = currentNode.next;
            }
            return null;
        }

        public override string ToString()
        {
            if (Count == 0)
                return "List is empty";

            string result = "";

            var currentNode = head;
            while (currentNode != null)
            {
                result += $" {currentNode} ";
                currentNode = currentNode.next;
            }

            return "List: " + result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public ListEnum<T> GetEnumerator()
        {
            return new ListEnum<T>(head);
        }
    }

    
}

