using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletImage.xaml
    /// </summary>
    public partial class ongletImage : System.Windows.Controls.UserControl
    {
        public static ongletImage Instance = null;



        public ongletImage()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Tab07ButtonA01_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selecteurFichier = new OpenFileDialog();
            //ofd.Filter = "txt files (.)|.txt|All files (.)|.";
            if ( selecteurFichier.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                Tab07ButtonA100.Content = "FileName='" + selecteurFichier.FileName + "'";
                Tab07ImageB01.Source = new BitmapImage(new Uri(selecteurFichier.FileName));
            }
            selecteurFichier = null;
        }
    }
}
