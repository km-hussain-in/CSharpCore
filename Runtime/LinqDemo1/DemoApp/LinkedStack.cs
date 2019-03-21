using System;

namespace DemoApp
{
    public class LinkedStack<V>
    {
        class Node
        {
            internal V Value;
            internal Node Below;
        }

        Node top;

        public void Push(V value) => top = new Node{Value = value, Below = top};

        public V Pop()
        {
            Node n = top;
            top = top.Below;
            return n.Value;
        }

        public bool Empty() => top == null;

        public void Peek(Action<V> watch)
        {
            for(Node n = top; n != null; n = n.Below) 
                watch(n.Value);           
        }
    }
}
