using System;

namespace Banking
{
    public static class Banker
    {
        private static long nextId;

        static Banker()
        {
            nextId = DateTime.Now.Ticks % 100000000L;
        }

        public static Account OpenBusinessAccount()
        {
            var acc = new BusinessAccount();
            acc.Id = 1000000000L + nextId++;
            return acc;
        }

        public static Account OpenPersonalAccount()
        {
            var acc = new PersonalAccount();
            acc.Id = 2000000000L + nextId++;
            return acc;
        }

    }
}