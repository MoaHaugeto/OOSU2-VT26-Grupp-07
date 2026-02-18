using OOSU2_VT26_Grupp_07.Controller;
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

namespace OOSU2_VT26_Grupp_07.Presentationslager_WPF_
{
    /// <summary>
    /// Interaction logic for RegistreraResursbokning.xaml
    /// </summary>
    public partial class RegistreraResursbokning : Window
    {
        private readonly UnitOfWork _uow;
        private readonly BokningsController _controller;
        public RegistreraResursbokning()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            _controller = new BokningsController(_uow);

            // Sätt dagens datum som standardval
            BokningsdatumPicker.SelectedDate = DateTime.Now;
        }

        private void registreraBokningButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validering av numeriska ID-fält
                if (!int.TryParse(ResursIDTextBox.Text, out int resursId))
                {
                    MessageBox.Show("ResursID måste vara en siffra.");
                    return;
                }

                if (!int.TryParse(MedlemsIDTextBox.Text, out int medlemsId))
                {
                    MessageBox.Show("MedlemsID måste vara en siffra.");
                    return;
                }

                if (BokningsdatumPicker.SelectedDate == null)
                {
                    MessageBox.Show("Vänligen välj ett datum.");
                    return;
                }

                DateTime datum = BokningsdatumPicker.SelectedDate.Value;
                TimeSpan start = TimeSpan.Parse(StarttidTextBox.Text);
                TimeSpan slut = TimeSpan.Parse(SluttidTextBox.Text);

                // Anropa controllern för att skapa bokningen och hantera krockkontroll
                bool resultat = _controller.SkapaBokning(
                    medlemsId,
                    resursId,
                    datum,
                    start,
                    slut,
                    out string felmeddelande
                );

                if (!resultat)
                {
                    MessageBox.Show(felmeddelande);
                    return;
                }

                MessageBox.Show("Bokningen har registrerats!");
                _uow.Dispose();
                HanteraResursbokningar meny = new HanteraResursbokningar();
                meny.Show();
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vänligen ange tider i formatet HH:mm (t.ex. 14:00).");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ett oväntat fel uppstod: {ex.Message}");
            }
        }

        private void avbrytButton_Click(object sender, RoutedEventArgs e)
        {
            _uow?.Dispose();
            HanteraResursbokningar meny = new HanteraResursbokningar();
            meny.Show();
            this.Close();
        }


    }
}

