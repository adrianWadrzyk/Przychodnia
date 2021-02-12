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
    /// Interaction logic for ActualRegisterWindow.xaml
    /// </summary>
    public partial class ActualRegisterWindow : Window
    {
        clinicEntities db = new clinicEntities();

        public ActualRegisterWindow()
        {
            InitializeComponent();
            getPatients();
        }
        public class PatientRegisteredView
        {
            public int Id_rejestracji { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Imie_doktora { get; set; }
            public string Specyfikacja { get; set; }
            public string Data_rejestracji { get; set; }
            public TimeSpan Godzina_przyjęcia { get; set; }
        }

        private void getPatients()
        {
            var results = from r in db.rejestracja
                          from p in db.pacjent
                          from l in db.lekarz
                          from s in db.specjalizacja
                          where (r.id_pacjenta == p.id_pacjenta && r.id_lekarza == l.id_lekarza && s.id_specjalizacji == l.id_specjalizacji)
                          select new PatientRegisteredView
                          {
                              Id_rejestracji = (int)r.id_rejestracji,
                              Imie = p.imie,
                              Nazwisko = p.nazwisko,
                              Imie_doktora = l.imie,
                              Specyfikacja = s.nazwa_specjalizacji,
                              Data_rejestracji = r.data_rejestracji.ToString(),
                              Godzina_przyjęcia = r.godzina
                          };
            this.patients.ItemsSource = results.ToList();
        }

        private void register(object sender, RoutedEventArgs e)
        {
            Przychodnia.RegisterWindow register = new RegisterWindow();
            this.Close();
            register.Show();
        }

        private void deleteRow(object sender, RoutedEventArgs e)
        {
            try
            {
              int register_id = (patients.SelectedItem as PatientRegisteredView).Id_rejestracji;
              var x = (from r in db.rejestracja where r.id_rejestracji == register_id select r).SingleOrDefault();
              db.rejestracja.Remove(x);
            }
            catch
            {
                MessageBox.Show("Wybierz element do usunięcia!");
                return;
            }
            edit.ItemsSource = null;
            db.SaveChanges();
            getPatients();
        }

        private void editRow(object sender, RoutedEventArgs e)
        {
            var register = patients.SelectedItem as PatientRegisteredView;
            var data = from r in db.rejestracja where r.id_rejestracji == register.Id_rejestracji select new PatientRegisteredView
            {
                Id_rejestracji = (int)r.id_rejestracji,
                Data_rejestracji = r.data_rejestracji.ToString(),
                Godzina_przyjęcia = r.godzina
            };
            try
            {
                edit.ItemsSource = data.ToList();
            }
            catch
            {
                MessageBox.Show("Wybierz element do edycji!");
                return;
            }
        }

        private void saveEditing(object sender, RoutedEventArgs e)
        {
            var toEdit = edit.SelectedItem as PatientRegisteredView;
            var result = (from r in db.rejestracja where r.id_rejestracji == toEdit.Id_rejestracji select r).Single();
            result.data_rejestracji =DateTime.Parse(toEdit.Data_rejestracji);
            result.godzina = toEdit.Godzina_przyjęcia;
            db.SaveChanges();
            getPatients();
        }

        private void backToMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
 
}
