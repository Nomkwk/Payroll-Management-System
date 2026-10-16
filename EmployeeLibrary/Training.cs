using System;

namespace EmployeeLibrary
{
    public class Training : Employee
    {
        public delegate void CheckBonusDelegate();
        public event CheckBonusDelegate CheckBonusEvent;

        //one time pay for training period
        //static because it can be changed
        public static decimal amount = 100;
        private bool isPaid = false;
        private decimal trainBonus;
        public int Week
        {
            get => (DateTime.Now - base.HireDate).Days / 14;
        }

        public bool IsPaid
        {
            get => isPaid;
        }

        public decimal TrainBonus
        {
            get => trainBonus;
            set => trainBonus = value;
        }

        //2 more constructor from base class
        public Training(string sin) : base(sin)
        {

        }

        public Training(string sin, string first, string last) : base(sin, first, last)
        {

        }

        public Training(string sin, string first, string last, DateTime hire, DateTime birth, string email, string phone, Address address, bool status) : base(sin, first, last, hire, birth, email, phone, address, status)
        {

        }

        //Extra constructor
        public Training(string sin, string first, string last, DateTime hire, DateTime birth, string email, string phone, Address address, bool status, decimal bonus) : base(sin, first, last, hire, birth, email, phone, address, status)
        {
            TrainBonus = bonus;
        }

        //9. just simple one time pay
        public override decimal CalculatePay()
        {
            if (isPaid == false)
            {
                isPaid = true;
                return amount;
            }
            else
            {
                return 0;
            }
        }

        //give bonus if employee finish training less than 2 week
        public override decimal Bonus()
        {
            if (Week < 2 && this.CheckBonusEvent != null)
            {
                CheckBonusEvent();
                return TrainBonus;
            }
            else
            {
                return 0;
            }
        }

        public override decimal IncomeTax()
        {
            return base.IncomeTax();
        }

        //training doesn't have to pay pension and uniondues
        public override decimal Pension()
        {
            return 0;
        }
        public override decimal UnionDues()
        {
            return 0;
        }
        //pay $5 for insurance because of possible injuries
        public override decimal Insurance()
        {
            return 5;
        }

        public override string ToString()
        {
            return "Training:" + base.ToString(); ;
        }
    }
}
