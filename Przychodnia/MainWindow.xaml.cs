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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void register_the_patient_handler(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Przychodnia.RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        private void All_patientShow(object sender, RoutedEventArgs e)
        {
            Przychodnia.AllPatientWindow allPatientWindow = new AllPatientWindow();
            this.Hide();
            allPatientWindow.Show();
        }

        private void Actual_register(object sender, RoutedEventArgs e)
        {
            Przychodnia.ActualRegisterWindow actualRegister = new ActualRegisterWindow();
            this.Hide();
            actualRegister.Show();
        }

        private void hirind_doctor(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow addDoctorWindow = new AddDoctorWindow();
            this.Close();
            addDoctorWindow.Show();
        }
    }
}
