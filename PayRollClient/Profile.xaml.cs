using EmployeeLibrary;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PayRollClient
{
    public sealed partial class Profile : Page
    {
        public Profile()
        {
            this.InitializeComponent();
        }

        Employee employee;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        //bring the employee's info
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Employee)
            {
                employee = e.Parameter as Employee;

                //add the event handler when first known its training
                if (employee is Training t)
                {
                    t.CheckBonusEvent += BonusHandlerMethod;
                }
                Refresh(employee);
            }
        }

        //update employee info
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //check if status changed
                bool activeChanged;
                if (cboStatus.SelectedIndex == 0)
                {
                    activeChanged = true;
                }
                else
                {
                    activeChanged = false;
                }

                //because active status means firing or hiring someone I want to check
                if (employee.Active != activeChanged)
                {
                    MessageDialog m = new MessageDialog("Do you want to update employee status?");
                    m.Commands.Add(new UICommand("Yes"));
                    m.Commands.Add(new UICommand("No"));

                    IUICommand result = await m.ShowAsync();

                    if (result.Label == "No")
                    {
                        cboStatus.SelectedIndex = employee.Active == true ? 0 : 1;
                        return;
                    }
                    employee.Active = activeChanged;
                }

                employee.Phone = txtPhone.Text;
                employee.Email = txtEmail.Text;

                //update salary amount by employee's type 
                if (employee is Salary empSal)
                {
                    empSal.Amount = decimal.Parse(txtPaid.Text, System.Globalization.NumberStyles.Currency);
                }
                else if (employee is Hourly empHour)
                {
                    empHour.Rate = decimal.Parse(txtSalary.Text, System.Globalization.NumberStyles.Currency);
                }
                else if (employee is Training empTrain)
                {
                    //here if the training person completed training
                    //then employee will paid
                    //and check the bonus
                    //if completed in 2weeks it has bonus
                    if (cboStatus.SelectedIndex == 2)
                    {
                        empTrain.Bonus();
                        empTrain.CalculatePay();
                    }

                    //because training pay is one time and static
                    if (Training.amount != decimal.Parse(txtSalary.Text, System.Globalization.NumberStyles.Currency))
                    {
                        MessageDialog m = new MessageDialog($"Do you want to update training pay?");
                        m.Commands.Add(new UICommand("Yes"));
                        m.Commands.Add(new UICommand("No"));

                        IUICommand result = await m.ShowAsync();

                        if (result.Label == "No")
                        {
                            return;
                        }
                        Training.amount = decimal.Parse(txtSalary.Text, System.Globalization.NumberStyles.Currency);
                    }

                }

                employee.Address = new Address(
                    txtStreet.Text,
                    txtCity.Text,
                    txtProvince.Text,
                    txtPostalCode.Text
                );

                //if updated go back
                MessageDialog updated = new MessageDialog("Employee information updated successfully.");
                await updated.ShowAsync();

                if (this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();
                }
            }
            catch (Exception ex)
            {
                MessageDialog error = new MessageDialog("Update failed: " + ex.Message);
                await error.ShowAsync();
            }
        }

        //refresh
        public void Refresh(Employee emp)
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Inactive");
            cboStatus.SelectedIndex = emp.Active ? 0 : 1;
            txtType.Text = emp.GetType().Name;


            if (emp is Salary s)
            {
                lblSalaryType.Text = "Biweekly pay: ";
                txtSalary.Text = emp.CalculatePay().ToString("C2");
                txtSalary.IsReadOnly = true;
                pnlPaid.Visibility = Visibility.Visible;
                lblPaid.Text = "Salary amount:";
                txtPaid.Text = s.Amount.ToString("C2");
            }
            else if (emp is Hourly h)
            {
                lblSalaryType.Text = "Biweekly pay: ";
                txtSalary.Text = emp.CalculatePay().ToString("C2");
                txtSalary.IsReadOnly = true;
                pnlPaid.Visibility = Visibility.Visible;
                lblPaid.Text = "Hourly pay: ";
                txtPaid.Text = h.Rate.ToString("C2");

            }
            else if (emp is Training t)
            {
                cboStatus.Items.Add("Completed");
                lblSalaryType.Text = "One time pay: ";
                txtSalary.Text = Training.amount.ToString("C2");
                pnlPaid.Visibility = Visibility.Visible;
                lblPaid.Text = "Is Paid: ";
                txtPaid.IsReadOnly = true;
                if (t.IsPaid)
                {
                    txtPaid.Text = "Yes";
                }
                else
                {
                    txtPaid.Text = "No";
                }

            }


            txtSin.Text = emp.Sin;
            txtName.Text = $"{emp.FirstName} {emp.LastName}";
            txtBirthDate.Text = emp.BirthDate.ToString("yyyy/MM/dd");

            if (emp.BirthDate.Month == DateTime.Today.Month && emp.BirthDate.Day == DateTime.Today.Day)
            {
                imgBirthday.Visibility = Visibility.Visible;
            }
            else
            {
                imgBirthday.Visibility = Visibility.Collapsed;
            }

            int week = (DateTime.Now - emp.HireDate).Days / 14;
            txtPeriod.Text = week.ToString() + " weeks";
            txtPhone.Text = emp.Phone;
            txtEmail.Text = emp.Email;

            txtStreet.Text = emp.Address.Street ?? "";
            txtCity.Text = emp.Address.City ?? "";
            txtProvince.Text = emp.Address.Province ?? "";
            txtPostalCode.Text = emp.Address.PostalCode ?? "";
        }

        private async void BonusHandlerMethod()
        {
            MessageDialog bonus = new MessageDialog($"{employee.FirstName} {employee.LastName} got bonus!");
            await bonus.ShowAsync();
        }
    }
}