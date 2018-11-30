namespace ExpressionTreeTest
{
    struct Interval
    {
        private int min, sec;

        public Interval(int m, int s)
        {
            min = m + s / 60;
            sec = s % 60;
        }

        public int Minutes
        {
            get { return min; }
        }

        public int Seconds
        {
            get { return sec; }
        }

        public int Time
        {
            get { return 60 * min + sec; }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1:00}", min, sec);
        }

	public static Interval operator+(Interval lhs, Interval rhs) => new Interval(lhs.min + rhs.min, lhs.sec + rhs.sec);

    }
}