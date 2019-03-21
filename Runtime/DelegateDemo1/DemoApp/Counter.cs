namespace DemoApp
{
    public delegate bool Filter(int value);

    public static class Counter
    {
        public static int Count(int[] values, Filter allowed)
        {
            int count = 0;
            foreach(int value in values)
            {
                if(allowed(value))
                    count += 1;
            }
            return count;
        }
    }
}