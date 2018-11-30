using System;
using System.Linq.Expressions;

namespace ExpressionTreeTest
{
    class Operators<T>
    {
        public static readonly Func<T, T, T> Add = MakeAddOperation();

        private static Func<T, T, T> MakeAddOperation()
        {
            ParameterExpression first = Expression.Parameter(typeof(T), "first");
            ParameterExpression second = Expression.Parameter(typeof(T), "second");
            BinaryExpression op = Expression.Add(first, second);

            return Expression.Lambda<Func<T, T, T>>(op, first, second).Compile();
        }
    }

    class Support
    {
        private static V Sum<V>(V first, params V[] values)
        {
            V total = first;

            foreach (V value in values)
                total = Operators<V>.Add(total, value);

            return total;
        }

        public void Run(string[] args)
        {
            double sd = Sum(1.1, 2.3, 3.5, 4.7);
            Console.WriteLine("Sum of doubles = {0}", sd);

            Interval si = Sum(new Interval(2, 20), new Interval(3, 30), new Interval(4, 40));
            Console.WriteLine("Sum of Intervals = {0}", si);
        }
    }
}
