using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeLibrary
{
    public class PayRoll<T> where T : Employee
    {

        private readonly DateTime payPeriod;
        private readonly List<T> currentEmployees;

        private readonly int totalEmployee;
        private decimal totalPay;
        private decimal totalBonus;
        private decimal totalIncomeTax;
        private decimal totalPension;
        private decimal totalUnion;
        private decimal totalInsurance;

        public DateTime PayPeriod
        {
            get { return payPeriod; }
        }

        public List<T> CurrentEmployees
        {
            get { return currentEmployees; }
        }

        //readonly properties
        public int TotalEmployee { get => totalEmployee; }
        public decimal TotalPay { get => totalPay; }
        public decimal TotalBonus { get => totalBonus; }
        public decimal TotalIncomeTax { get => totalIncomeTax; }
        public decimal TotalPension { get => totalPension; }
        public decimal TotalUnion { get => totalUnion; }
        public decimal TotalInsurance { get => totalInsurance; }


        public PayRoll(DateTime date, List<T> employees)
        {
            this.payPeriod = date;

            //get employees which hire date is before the payroll date
            currentEmployees = employees.Where(e => e.HireDate < date).ToList();

            totalEmployee = currentEmployees.Count;
        }

        //processPayRoll method
        public List<string> ProcessPayRoll()
        {
            List<string> result = new List<string>();

            var grouped = currentEmployees.GroupBy(e => e.GetType());

            foreach (var group in grouped)
            {
                foreach (var employee in group)
                {
                    {
                        //Salary and bonus
                        decimal grossEarning = employee.CalculatePay();
                        decimal bonus = employee.Bonus();

                        //deductions
                        decimal incomeTax = employee.IncomeTax();
                        decimal pension = employee.Pension();
                        decimal union = employee.UnionDues();
                        decimal insurance = employee.Insurance();
                        //total deduction
                        decimal deductions = incomeTax + pension + union + insurance;

                        //net
                        decimal net = grossEarning + bonus - deductions;

                        // accumulate totals
                        totalPay += grossEarning;
                        totalBonus += bonus;
                        totalIncomeTax += incomeTax;
                        totalPension += pension;
                        totalUnion += union;
                        totalInsurance += insurance;
                        result.Add($"({employee.GetType().Name}) {employee.Sin} {employee.FirstName} {employee.LastName} - Net: {net:N2} - Bonus: {bonus:N2} - Deductions: {deductions:N2}"
                );
                    }
                }

            }
            return result;
        }
    }
}
