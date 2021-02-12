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
    /// Interaction logic for AddDoctorWindow.xaml
    /// </summary>
    public partial class AddDoctorWindow : Window
    {
        clinicEntities db = new clinicEntities();
        public AddDoctorWindow()
        {
            InitializeComponent();
            getSpecializations();
        }

        private void addDoctor(object sender, RoutedEventArgs e)
        {
            if(name.Text.Length < 1)
            {
                MessageBox.Show("Podaj imie lakarza!");
                return;
            }
            if(surname.Text.Length < 1)
            {
                MessageBox.Show("Podaj nazwisko lekarza!");
                return;
            }
            if (add_new.IsChecked ?? false)
            {
                if (specializations.SelectedIndex == -1)
                {
                    MessageBox.Show("Musisz wybrać specjalizacje!");
                    return;
                }
            }

            try
            {
                lekarz lekarz = new lekarz()
                {
                    imie = name.Text,
                    nazwisko = surname.Text,
                    id_specjalizacji = specializations.SelectedIndex+1
                };
                db.lekarz.Add(lekarz);
                db.SaveChanges();
            }catch
            {
                MessageBox.Show("Ups! Coś poszło nie tak");
                return;
            }

            MessageBox.Show("Dodano nowego lekarza!");
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }

        private void getSpecializations()
        {
            var results = from r in db.specjalizacja select r.nazwa_specjalizacji;
            specializations.ItemsSource = results;
        }

        private void checkState(object sender, RoutedEventArgs e)
        {
            new_specjalization.IsEnabled = ((bool)add_new.IsChecked);
        }
    }
}
