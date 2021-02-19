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
using System.Data.Entity;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for AllPatientWindow.xaml
    /// </summary>
    public partial class AllPatientWindow : Window
    {
        readonly clinicEntities db = new clinicEntities();
        readonly CollectionViewSource patientViewSource;
        public AllPatientWindow()
        {
            InitializeComponent();
            patientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pacjentViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.pacjent.Load();
            patientViewSource.Source = db.pacjent.Local;
        }
        // move to next record
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            patientViewSource.View.MoveCurrentToNext();
        }
        //  back to main menu
        private void Close(object sender, RoutedEventArgs e)
        {
            LoggedRegistrationWindow loggedRegistration = new LoggedRegistrationWindow();
            this.Close();
            loggedRegistration.Show();
        }
    }
}
