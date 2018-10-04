using Labo_template.agents;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletBoutons.xaml
    /// </summary>
    public partial class ongletBoutons : UserControl
    {
        private bool es;
        private string[] Tab = { "Faux" , "Vrai"};

        public ongletBoutons()
        {
            InitializeComponent();
            Msg.Publication("Initialisation de l'onglet 'Boutons'...");
        }

        private void Tab01Bouton01_Click(object sender, RoutedEventArgs e)
        {
            string etat = Tab[Convert.ToInt16(changeEs())];
            Tab01Label01.Content = "Etat de ES : " + etat;
            Msg.Publication("Etat de ES : " + etat);
        }

        private void Tab01Bouton02_Click(object sender, RoutedEventArgs e)
        {
            Tab01Label01.Content = "";
            Msg.Publication("Vidage effectué");
        }

        private bool changeEs ()
        {
            es = !es;
            return es;
        }

    }
}
