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
        clinicEntities db = new clinicEntities();
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

        private void getPatients(string PESEL)
        {

            var results = from k in db.karta_pacjenta
                          from p in db.pacjent
                          from l in db.lekarz
                          from c in db.choroby
                          where (k.id_pacjenta == 1 && l.id_lekarza == k.lekarz_prowadzacy && c.kod_choroby == k.kod_choroby )
                          select new PatientsCard
                          {
                              Imie = p.imie,
                              Nazwisko = p.nazwisko,
                              Choroba = c.nazwa_choroby,
                              Lekarz = l.imie
                          };
            this.cards.ItemsSource = results.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getPatients(PESEL.Text.Trim());
        }
    }
}
