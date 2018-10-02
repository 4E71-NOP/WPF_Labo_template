using Labo_template.Entity;
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
    /// Logique d'interaction pour ongletTables.xaml
    /// </summary>
    /// 


    /*

    Aller regarder comment améliorer la chose avec de controle sur les colonne commenr
        interdire l'édition 
        interdire le tri par colonne
        interdire ou n'avoir qu'une seule ligne selectionnée.

    Sinon voir
    https://www.codeproject.com/tips/362436/data-binding-in-wpf-datagrid-control
    <datagrid alternatingrowremoved="#FFC4B0B0" height="400" width="350" autogeneratecolumns="False" name="grdEmployee">
    <datagrid.columns>
    <datagridtextcolumn binding="{Binding FirstName}" width="100" header="First Name"/>
    <datagridtextcolumn binding="{Binding LastName}" width="100" header="Last Name"/>
    <datagridtextcolumn binding="{Binding Salary}" width="100" header="Salary"/>
    </datagrid.columns>
    </datagrid>
     */


    public partial class ongletTables : UserControl
    {
        private List<User> tabUserTab05ListViewA02 = new List<User>();

        public ongletTables()
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

        private void Tab04ButtonA01_Click(object sender, RoutedEventArgs e)
        {
            Tab04DataGridA02.ItemsSource = tabUserTab05ListViewA02;
        }
        private void Tab04ButtonB01_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tab04ButtonC01_Click(object sender, RoutedEventArgs e)
        {
            Tab04ButtonC01Msg("");
            Tab04DataGridA02.ItemsSource = null;
        }

        //-----------------------------------------------------------------------------
        private void Tab04DataGridA02_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Tab04DataGridA02.ItemsSource != null && Tab04DataGridA02.SelectedIndex != -1)
            {
                Tab04ButtonC01Msg("MouseLeftButtonUp Tab04DataGridA02 : " + Tab04DataGridA02.SelectedIndex + ": " + Tab04DataGridA02.SelectedItem.ToString());
            }
        }
        private void Tab04DataGridA02_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tab04ButtonC01Msg("MouseLeftButtonDown sur Tab04DataGridA02");
        }

        //-----------------------------------------------------------------------------
        private void Tab04GridB02_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tab04ButtonC01Msg("MouseLeftButtonUp sur Tab04GridB02");

        }
        private void Tab04GridB02_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tab04ButtonC01Msg("MouseLeftButtonDown sur Tab04GridB02");
        }


        //-----------------------------------------------------------------------------
        public void Tab04ButtonC01Msg(string msg)
        {
            Tab04LabelC02.Content = msg;
        }


    }
}






