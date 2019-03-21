namespace DemoApp
{

    public interface IStackReader<out V>
    {
        V Pop();
        bool Empty();
    }

    public interface IStackWriter<in V>
    {
        void Push(V value);
    }

    public interface IStackCopier<out V>
    {
        void Copy(IStackWriter<V> target);            
    }

    public class FiniteStack<V> : IStackReader<V>, IStackWriter<V>, IStackCopier<V>
    {
        V[] values;
        int count;

        public FiniteStack(int size)
        {
            values = new V[size];
        }

        public void Push(V value) => values[count++] = value;

        public V Pop() => values[--count];

        public bool Empty() => count == 0;

        public void Copy(IStackWriter<V> target)
        {
            for(int i = 0; i < count; ++i)
                target.Push(values[i]);
        }
    }

    public class LinkedStack<V> : IStackReader<V>, IStackWriter<V>
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
    }
}
