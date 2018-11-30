using System;
using System.Reflection.Emit;

namespace DynamicMethodTest
{
    class Operators<T>
    {
        public static readonly Func<T, T, T> Add = MakeAddOperation();

        private static Func<T, T, T> MakeAddOperation()
        {
            return MakeBinaryOperation(OpCodes.Add, "op_Addition");
        }

        private static Func<T, T, T> MakeBinaryOperation(OpCode code, string name)
        {
            Type t = typeof(T);
            Type[] signature = { t, t };
            DynamicMethod dm = new DynamicMethod(name, t, signature, typeof(Operators<T>));
            ILGenerator gen = dm.GetILGenerator();

            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldarg_1);
            if (t.IsPrimitive)
                gen.Emit(code);
            else
                gen.EmitCall(OpCodes.Call, t.GetMethod(name, signature), null);
            gen.Emit(OpCodes.Ret);

            return (Func<T, T, T>)dm.CreateDelegate(typeof(Func<T, T, T>));
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
