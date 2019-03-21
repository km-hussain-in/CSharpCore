using System;
using System.Threading;

namespace DemoApp
{
    class Pipe<V>
    {
        private V value;
        private bool available;
 
        public V Read()
        {
            Monitor.Enter(this);
            try
            {
                while(!available)
                    Monitor.Wait(this);
                available = false;
                Monitor.Pulse(this);
                return value;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public void Write(V data)
        {
            lock(this)
            {
                while(available)
                    Monitor.Wait(this);
                value = data;
                available = true;
                Monitor.Pulse(this);
            }
        }

    }

    class Program
    {
        static Pipe<int> tube = new Pipe<int>();

        static void Produce()
        {
            Console.WriteLine("Producer<{0}> ready...", Thread.CurrentThread.ManagedThreadId);
            for(int val = 5; val >= 0; val--)
            {
                Worker.DoWork(val);
                tube.Write(val);
            }
        }

        static void Consume()
        {
            Console.WriteLine("Consumer<{0}> ready...", Thread.CurrentThread.ManagedThreadId);
            int val;
            while((val = tube.Read()) != 0)
            {
                Worker.DoWork(val);
                Console.WriteLine("Consumer processed value = {0}", val * val);
            }
        }

        static void Main(string[] args)
        {
            var producer = new Thread(Produce);
            producer.Start();
            var consumer = new Thread(Consume);
            consumer.Start();
            consumer.Join();
            producer.Join();
            Console.WriteLine("Done!");
        }
    }
}
