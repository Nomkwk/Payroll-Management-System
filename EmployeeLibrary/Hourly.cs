using System;

namespace EmployeeLibrary
{
    public sealed class Hourly : Employee
    {
        private decimal rate;
        private decimal hours;

        public decimal Rate
        {
            get => rate;
            set => rate = value;
        }

        public decimal Hours
        {
            get => hours;
            set => hours = value;
        }

        //2 more constructor from base class
        public Hourly(string sin) : base(sin)
        {

        }

        public Hourly(string sin, string first, string last) : base(sin, first, last)
        {

        }

        public Hourly(string sin, string first, string last, decimal rate, decimal hours) : base(sin, first, last)
        {
            Rate = rate;
            Hours = hours;
        }

        public Hourly(string sin, string first, string last, DateTime hire, DateTime birth, string email, string phone, Address address, bool status) : base(sin, first, last, hire, birth, email, phone, address, status)
        {

        }

        public Hourly(string sin, string first, string last, DateTime hire, DateTime birth, string email, string phone, Address address, bool status, decimal rate, decimal hours) : base(sin, first, last, hire, birth, email, phone, address, status)
        {
            Rate = rate;
            Hours = hours;
        }
        public override string ToString()
        {
            return "Hourly:" + base.ToString();
        }

        public override decimal Bonus()
        {
            return 0;
        }

        public override decimal CalculatePay()
        {
            return Rate * Hours;
        }

        public override decimal IncomeTax()
        {
            return base.IncomeTax();
        }
        //11. Pension is 3% of salary
        public override decimal Pension()
        {
            return CalculatePay() * 0.03m;
        }
        //Union dues is $10 per biweek
        public override decimal UnionDues()
        {
            return 10;
        }
        //insurance is $12.5 per biweek
        public override decimal Insurance()
        {
            return 12.50m;
        }
    }
}

