using EmployeeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PayRollClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PayRoll : Page
    {
        List<Employee> employees;

        public PayRoll()
        {
            this.InitializeComponent();
        }

        //come through this page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is List<Employee> empList)
            {
                employees = (List<Employee>)empList.OrderBy(emp => emp.GetType().Name).ToList();

                //initialize with today's datetime
                ShowPayRoll(System.DateTime.Now);
            }
        }


        //if date changed show pay roll by selected date
        private void dtpPayPeriod_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            DateTime date = dtpPayPeriod.Date.DateTime;

            ShowPayRoll(date);
        }

        private void btnBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        //method that search and count payrolls by their type etc.

        public void ShowPayRoll(DateTime date)
        {
            int count = 0;
            decimal gross = 0;
            decimal bonus = 0;
            decimal deduction = 0;

            List<Employee> empSalary = (List<Employee>)employees.Where(empSal => empSal is Salary).ToList();
            PayRoll<Employee> payrollSal = new PayRoll<Employee>(date, empSalary);
            var resultSal = payrollSal.ProcessPayRoll();
            lvwSalary.ItemsSource = resultSal;


            List<Employee> empHourly = (List<Employee>)employees.Where(empHour => empHour is Hourly).ToList();
            PayRoll<Employee> payrollHour = new PayRoll<Employee>(date, empHourly);
            var resultHour = payrollHour.ProcessPayRoll();
            lvwHourly.ItemsSource = resultHour;

            List<Employee> empTraining = (List<Employee>)employees.Where(empTrain => empTrain is Training).ToList();
            PayRoll<Employee> payrollTrain = new PayRoll<Employee>(date, empTraining);
            var resultTrain = payrollTrain.ProcessPayRoll();
            lvwTraining.ItemsSource = resultTrain;

            count = resultSal.Count + resultHour.Count + resultTrain.Count;
            gross = payrollSal.TotalPay + payrollHour.TotalPay + payrollTrain.TotalPay;
            bonus = payrollSal.TotalBonus + payrollHour.TotalBonus + payrollTrain.TotalBonus;

            //deduction
            decimal salDeduction = payrollSal.TotalIncomeTax + payrollSal.TotalPension + payrollSal.TotalUnion + payrollSal.TotalInsurance;
            decimal hourDeduction = payrollHour.TotalIncomeTax + payrollHour.TotalPension + payrollHour.TotalUnion + payrollHour.TotalInsurance;
            decimal trainDeduction = payrollTrain.TotalIncomeTax + payrollTrain.TotalPension + payrollTrain.TotalUnion + payrollTrain.TotalInsurance;

            deduction = salDeduction + hourDeduction + trainDeduction;

            txtTotalEmployee.Text = count.ToString();
            txtTotalGross.Text = gross.ToString("C2");
            txtTotalBonus.Text = bonus.ToString("C2");
            txtTotalDeduction.Text = deduction.ToString("C2");

        }
    }
}
