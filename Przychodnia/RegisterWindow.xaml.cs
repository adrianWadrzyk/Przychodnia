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
            pacjent pacjent = new pacjent()
            {
                id_pacjenta = context.pacjent.Local.Count() + 1,
                imie = name_box.Text, 
                nazwisko = surname_box.Text, 
                PESEL = pesel_box.Text, 
                telefon = phone_box.Text,
                miasto = city_box.Text,
                ulica = street_box.Text,
                nr_lokalu = house_num_box.Text
            };

            context.pacjent.Add(pacjent);
        }
    }
}
