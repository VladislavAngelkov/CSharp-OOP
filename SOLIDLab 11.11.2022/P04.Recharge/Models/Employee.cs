namespace P04.Recharge.Models
{
    using System;
    using P04.Recharge.Models.Innterfaces;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }



    }
}
