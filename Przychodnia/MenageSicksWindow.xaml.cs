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
    /// Interaction logic for MenageSicksWindow.xaml
    /// </summary>
    public partial class MenageSicksWindow : Window
    {
        DoctorLoginWindow doctorLogin = new DoctorLoginWindow();
        readonly clinicEntities db = new clinicEntities();
        public MenageSicksWindow()
        {
            InitializeComponent();
            FillSicksList();
        }

        private void Add_sickButton_Click(object sender, RoutedEventArgs e)
        {
            if(sick_nameTextBox.Text.Length < 1)
            {
                MessageBox.Show("Podaj nazwę choroby!");
                return;
            }
            if(sick_codeTextBox.Text.Length > 6 || sick_codeTextBox.Text.Length < 1)
            {
                MessageBox.Show("Podaj poprawny kod choroby! (max 6 znaków)");
                return;
            }
            try
            {
                choroby sick = new choroby()
                {
                    kod_choroby = sick_codeTextBox.Text.Trim(),
                    nazwa_choroby = sick_nameTextBox.Text.Trim()
                };
                db.choroby.Add(sick);
                db.SaveChanges();
            }catch
            {
                MessageBox.Show("Nie udało się dodać choroby!");
                return;
            }
            MessageBox.Show("Dodano chorobę do bazy!");
            this.Close();
            doctorLogin.Show();
        }

        private void FillSicksList()
        {
            var results = from r in db.choroby select r.kod_choroby;
            foreach (var x in results)
                sicks_list.Items.Add(x);
        }

        private void EnableDeleteButton(object sender, SelectionChangedEventArgs e)
        {
            delete_sick.IsEnabled = true;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var toDelete = (from r in db.choroby
                            where r.kod_choroby == sicks_list.SelectedItem.ToString()
                            select r).FirstOrDefault();
            try
            {
                db.choroby.Remove(toDelete);
                db.SaveChanges();
            }catch
            {
                MessageBox.Show("Ups! Coś poszło nie tak!");
                return;
            }
            MessageBox.Show("Usunięto chorobę");
            this.Hide();
            doctorLogin.Show();
           
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DoctorLoginWindow doctorLogin = new DoctorLoginWindow();
            this.Close();
            doctorLogin.Show();
        }
    }
}
