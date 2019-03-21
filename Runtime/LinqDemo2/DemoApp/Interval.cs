namespace DemoApp
{
    
	partial class Interval : System.IComparable<Interval>
    {
        int min, sec;

        partial void OnCreate();

        public Interval(int minutes, int seconds)
        {
            min = minutes + seconds / 60;
            sec = seconds % 60;
            OnCreate();
        }

        public void Deconstruct(out int minutes, out int seconds)
        {
            minutes = min;
            seconds = sec;
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

        public int CompareTo(Interval that)
        {
            return this.Time - that.Time;
        }
    }
}
