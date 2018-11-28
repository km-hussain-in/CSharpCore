namespace LinqTest
{
    class Interval : System.IComparable<Interval>
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

        public override int GetHashCode()
        {
            return Time;
        }

        public override bool Equals(object other)
        {
            if (other is Interval that)
            {
               return (this.min == that.min) && (this.sec == that.sec);
            }

            return false;
        }

        public static bool operator ==(Interval lhs, Interval rhs)
        {
            return lhs.GetHashCode() == rhs.GetHashCode() && lhs.Equals(rhs);
        }

        public static bool operator !=(Interval lhs, Interval rhs) => !(lhs == rhs);

        public int CompareTo(Interval that)
        {
            return this.Time - that.Time;
        }
    }

}
