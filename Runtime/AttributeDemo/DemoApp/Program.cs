using System;
using System.Reflection;

namespace DemoApp
{
    static class LateBindingHelper
    {
        public static object CallByName(this object target, string method, params object[] arguments)
        {
            Type t = target.GetType();
            return t.InvokeMember(method, BindingFlags.InvokeMethod, null, target, arguments);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double p = double.Parse(args[0]);
                Type t = args.Length > 1 ? Type.GetType(args[1], true) : typeof(PersonalLoan);
                object scheme = Activator.CreateInstance(t);
                float rate = (float)scheme.CallByName("GetInterestRate", p);
                var md = (MaxDurationAttribute)Attribute.GetCustomAttribute(t, typeof(MaxDurationAttribute));
                int m = md != null ? md.Limit : 10;
                for(int n = 1; n <= m; ++n)
                {
                    float i = rate / 1200;
                    double mi = p * i / (1 - Math.Pow(1 + i, -12 * n));
                    Console.WriteLine("{0, -6}{1, 12:0.00}", n, mi);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
