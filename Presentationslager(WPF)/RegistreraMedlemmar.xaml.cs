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
using OOSU2_VT26_Grupp_07.Controller;


namespace OOSU2_VT26_Grupp_07.Presentationslager_WPF_
{
    /// <summary>
    /// Interaction logic for RegistreraMedlemmar.xaml
    /// </summary>
    public partial class RegistreraMedlemmar : Window
    {
        private readonly UnitOfWork _uow;
        private readonly MedlemsController _controller;
        public RegistreraMedlemmar()
        {
            InitializeComponent();

            _uow = new UnitOfWork();
            _controller = new MedlemsController(_uow);

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
            string namn = namnTextBox.Text;
            string telefon = telefonnummerTextBox.Text;
            string email = emailTextBox.Text;


            string medlemskapsnivå = medlemskapsnivåComboBox.SelectedItem?.ToString();
            string betalstatus = betalningsStatusComboBox.SelectedItem?.ToString();

            bool resultat = _controller.LäggTillMedlem(
                namn,
                telefon,
                email,
                medlemskapsnivå,
                betalstatus,
                out string felmeddelande
                );

            if (!resultat)
            {
                MessageBox.Show(felmeddelande);
                return;
            }

            MessageBox.Show("Medlem registrerad!");
            _uow.Dispose();
            this.Close();

        }

    }
}
