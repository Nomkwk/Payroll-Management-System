using System;

namespace EmployeeLibrary
{
    public abstract class Employee : IDeduction
    {
        //Variables
        private string sin;
        private string first;
        private string last;
        private DateTime hire;
        private DateTime birth;
        private string email;
        private string phone;
        private Address address;
        private bool status;

        //Company name
        public static string COMPANY = "Lemon co.";

        //3. Properties --all validated

        //Sin has to be 9digits
        public string Sin
        {
            get => sin;
            set
            {
                if (value.Length != 9)
                {
                    throw new Exception("Sin number must have 9 digit");
                }
                else if (!long.TryParse(value, out long sin))
                {
                    throw new Exception("Sin number must have 9 digit");
                }
                this.sin = value;
            }
        }

        //first name cant be empty
        public string FirstName
        {
            get => first;
            set
            {
                if (value == "")
                {
                    throw new Exception("Please fill first name");
                }
                this.first = value;
            }
        }

        //last name can't be empty
        public string LastName
        {
            get => last;
            set
            {
                if (value == "")
                {
                    throw new Exception("Please fill last name");
                }
                this.last = value;
            }
        }

        //hire date can't be empty
        public DateTime HireDate
        {
            get => hire;
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new Exception("Please fill hire date");
                }
                this.hire = value;
            }
        }

        //birthdate can't be empty
        public DateTime BirthDate
        {
            get => birth;
            set
            {
                if (value.ToString() == "")
                {
                    throw new Exception("please fill birth date");
                }
                this.birth = value;
            }
        }

        //email is not required
        public string Email
        {
            get => email;
            set => email = value;
        }

        //phone number has to be 10 digits
        public string Phone
        {
            get => phone;
            set
            {
                if (value.Length != 10)
                {
                    throw new Exception("Phone number should have 10 digit");
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Phone number can't be empty");
                }
                else if (!long.TryParse(value, out long phone))
                {
                    throw new Exception("Sin number must have 9 digit");
                }
                else
                {
                    this.phone = value;
                }
            }
        }

        //address will sete by address class
        public Address Address
        {
            get => address;
            set
            {
                address = value;
            }
        }

        //active or not will get bool
        public bool Active
        {
            get => status;
            set
            {
                if (value != true && value != false)
                {
                    throw new Exception("Please fill status");
                }
                this.status = value;
            }
        }

        public Employee(string sin)
        {
            Sin = sin;
        }

        public Employee(string sin, string first, string last)
        {
            Sin = sin;
            FirstName = first;
            LastName = last;
        }

        public Employee(string sin, string first, string last, DateTime hire, DateTime birth, string email, string phone, Address address, bool status)
        {
            Sin = sin;
            FirstName = first;
            LastName = last;
            HireDate = hire;
            BirthDate = birth;
            Email = email;
            Phone = phone;
            Address = address;
            Active = status;
        }

        //5. base class to string methos return full name and phone

        public override string ToString()
        {
            return $" {FirstName} {LastName} \nPhone: ({Phone.Substring(0, 3)})-{Phone.Substring(3, 3)}-{Phone.Substring(6, 4)}\nHire Date: {HireDate.ToString("yyyy/MM/dd")}";
        }

        //bonus and calculate pay method 
        public virtual decimal Bonus()
        {
            return 0M;
        }

        public abstract decimal CalculatePay();

        //income tax is same for all
        public virtual decimal IncomeTax()
        {
            decimal salary = CalculatePay();
            if (salary <= 58523)
            {
                return salary * 0.14M;
            }
            else if (salary > 58523 && salary <= 117045)
            {
                return salary * 0.205M;
            }
            else if (salary > 117045 && salary <= 181440)
            {
                return salary * 0.26M;
            }
            else if (salary > 181440 && salary <= 258482)
            {
                return salary * 0.29m;
            }
            else
            {
                return salary * 0.33M;
            }
        }

        public virtual decimal Pension()
        {
            return 0;
        }

        public virtual decimal UnionDues()
        {
            return 0;
        }

        public virtual decimal Insurance()
        {
            return 0;
        }

    }
}

