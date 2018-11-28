using System.Threading.Tasks;

namespace AsyncTaskTest
{
    class Computation
    {
        public long Compute(int low, int high)
        {
            long result = 0;

            for (int value = low; value <= high; ++value)
            {
                for (int t = Environment.TickCount + 100 * value; t > Environment.TickCount;) ;
                result += value * value;
            }

            return result;
        }

        public Task<long> ComputeAsync(int low, int high)
        {
            return Task<long>.Run(() => Compute(low, high));
        }
    }
}