using System;

namespace ThreadingTest
{
    static class DemoApp
    {
        public static void DoWork(int amount)
        {
           for(int t = Environment.TickCount + 100 * amount; t > Environment.TickCount;);
        }

    }
}
