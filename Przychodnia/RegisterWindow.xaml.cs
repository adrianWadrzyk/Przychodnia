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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        clinicEntities context = new clinicEntities();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void add_patient(object sender, RoutedEventArgs e)
        {
         
            if(!registerDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Wybierz datę wizyty!");
                return;
            }
            if (pesel_box.Text.Length != 11)
            {
                MessageBox.Show("Pesel musi zawierać 11 liczb!");
                return;
            }
            if (phone_box.Text.Length != 9)
            {
                MessageBox.Show("Telefon musi zawierać 9 liczb");
                return;
            }
            if (doctors.SelectedIndex == -1)
            {
                MessageBox.Show("Musisz wybrać doktora prowadzącego!");
                return;
            }

            try
            {
               decimal.Parse(pesel_box.Text);
            } catch
            {
                MessageBox.Show("Pesel nie może zawierać liter");
                return;
            }

            try
            {
                decimal.Parse(phone_box.Text);
            }
            catch
            {
                MessageBox.Show("Telefon nie może zawierać liter");
                return;
            }

            pacjent pacjent = new pacjent()
            {
                imie = name_box.Text,
                nazwisko = surname_box.Text,
                PESEL = pesel_box.Text,
                telefon = phone_box.Text,
                miasto = city_box.Text,
                ulica = street_box.Text,
                nr_lokalu = house_num_box.Text
            };

            rejestracja rejestration = new rejestracja()
            {
                id_pacjenta = pacjent.id_pacjenta,
                id_lekarza = doctors.SelectedIndex+1,
                data_rejestracji = registerDate.SelectedDate.Value,
                godzina = new TimeSpan(10, 00, 11)
            };

            try
            {
                context.pacjent.Add(pacjent);
                context.rejestracja.Add(rejestration);
            }catch
            {
                MessageBox.Show("Ups! Coś poszło nie tak!");
                return;
            }
                
             context.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }

        private void getDoctors()
        {
            var results = from row in context.lekarz select row;
            foreach(var x in results)
                doctors.Items.Add(x.imie);
            MessageBox.Show("Work");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.getDoctors();
        }
    }
}
