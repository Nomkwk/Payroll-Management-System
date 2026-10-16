using System;

namespace EmployeeLibrary
{
    public class Salary : Employee
    {

        private decimal amount;

        public decimal Amount
        {
            get => amount;
            set => amount = value;
        }

        //2 more constructor from base class
        public Salary(string sin) : base(sin)
        {

        }

        public Salary(string sin, string first, string last) : base(sin, first, last)
        {

        }

        public Salary(string sin, string first, string last, decimal amount) : base(sin, first, last)
        {
            Amount = amount;
        }

        public Salary(string sin, string first, string last, DateTime hire, DateTime birth, string email, string phone, Address address, bool status) : base(sin, first, last, hire, birth, email, phone, address, status)
        {

        }

        public Salary(string sin, string first, string last, DateTime hire, DateTime birth, string email, string phone, Address address, bool status, decimal amount) : base(sin, first, last, hire, birth, email, phone, address, status)
        {
            Amount = amount;
        }

        public override string ToString()
        {
            return "Salary:" + base.ToString();
        }

        public override decimal Bonus()
        {
            //8. get full year and multipy by 100 for bonus
            int year = DateTime.Now.Year - HireDate.Year;
            return year * 100;
        }

        public override decimal CalculatePay()
        {
            //pay period salary
            return amount / (365 / 14);
        }
        public override decimal IncomeTax()
        {
            return base.IncomeTax();
        }

        //pension is 5% of salary 
        //higher than hourly

        public override decimal Pension()
        {
            return CalculatePay() * 0.05m;
        }

        //union due is $10 for biweek same as hourly
        public override decimal UnionDues()
        {
            return 10;
        }

        //Insurance is $40 pretty high because of better benefits
        public override decimal Insurance()
        {
            return 40;
        }
    }
}

