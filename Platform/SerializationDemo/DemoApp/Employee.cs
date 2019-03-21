using System;

namespace DemoApp
{
    [Serializable]
    public class Employee
    {
        [NonSerialized]
        private long sid = -1;

        public string Name {get; set;}

        public short Hours {get; set;}

        public float Rate {get; set;}

        public virtual double GetIncome() => Hours * Rate;

        public long GetSessionId()
        {
            if(sid == -1)
                sid = DateTime.Now.Ticks;
            return sid;
        }
    }
}
