using System;

namespace DemoApp
{
    static class Worker
    {
        public static void DoWork(int amount)
        {
           for(int t = Environment.TickCount + 100 * amount; t > Environment.TickCount;);
        }

    }
}
