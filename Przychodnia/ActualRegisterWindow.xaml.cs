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
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Imię_doktora { get; set; }
            public string Specyfikacja { get; set; }
            public string Data { get; set; }
            public TimeSpan Godzina { get; set; }
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
                              Imie = p.imie,
                              Nazwisko = p.nazwisko,
                              Imię_doktora = l.imie,
                              Specyfikacja = s.nazwa_specjalizacji,
                              Data = r.data_rejestracji.ToString(),
                              Godzina = r.godzina
                          };
            this.patients.ItemsSource = results.ToList();
        }
    }
 
}
