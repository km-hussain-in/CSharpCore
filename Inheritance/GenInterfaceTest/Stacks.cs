namespace GenInterfaceTest
{
    interface IStackReader<out V>
    {
        bool Empty();
        V Pop();
    }

    interface IStackWriter<in V>
    {
        void Push(V value);
    }

    class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
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

        public void Copy(IStackWriter<V> target)
        {
            for (Node n = top; n != null; n = n.below)
                target.Push(n.value);
        }
    }

    class FiniteStack<V> : IStackReader<V>, IStackWriter<V>
    {
        private V[] values;
        private int count;

        public FiniteStack(int size)
        {
            values = new V[size];
        }

        public void Push(V value)
        {
            values[count++] = value;
        }

        public V Pop()
        {
            return values[--count];
        }

        public bool Empty()
        {
            return count == 0;
        }
    }

}