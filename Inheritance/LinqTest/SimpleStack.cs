using System.Collections;
using System.Collections.Generic;

namespace LinqTest
{
    class SimpleStack<V> : IEnumerable<V>
    {
        class Node
        {
            internal V value;
            internal Node below;

            internal Node(V v, Node n)
            {
                value = v;
                below = n;
            }
        }

        private Node top;

        public void Push(V value)
        {
            top = new Node(value, top);
        }

        public V Pop()
        {
            Node n = top;
            top = top.below;
            return n.value;
        }

        public bool Empty()
        {
            return top == null;
        }

        public IEnumerator<V> GetEnumerator()
        {
            for (Node n = top; n != null; n = n.below)
                yield return n.value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
