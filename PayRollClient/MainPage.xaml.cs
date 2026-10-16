using EmployeeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PayRollClient
{
    public sealed partial class MainPage : Page
    {
        // Using a static list ensures the data persists across page navigations 
        // within the same session.
        static List<Employee> employees = Data.GetSampleEmployees();

        public MainPage()
        {
            this.InitializeComponent();
            lvwEmployees.ItemsSource = employees;
            rdbAll.IsChecked = true;
        }

        //new employee from new employee
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Employee newEmp)
            {
                employees.Add(newEmp);
            }

            //Initialize the page
            Event_Refresh(null, null);
        }


        //see profile button
        private void btnProfile_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //goes to profile
            var button = sender as Button;
            var emp = button?.CommandParameter as Employee;

            if (emp != null)
            {
                this.Frame.Navigate(typeof(Profile), emp);
            }
        }

        //this is where the page refresh by filters
        //it used as text changed event
        private void Event_Refresh(object sender, object e)
        {
            //because if data is null it doesn't have to calculate
            if (employees == null) return;

            //ienumerable so i can use linq
            IEnumerable<Employee> employeesFilter = employees.OrderBy(emp => emp.FirstName);

            //get employees which is chosen in radio button
            //if not chosen then not doing anything
            if (rdbTraining.IsChecked == true)
            {
                employeesFilter = employeesFilter.Where(emp => emp is Training);
            }
            else if (rdbHourly.IsChecked == true)
            {
                employeesFilter = employeesFilter.Where(emp => emp is Hourly);
            }
            else if (rdbSalary.IsChecked == true)
            {
                employeesFilter = employeesFilter.Where(emp => emp is Salary);
            }

            string name = txtNameSearch.Text;
            string phone = txtPhoneSearch.Text;

            //check if null
            //if not null then filter
            if (!string.IsNullOrWhiteSpace(name))
            {
                employeesFilter = employeesFilter.Where(emp => emp.FirstName.ToLower().Contains(name.ToLower()) || emp.LastName.ToLower().Contains(name.ToLower()) || (emp.FirstName + " " + emp.LastName).ToLower().Contains(name.ToLower()));
            }
            //phone
            if (!string.IsNullOrWhiteSpace(phone))
            {
                employeesFilter = employeesFilter.Where(emp => emp.Phone.Contains(phone));
            }

            //date picker
            if (dtpStartDate.SelectedDate != null)
            {
                DateTime date = dtpStartDate.SelectedDate.Value.Date;
                employeesFilter = employeesFilter.Where(emp => emp.HireDate >= date);
            }

            // Give the filtered employees as refershing
            lvwEmployees.ItemsSource = null;
            lvwEmployees.ItemsSource = employeesFilter.ToList();
        }

        //delete employee(s)
        private async void btnDelete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //get selected employees together
            var selectedEmployees = lvwEmployees.SelectedItems.Cast<Employee>().ToList();

            if (selectedEmployees.Count == 0)
            {
                MessageDialog lsvEmpty = new MessageDialog("Please select employee");
                await lsvEmpty.ShowAsync();
            }
            else
            {
                //show me selected employees together
                var names = selectedEmployees.Select(emp => $"{emp.FirstName} {emp.LastName}");
                string nameList = string.Join(", ", names);

                MessageDialog m = new MessageDialog($"Delete employees: {nameList}");
                m.Commands.Add(new UICommand("Yes"));
                m.Commands.Add(new UICommand("No"));

                IUICommand result = await m.ShowAsync();

                if (result.Label == "Yes")
                {
                    foreach (var emp in selectedEmployees)
                    {
                        employees.Remove(emp);
                    }
                    Clear();
                }
            }
        }

        //remove all selected
        private void btnCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Clear();
        }

        //clear method 
        public void Clear()
        {
            rdbAll.IsChecked = true;
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            dtpStartDate.SelectedDate = null;

            lvwEmployees.ItemsSource = null;
            lvwEmployees.ItemsSource = employees;
        }

        //go to other page
        private void btnAdd_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewEmployee));
        }

        private void btnPayRoll_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PayRoll), employees);
        }

        private void btnDashboard_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Dashboard), employees);
        }
    }
}