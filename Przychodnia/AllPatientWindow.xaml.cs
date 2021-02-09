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
using System.Data.Entity;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for AllPatientWindow.xaml
    /// </summary>
    public partial class AllPatientWindow : Window
    {
        clinicEntities context = new clinicEntities();
        CollectionViewSource patientViewSource;
        public AllPatientWindow()
        {
            InitializeComponent();
            patientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pacjentViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.pacjent.Load();
            patientViewSource.Source = context.pacjent.Local;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            patientViewSource.View.MoveCurrentToNext();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}