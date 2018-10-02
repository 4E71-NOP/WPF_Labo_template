using Labo_template.agents;
using Labo_template.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo_template
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Msg.Publication("Initalisation de la fenêtre principale...");
        }

        private void FenetreInitiale_Activated(object sender, EventArgs e) { AnnulationEffet(); }
        private void FenetreInitiale_Deactivated(object sender, EventArgs e) { AjoutEffet(); }

        private void AnnulationEffet()
        {
            Msg.Publication("Le focus est revenu");
            this.Effect = null;
        }
        private void AjoutEffet()
        {
            Msg.Publication("Le focus est parti");
            BlurEffect be = new BlurEffect { Radius = 5 };
            FenetreInitiale.Effect = be;
            //FenetreInitiale.Background = new SolidColorBrush(Color.FromArgb(16, 255, 255, 255));


        }

    }
}
