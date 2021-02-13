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
    /// Interaction logic for PatientCard.xaml
    /// </summary>        

    public partial class PatientCard : Window
    {
        readonly clinicEntities db = new clinicEntities();
        public PatientCard()
        {
            InitializeComponent();
        }

        public class PatientsCard
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Choroba { get; set; }
            public string Lekarz { get; set; }
        }

        private void GetPatients(string PESEL)
        {

            var patient = from p in db.pacjent
                          where p.PESEL == PESEL
                          select p;

            var card = from x in patient
                       from c in db.karta_pacjenta
                       where x.id_pacjenta == c.id_pacjenta
                       select new PatientsCard
                       {
                           Imie = x.imie,
                           Nazwisko = x.nazwisko,
                       };

            this.cards.ItemsSource = card.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetPatients(PESEL.Text.Trim());
        }
    }
}
