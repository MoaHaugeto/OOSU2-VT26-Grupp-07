using OOSU2_VT26_Grupp_07.Datalager;
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
using OOSU2_VT26_Grupp_07.Entiteter;


namespace OOSU2_VT26_Grupp_07.Presentationslager_WPF_
{
    /// <summary>
    /// Interaction logic for RegistreraMedlemmar.xaml
    /// </summary>
    public partial class RegistreraMedlemmar : Window
    {
        private readonly UnitOfWork _uow;
        public RegistreraMedlemmar()
        {
            InitializeComponent();

            _uow = new UnitOfWork();

            medlemskapsnivåComboBox.ItemsSource = new List<string>
            {
                "Välj nivå",
                "Flex",
                "Fast",
                "Företag"
            };

            medlemskapsnivåComboBox.SelectedIndex = 0;


            betalningsStatusComboBox.ItemsSource = new List<string>
            {
               "Välj status",
                "Betald",
                "Obetald"
            };

            betalningsStatusComboBox.SelectedIndex = 0;
        }

        private void registreraMedlemButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(namnTextBox.Text))
            {
                MessageBox.Show("Fyll i namn.");
                return;
            }
            if(medlemskapsnivåComboBox.SelectedIndex == null) 
            {
                MessageBox.Show("Välj medlemskapsnivå.");
                return;
            }

            Medlem medlem = new Medlem
            {
                Namn = namnTextBox.Text.Trim(),
                Telefonnummer = telefonnummerTextBox.Text.Trim(),
                Email = emailTextBox.Text.Trim(),
                MedlemskapsNivå = medlemskapsnivåComboBox.SelectedItem.ToString(), 
                Betalstatus=betalningsStatusComboBox.SelectedItem.ToString()
            };

            _uow.MedlemRepository.LäggTillMedlem(medlem);
            _uow.Save();

            MessageBox.Show("Medlem registrerad");
            this.Close(); 

        }
    }
}
