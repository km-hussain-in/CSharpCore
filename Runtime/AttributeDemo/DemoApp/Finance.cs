using System;

namespace DemoApp
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MaxDurationAttribute : Attribute
    {
        public int Limit {get;}

        public MaxDurationAttribute(int value) => Limit = value;

        public MaxDurationAttribute() : this(5) {}
    }

    [MaxDuration(4)]
    public class EducationLoan
    {
        public float GetInterestRate(double amount) => 2.5f;
    }

    public class HomeLoan
    {
        public float GetInterestRate(double amount) => amount < 100000 ? 3.0f : 3.5f;
    }    

    [MaxDuration]
    public class PersonalLoan
    {
        public float GetInterestRate(double amount) => 4.0f + 0.1f * ((int) amount / 10000);
    }        

}