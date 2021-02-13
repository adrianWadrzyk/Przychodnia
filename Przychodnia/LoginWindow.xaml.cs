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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_action(object sender, RoutedEventArgs e)
        {
            if(login.Text.Length < 1)
            {
                MessageBox.Show("Podaj login!");
                return;
            }
            if(password.Text.Length < 1)
            {
                MessageBox.Show("Podaj hasło");
                return;
            }
            if(login.Text == "doc" && password.Text == "cod")
            {

            } else if(login.Text =="rejestracja" && password.Text == "haslo")
            {

            }else
            {
                MessageBox.Show("Podałeś błędne dane");
                return;
            }


        }
    }
}
