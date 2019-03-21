using System;
using System.Threading.Tasks;

namespace DemoApp
{

    public class Computation
    {
        public int Calculations {get; private set;}

        private static long Calculate(int value)
        {
            for(int t = Environment.TickCount + 100 * value; t > Environment.TickCount;);
            return value * value;
        }

        public long Compute(int first, int last)
        {
            long result = 0;
            lock(this)
            {
                int count = Calculations;
                for (int value = first; value <= last; ++value, ++count)
                    result += Calculate(value);
                Calculations = count;
            }
            return result;
        }

        public Task<long> ComputeAsync(int first, int last)
        {
            return Task<long>.Run(() => Compute(first, last));
        }
    }
}