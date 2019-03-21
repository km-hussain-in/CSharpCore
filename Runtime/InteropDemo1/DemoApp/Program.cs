using System;

namespace DemoApp
{
    class Program
    {
        static unsafe void FastSquareAll(float[] values)
        {
            fixed(float* accessor = &values[0])
            {
                for(int i = 0; i < values.Length; ++i)
                    accessor[i] *= accessor[i];
            }
        }

        static void Main(string[] args)
        {
            try
            {
                float l = float.Parse(args[0]);
                float b = float.Parse(args[1]);
                float h = float.Parse(args[2]);

                float[] list = {l, b, h};
                FastSquareAll(list);
                Console.WriteLine("Sum of squares = {0}", list[0] + list[1] + list[2]);

                using(var box = new NativeBoxWrapper(l, b, h))
                {
                    Console.WriteLine("Inner volume = {0:0.00}", box.GetInnerVolume(1));
                }
            }
            catch
            {
                Console.WriteLine("Usage: dotnet run length breadth height");
            }
        }
    }
}
