namespace GenClassTest
{
    class SimpleStack<V>
    {
        public class Node
        {
            public V value;
            public Node below;

            public Node(V v, Node n)
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

        public Enumerator GetEnumerator()
        {
            return new Enumerator(top);
        }

        //nested class
        public class Enumerator
        {
            private Node next;

            public Enumerator(Node begin)
            {
                next = begin;
            }

            public bool MoveNext()
            {
                return next != null;
            }

            public V Current
            {
                get
                {
                    Node node = next;
                    next = next.below;
                    return node.value;
                }
            }

        }

    }

}