using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for LoggedRegistrationWindow.xaml
    /// </summary>
    public partial class LoggedRegistrationWindow : Window
    {
        public LoggedRegistrationWindow()
        {
            InitializeComponent();
        }
        // show register window
        private void Register_the_patient_handler(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Przychodnia.RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
        // show all patient list window
        private void All_patientShow(object sender, RoutedEventArgs e)
        {
            Przychodnia.AllPatientWindow allPatientWindow = new AllPatientWindow();
            this.Hide();
            allPatientWindow.Show();
        }
        // show actual register from database
        private void Actual_register(object sender, RoutedEventArgs e)
        {
            Przychodnia.ActualRegisterWindow actualRegister = new ActualRegisterWindow();
            this.Hide();
            actualRegister.Show();
        }
        // show hiring doctor window
        private void Hiring_doctor(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow addDoctorWindow = new AddDoctorWindow();
            this.Close();
            addDoctorWindow.Show();
        }
        // back to login window
        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }
    }
}
