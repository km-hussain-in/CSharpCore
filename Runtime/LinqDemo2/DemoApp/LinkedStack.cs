using System.Collections;
using System.Collections.Generic;

namespace DemoApp
{
    public class LinkedStack<V> : IEnumerable<V>
    {
        class Node
        {
            internal V Value;
            internal Node Below;
        }

        Node top;

        public void Push(V value) => top = new Node{Value = value, Below = top};

        public void Add(V value) => Push(value);

        public V Pop()
        {
            Node n = top;
            top = top.Below;
            return n.Value;
        }

        public bool Empty() => top == null;

        public IEnumerator<V> GetEnumerator()
        {
            for(Node n = top; n != null; n = n.Below)
            yield return n.Value;
	    }

        IEnumerator IEnumerable.GetEnumerator()
        { 
            return GetEnumerator();
        }
    }
}
