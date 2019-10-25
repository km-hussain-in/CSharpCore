using System;

namespace DemoApp
{
    class Program
    {
        static void PrintStack(IStackReader<object> stack)
        {
            for(int i = 0; !stack.Empty(); ++i)
            {
                if(i > 0) Console.Write(", ");
                Console.Write(stack.Pop());
            }            
            Console.WriteLine();
        }

        static V Greatest<V>(IStackCopier<V> stack) where V : IComparable<V>
        {
            var temp = new LinkedStack<V>();
            stack.Copy(temp);
            V max = temp.Pop();
            while(!temp.Empty())
            {
                V val = temp.Pop();
                if(val.CompareTo(max) > 0) max = val;
            }
            return max;
        }

        static void Main(string[] args)
        {
            var a = new FiniteStack<string>(5);
            a.Push("Monday");
            a.Push("Tuesday");
            a.Push("Wednesday");
            a.Push("Thursday");
            a.Push("Friday");
            var b = new LinkedStack<string>();
            b.Push("June");
            b.Push("May");
            b.Push("April");
            b.Push("March");
            var c = new FiniteStack<Interval>(5);
            c.Push(new Interval(4, 31));
            c.Push(new Interval(3, 42));
            c.Push(new Interval(6, 13));
            c.Push(new Interval(7, 24));
            c.Push(new Interval(5, 55));
            var d = new LinkedStack<Object>();
            d.Push(34.56);
            d.Push(new Interval(2, 30));
            d.Push("Sunday"); 
            c.Copy(d);
            string ga = Greatest(a);
            Interval gc = Greatest(c);
            PrintStack(a);
            PrintStack(b);
            PrintStack(c);
            PrintStack(d);
            Console.WriteLine("Greatest value in first stack = {0}", ga);
            Console.WriteLine("Greatest value in third stack = {0}", gc);
        }
    }
}
