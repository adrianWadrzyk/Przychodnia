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
    /// Interaction logic for NewCartWindow.xaml
    /// </summary>
    public partial class NewCartWindow : Window
    {
        clinicEntities db = new clinicEntities();
        public NewCartWindow()
        {
         InitializeComponent();
    }

    private void find_Click(object sender, RoutedEventArgs e)
        {
            if (PESEL.Text.Length < 9)
            {
                MessageBox.Show("Pesel nie może być krótszy niż 11 liczb!");
                return ;
            }else
            {
                try
                {
                    var result = (from id in db.pacjent where id.PESEL == PESEL.Text select id).FirstOrDefault();
                    this.name.Text = result.imie;
                    this.surname.Text = result.nazwisko;
                    this.patient_id.Text =  result.id_pacjenta.ToString();
                }catch
                {
                    MessageBox.Show("Nie znaleziono takiego pacjenta");
                    return;
                }

                getDoctors();
                getCure();
                getSickCode();
                getServices();
            }
        }
        private void getDoctors()
        {
            var results = from row in db.lekarz select row;
            foreach (var x in results)
                docktor.Items.Add(x.imie);
        }

        private void getSickCode()
        {
            var results = from row in db.choroby select row;
            foreach (var x in results)
                sick_code.Items.Add(x.kod_choroby + " ("+ x.nazwa_choroby + ")");
        }

        private void getCure()
        {
            var results = from row in db.lek select row;
            foreach (var x in results)
                cure.Items.Add(x.nazwa_leku);
        }

        private void getServices()
        {
            var results = from row in db.uslugi select row;
            foreach (var x in results)
                services.Items.Add(x.nazwa_uslugi);
        }

        private void add_newCard(object sender, RoutedEventArgs e)
        {
            if (patient_id.Text.Length == 0)
            {
                MessageBox.Show("Wybierz pacjenta!");
                return;
            }
            if(docktor.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz lekarza prowadzącego!");
                return;
            }
            if (cure.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz lek!");
                return;
            }
            if (cure.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz chorobę!");
                return;
            }
            if (diagnosis.Text.Length < 50)
            {
                MessageBox.Show("Diagnoza nie może być krótsza niż 50 znaków!");
                return;
            }

            try
            {
                karta_pacjenta karta = new karta_pacjenta()
                {
                    id_pacjenta = int.Parse(patient_id.Text),
                    wykonane_uslugi = services.SelectedIndex + 1,
                    kod_choroby = sick_code.Text.Split(' ')[0],
                    id_leku = sick_code.SelectedIndex + 1,
                    lekarz_prowadzacy = docktor.SelectedIndex + 1,
                    diagnoza = diagnosis.Text
                };
                db.karta_pacjenta.Add(karta);
                db.SaveChanges();
            }catch
            {
                MessageBox.Show("Ups! Coś poszlo nie tak!");
                return;
            }
            MessageBox.Show("Karta pacjenta została utworzona!");
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }

}
