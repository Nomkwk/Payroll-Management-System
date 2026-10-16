using EmployeeLibrary;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PayRollClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard : Page
    {
        List<Employee> employees;
        public Dashboard()
        {
            this.InitializeComponent();
        }

        //Initiliaze the page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is List<Employee> empList)
            {
                employees = empList;

                // 1.Total number of each employee type
                lblSalaryTotal.Text = employees.Count(emp => emp is Salary).ToString();
                lblHourlyTotal.Text = employees.Count(emp => emp is Hourly).ToString();
                lblTrainingTotal.Text = employees.Count(emp => emp is Training).ToString();

                // 2.Total Active Inactive
                txtActiveTotal.Text = employees.Count(emp => emp.Active).ToString();
                txtInactiveTotal.Text = employees.Count(emp => !emp.Active).ToString();

                // 3.Seniority
                var mostSenior = employees.OrderBy(emp => emp.HireDate).First();
                var leastSenior = employees.OrderByDescending(emp => emp.HireDate).First();

                txtMostSenior.Text = $"{mostSenior.FirstName} ({mostSenior.GetType().Name})\n{mostSenior.CalculatePay().ToString("C2")}";

                txtLeastSenior.Text = $"{leastSenior.FirstName} ({leastSenior.GetType().Name})\n{leastSenior.CalculatePay().ToString("C2")}";

                // 4.Highest paid 
                var highestPayEmp = employees.OrderBy(emp => -emp.CalculatePay()).First();

                if (highestPayEmp != null)
                {
                    txtHighestPay.Text = $"{highestPayEmp.FirstName} ({highestPayEmp.GetType().Name}) - {highestPayEmp.CalculatePay().ToString("C2")}";
                }

                // 5. Employee type with highest total pay
                var highestType = employees.GroupBy(emp => emp.GetType().Name).Select(group => new
                {
                    Type = group.Key,
                    TotalPay = group.Sum(emp => emp.CalculatePay())
                }).OrderBy(g => -g.TotalPay).First();

                txtUnique.Text = $"{highestType.Type} - {highestType.TotalPay.ToString("C2")}";

                // 6.Average pay
                txtAverage.Text = employees.Average(emp => emp.CalculatePay()).ToString("C2");

                // 7.Most common type
                var mostCommonType = employees.GroupBy(emp => emp.GetType().Name).OrderBy(g => -g.Count()).First();

                txtUnique.Text = $"Common: {mostCommonType.Key} ({mostCommonType.Count()})";

            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }



    }
}
