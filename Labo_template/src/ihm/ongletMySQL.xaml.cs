using Labo_template.agents;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletMySQL.xaml
    /// </summary>
    public partial class ongletMySQL : UserControl
    {
        public ongletMySQL()
        {
            InitializeComponent();
        }

        private void Tab13ButtonB01_Click(object sender, RoutedEventArgs e)
        {
            Tab13TextBoxB02.Text = "192.168.1.12";
            Tab13TextBoxB03.Text = "root";
            Tab13PasswordBoxB04.Password = "1a2b3c4d";
            Tab13TextBoxB05.Text = "code_test";
            Tab13TextBoxB06.Text = "SslMode=none";
            Tab13TextBoxB07.Text = "SELECT * FROM code_test.utilisateurs";
        }

        private void Tab13ButtonB08_Click(object sender, RoutedEventArgs e)
        {
            bool formulaireValide = true;
            if (Tab13TextBoxB02.Text.Length == 0) { formulaireValide = false; }
            if (Tab13TextBoxB03.Text.Length == 0) { formulaireValide = false; }
            if (Tab13PasswordBoxB04.Password.Length == 0) { formulaireValide = false; }
            //if (Tab13TextBoxB07.Text.Length == 0) { formulaireValide = false; }

            if (formulaireValide == true)
            {
                try
                {
                    string cnxString = "SERVER=" + Tab13TextBoxB02.Text + ";UID=" + Tab13TextBoxB03.Text + ";PASSWORD=" + Tab13PasswordBoxB04.Password;
                    if (Tab13TextBoxB05.Text.Length > 0) { cnxString += ";DATABASE=" + Tab13TextBoxB05.Text; }
                    if (Tab13TextBoxB06.Text.Length > 0) { cnxString += ";" + Tab13TextBoxB06.Text; }

                    Msg.Publication("Cnx: " + cnxString);

                    MySqlConnection cnx = new MySqlConnection(cnxString);
                    cnx.Open();

                    if (Tab13TextBoxB07.Text.Length > 0)
                    {
                        MySqlCommand query = new MySqlCommand(Tab13TextBoxB07.Text, cnx);
                        DataTable dt = new DataTable();
                        dt.Load(query.ExecuteReader());
                        Tab13DataGridC01.DataContext = dt;
                    }


                    cnx.Close();

                }
                catch (MySqlException ex)
                {
                    Msg.Publication("Une erreur est survenue." + ex.Message);
                }
            }
        }
    }
}
