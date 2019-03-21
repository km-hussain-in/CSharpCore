namespace DemoApp
{
    
	class Interval 
    {
        int min, sec;

        public Interval(int minutes, int seconds)
        {
            min = minutes + seconds / 60;
            sec = seconds % 60;
        }

        public int Minutes => min;

        public int Seconds => sec;

        public int Time => 60 * min + sec;

        public override string ToString()
        {
            return $"{min}:{sec:00}";
        }

        public override int GetHashCode() => sec + min << 6;

        public override bool Equals(object other)
        {
            if(other is Interval that)
                return (this.min == that.min) && (this.sec == that.sec);
            return false;
        }

        public static Interval operator+(Interval lhs, Interval rhs)
        {
            return new Interval(lhs.min + rhs.min, lhs.sec + rhs.sec);
        }
    }
}
