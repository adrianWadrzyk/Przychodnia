﻿using System;
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
                imie = name_box.Text, 
                nazwisko = surname_box.Text, 
                PESEL = pesel_box.Text, 
                telefon = phone_box.Text,
                miasto = city_box.Text,
                ulica = street_box.Text,
                nr_lokalu = house_num_box.Text
            };
            
            try
            {
                if (pesel_box.Text.Length == 11)
                    int.Parse(pesel_box.Text);
                else
                    MessageBox.Show("Pesel musi zawierać 11 liczb!");
            } catch
            {
                MessageBox.Show("Pesel nie może zawierać liter");
                return;
            }

            try
            {
                if (phone_box.Text.Length == 9)
                    int.Parse(phone_box.Text);
                else
                    MessageBox.Show("Telefon musi zawierać 9 liczb");
            } catch
            {
                MessageBox.Show("Telefon nie może zawierać liter");
                return;
            }
                context.pacjent.Add(pacjent);
                context.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }
    }
}
