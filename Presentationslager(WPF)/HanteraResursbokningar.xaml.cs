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
    /// Interaction logic for HanteraResursbokningar.xaml
    /// </summary>
    public partial class HanteraResursbokningar : Window
    {
        public HanteraResursbokningar()
        {
            InitializeComponent();
        }

        private void TillbakaButton_Click(object sender, RoutedEventArgs e)
        {
            PersonalMeny meny = new PersonalMeny();
            meny.Show();
            this.Close();
        }
    }
}
