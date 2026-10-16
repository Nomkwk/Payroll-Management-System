using System;

namespace EmployeeLibrary
{
    public struct Address
    {
        //4. struct class with properties

        private string street;
        private string city;
        private string province;
        private string postalCode;

        public string Street
        {
            get { return street; }
            set
            {
                if (value == "")
                {
                    throw new Exception("Street can't be empty");
                }
                street = value;
            }
        }

        public string City
        {
            get => city;
            set
            {
                if (value == "")
                {
                    throw new Exception("City can't be empty");
                }
                city = value;
            }
        }

        public string Province
        {
            get => province;
            set
            {
                if (value == "")
                {
                    throw new Exception("Province can't be empty");
                }
                province = value;
            }
        }

        public string PostalCode
        {
            get => postalCode;
            set
            {
                if (value.Trim().Length == 6)
                {
                    postalCode = value;
                }
                else if (value == "")
                {
                    throw new Exception("Postal code can't be empty");
                }
                else
                {
                    throw new Exception("Postal code is not in right length");
                }
            }
        }

        //one constructor with parameters for all field
        public Address(string street, string city, string province, string postalCode)
        {
            if (street == "" || city == "" || province == "" || postalCode == "")
            {
                throw new Exception("Please fill all address infos");
            }
            else
            {
                if (street == "")
                {
                    throw new Exception("Street can't be empty");
                }
                this.street = street;

                if (city == "")
                {
                    throw new Exception("City can't be empty");
                }
                this.city = city;

                if (province == "")
                {
                    throw new Exception("Province can't be empty");
                }
                this.province = province;

                if (postalCode.Trim().Length == 6)
                {
                    this.postalCode = postalCode;
                }
                else if (postalCode == "")
                {
                    throw new Exception("Postal code can't be empty");
                }
                else
                {
                    throw new Exception("Postal code is not in right length");
                }
            }
        }

        public override string ToString()
        {
            return ($"Address: {street}, {city}, {province} ({postalCode})");
        }


    }
}

