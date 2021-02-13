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
            if (add_new.IsChecked == false)
            {
                if (specializations.SelectedIndex == -1)
                {
                    MessageBox.Show("Musisz wybrać specjalizacje!");
                    return;
                }
            }else
            {
                if(new_specjalization.Text.Length < 1)
                {
                    MessageBox.Show("Musisz wpisac nową specjalizację!");
                }
            }

            try
            {
                lekarz lekarz = new lekarz()
                {
                    imie = name.Text,
                    nazwisko = surname.Text,
                    id_specjalizacji = specializations.SelectedIndex + 1
                };

                if (add_new.IsChecked ?? true)
                {
                    specjalizacja specjalizacja = new specjalizacja()
                    {
                        nazwa_specjalizacji = new_specjalization.Text
                    };

                    db.specjalizacja.Add(specjalizacja);
                    db.SaveChanges();
                    lekarz.id_specjalizacji = (from r in db.specjalizacja where r.nazwa_specjalizacji == new_specjalization.Text select r.id_specjalizacji).FirstOrDefault();
                };
        
                db.lekarz.Add(lekarz);
                db.SaveChanges();
            }catch
            {
                MessageBox.Show("Ups! Coś poszło nie tak");
                return;
            }

            MessageBox.Show("Dodano nowego lekarza!");
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();

        }

        private void getSpecializations()
        {
            var results = from r in db.specjalizacja select r.nazwa_specjalizacji;
            foreach (var x in results)
                specializations.Items.Add(x);
        }

        private void checkState(object sender, RoutedEventArgs e)
        {
            new_specjalization.IsEnabled = true;
            specializations.IsEnabled = false;
        }

        private void setEnabledNewSpecjalization(object sender, RoutedEventArgs e)
        {
            new_specjalization.IsEnabled = false; 
            specializations.IsEnabled = true;
        }
    }
}
