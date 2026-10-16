using EmployeeLibrary;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PayRollClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewEmployee : Page
    {
        public NewEmployee()
        {
            this.InitializeComponent();
        }

        Employee employee;

        //navigate through this page
        //initialize
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Employee)
            {
                employee = e.Parameter as Employee;
            }
        }

        //go back
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool status = cboStatus.SelectedIndex == 0;
                string sin = txtSin.Text;
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                DateTime hireDate = DateTime.Now;
                DateTime birthDate = dtpBirthDate.Date.DateTime;
                string email = txtEmail.Text;
                string phone = txtPhone.Text;

                string street = txtStreet.Text;
                string city = txtCity.Text;
                string province = txtProvince.Text;
                string postalCode = txtPostalCode.Text;

                Address address = new Address(street, city, province, postalCode);

                int type = cboType.SelectedIndex;

                Employee newEmployee = null;

                //check combo box type
                switch (type)
                {
                    case 0:
                        decimal salaryAmount = decimal.Parse(txtAmount.Text);
                        newEmployee = new Salary(sin, firstName, lastName, hireDate, birthDate, email, phone, address, status, salaryAmount);
                        break;

                    case 1:
                        decimal rate = decimal.Parse(txtAmount.Text);
                        newEmployee = new Hourly(sin, firstName, lastName, hireDate, birthDate, email, phone, address, status, rate, 0);
                        break;

                    case 2:
                        newEmployee = new Training(sin, firstName, lastName, hireDate, birthDate, email, phone, address, status);
                        break;
                }

                MessageDialog added = new MessageDialog("Succesfully Added");
                added.ShowAsync();

                //Pass new employee info to main page
                Frame.Navigate(typeof(MainPage), newEmployee);
            }
            catch (Exception ex)
            {
                MessageDialog error = new MessageDialog(ex.Message);
                error.ShowAsync();
            }
        }

        //combo box type change bc of emount salary
        private void cboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pnlAmount.Visibility = Visibility.Visible;
            int type = cboType.SelectedIndex;

            switch (type)
            {
                case 0:
                    lblAmount.Text = "Yearly amount:";
                    txtAmount.IsReadOnly = false;
                    txtAmount.Text = "";
                    break;
                case 1:
                    lblAmount.Text = "Rate:";
                    txtAmount.IsReadOnly = false;
                    txtAmount.Text = "";
                    break;
                case 2:
                    lblAmount.Text = "One Time Pay:";
                    txtAmount.IsReadOnly = true;
                    txtAmount.Text = Training.amount.ToString("C2");
                    break;

            }



        }
    }
}
