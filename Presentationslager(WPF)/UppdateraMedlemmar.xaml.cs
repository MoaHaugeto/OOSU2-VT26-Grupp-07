using OOSU2_VT26_Grupp_07.Controller;
using OOSU2_VT26_Grupp_07.Datalager;
using OOSU2_VT26_Grupp_07.Entiteter;
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

namespace OOSU2_VT26_Grupp_07.Presentationslager_WPF_
{
    /// <summary>
    /// Interaction logic for UppdateraMedlemmar.xaml
    /// </summary>
    public partial class UppdateraMedlemmar : Window
    {
        private readonly UnitOfWork _uow;
        private readonly MedlemsController _controller;
        public UppdateraMedlemmar()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            _controller = new MedlemsController(_uow);

           
            nivaComboBox.ItemsSource = new List<string> { "Flex", "Fast", "Företag" };
            statusComboBox.ItemsSource = new List<string> { "Betald", "Obetald" };

            // Ladda alla medlemmar i listan högst upp
            medlemComboBox.ItemsSource = _controller.HämtaAllaMedlemmar();
        }
        private void medlemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (medlemComboBox.SelectedItem is Medlem valdMedlem)
            {
                // Fyll i textrutorna med den valda medlemmens data
                namnTextBox.Text = valdMedlem.Namn;
                emailTextBox.Text = valdMedlem.Email;
                telefonTextBox.Text = valdMedlem.Telefonnummer;
                nivaComboBox.SelectedItem = valdMedlem.MedlemskapsNivå;
                statusComboBox.SelectedItem = valdMedlem.Betalstatus;
            }
        }
        private void sparaButton_Click(object sender, RoutedEventArgs e)
        {
            if (medlemComboBox.SelectedItem is Medlem valdMedlem)
            {
                // Uppdatera objektet med nya värden
                valdMedlem.Namn = namnTextBox.Text;
                valdMedlem.Email = emailTextBox.Text;
                valdMedlem.Telefonnummer = telefonTextBox.Text;
                valdMedlem.MedlemskapsNivå = nivaComboBox.SelectedItem?.ToString();
                valdMedlem.Betalstatus = statusComboBox.SelectedItem?.ToString();

                // Spara via controllern
                _controller.UppdateraMedlem(valdMedlem);

                MessageBox.Show("Medlem uppdaterad!");
                _uow.Dispose();
                HanteraMedlemar meny = new HanteraMedlemar();
                meny.Show();
                this.Close();
            }
        }

        private void tillbakaButton_Click(object sender, RoutedEventArgs e)
        {
            _uow.Dispose();
            HanteraMedlemar meny = new HanteraMedlemar();
            meny.Show();
            this.Close();
        }
    }
}
