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
    /// Interaction logic for DoctorLoginWindow.xaml
    /// </summary>
    public partial class DoctorLoginWindow : Window
    {
        public DoctorLoginWindow()
        {
            InitializeComponent();
        }

        private void Card_patient(object sender, RoutedEventArgs e)
        {
            Przychodnia.PatientCard patientCard = new PatientCard();
            this.Hide();
            patientCard.Show();
        }

        private void Create_new_card(object sender, RoutedEventArgs e)
        {
            Przychodnia.NewCartWindow newCartWindow = new NewCartWindow();
            this.Close();
            newCartWindow.Show();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }
    }
}
