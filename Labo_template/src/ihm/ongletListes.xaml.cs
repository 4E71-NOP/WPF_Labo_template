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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletListes.xaml
    /// </summary>
    public partial class ongletListes : UserControl
    {
        private List<User> tabUserTab05ListViewA02 = new List<User>();

        public ongletListes()
        {
            InitializeComponent();

            tabUserTab05ListViewA02.Add(new User("Durand", "Jean", 17));
            tabUserTab05ListViewA02.Add(new User("Durand", "Martin", 18));
            tabUserTab05ListViewA02.Add(new User("Durand", "Clementine", 19));
            tabUserTab05ListViewA02.Add(new User("Durand", "Amelia", 20));
            tabUserTab05ListViewA02.Add(new User("Boulanger", "Jean", 17));
            tabUserTab05ListViewA02.Add(new User("Boulanger", "Martin", 18));
            tabUserTab05ListViewA02.Add(new User("Boulanger", "Clementine", 19));
            tabUserTab05ListViewA02.Add(new User("Boulanger", "Amelia", 20));

        }

        //-----------------------------------------------------------------------------
        private void Tab05ButtonA01_Click(object sender, RoutedEventArgs e)
        {
            Tab05ListViewA02.ItemsSource = tabUserTab05ListViewA02;
            Tab05ListViewA03.ItemsSource = tabUserTab05ListViewA02;

            // Tri sur un critère 
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Tab05ListViewA02.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));

            Tab05LabelC02Msg("");
        }

        private void Tab05ButtonB01_Click(object sender, RoutedEventArgs e)
        {
            Tab05ListBoxB02.ItemsSource = tabUserTab05ListViewA02;
            Tab05LabelC02Msg("");
        }

        private void Tab05ButtonC01_Click(object sender, RoutedEventArgs e)
        {
            Tab05ListViewA02.ItemsSource = null;
            Tab05ListViewA03.ItemsSource = null;
            Tab05ListBoxB02.ItemsSource = null;
            Tab05LabelC02Msg("");
        }

        //-----------------------------------------------------------------------------
        private void Tab05ListViewA02_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Tab05ListViewA02.ItemsSource != null && Tab05ListViewA02.SelectedItem != null)
            {
                Tab05LabelC02Msg("MouseLeftButtonUp Tab05ListViewA02 : " + Tab05ListViewA02.SelectedIndex + ": " + Tab05ListViewA02.SelectedItem.ToString());
            }
        }

        // N'est pas lancé en tant que tel mais en tant que PreviewMouseLeftButtonDown
        // https://social.msdn.microsoft.com/Forums/en-US/61807025-d4c4-41e0-b648-b11183065009/mousedown-event-not-working-wpf?forum=wpf
        private void Tab05ListViewA02_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tab05LabelC02Msg("MouseLeftButtonDown sur Tab05ListViewA02");
        }

        //-----------------------------------------------------------------------------
        private void Tab05ListViewA03_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Tab05ListViewA03.ItemsSource != null && Tab05ListViewA03.SelectedItem != null)
            {
                Tab05LabelC02Msg("MouseLeftButtonUp Tab05ListViewA03 : " + Tab05ListViewA03.SelectedIndex + ": " + Tab05ListViewA03.SelectedItem.ToString());
            }
        }
        private void Tab05ListViewA03_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tab05LabelC02Msg("MouseLeftButtonDown sur Tab05ListViewA03");
        }

        //-----------------------------------------------------------------------------
        private void Tab05ListBoxB02_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Tab05ListBoxB02.ItemsSource != null && Tab05ListBoxB02.SelectedItem != null)
            {
                Tab05LabelC02Msg("MouseLeftButtonUp Tab05ListBoxB02 : " + Tab05ListBoxB02.SelectedIndex + ": " + Tab05ListBoxB02.SelectedItem.ToString());
            }
        }
        private void Tab05ListBoxB02_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tab05LabelC02Msg("MouseLeftButtonDown sur Tab05ListBoxB02");
        }

        //-----------------------------------------------------------------------------
        //  Méthode de gestion du click de la colonne pour faire un tri dans la liste
        public void Tab05LabelC02Msg(string msg)
        {
            Tab05LabelC02.Content = msg;
        }


        private GridViewColumnHeader Tab05ListViewA03SortCol = null;
        private bool Tab05ListViewA03SortColDir;

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {

            GridViewColumnHeader colonneEnCours = (sender as GridViewColumnHeader);

            string titreColonneEnCours = colonneEnCours.Content.ToString();
            string sortBy = colonneEnCours.Tag.ToString();

            if (Tab05ListViewA03SortCol != null)
            {
                Tab05ListViewA03.Items.SortDescriptions.Clear();
            }

            ListSortDirection lsd = ListSortDirection.Ascending;
            titreColonneEnCours = titreColonneEnCours.Replace("↓", string.Empty);

            if (Tab05ListViewA03SortCol == colonneEnCours)
            {
                Tab05ListViewA03SortColDir = !Tab05ListViewA03SortColDir;
            }

            switch (Tab05ListViewA03SortColDir)
            {
                case true:
                    lsd = ListSortDirection.Descending;
                    titreColonneEnCours += "↓";
                    break;
                default:
                    lsd = ListSortDirection.Ascending;
                    break;
            }

            Tab05ListViewA03SortCol = colonneEnCours;
            colonneEnCours.Content = titreColonneEnCours;
            Tab05ListViewA03.Items.SortDescriptions.Add(new SortDescription(sortBy, lsd));

            Tab05LabelC02.Content = "titreColonneEnCours : " + titreColonneEnCours + ", ";
        }

    }

}
