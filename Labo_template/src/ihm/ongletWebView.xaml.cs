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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletWebView.xaml
    /// </summary>
    public partial class ongletWebView : UserControl
    {
        public ongletWebView()
        {
            InitializeComponent();
        }

        private void Tab09ButtonA01_Click(object sender, RoutedEventArgs e)
        {
            Tab09WebBrowserA02.Navigate(new Uri(Tab09TextBoxB01.Text));
        }
    }
}
