using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Labo_template.agents;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletFormulaires.xaml
    /// </summary>
    public partial class ongletFormulaires : System.Windows.Controls.UserControl
    {
        public ongletFormulaires()
        {
            InitializeComponent();
            Msg.Publication("Initalisation de l'onglet 'Formulaires'...");
            Tab02ComboBoxB06.SelectedIndex = 1;
        }

        private void Tab02TextBoxB01_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show("plouf", "Your title", MessageBoxButton.OK);
            Tab02LabelC01.Content = "Texte: " + Tab02TextBoxB01.Text;
            Msg.Publication("Tab02TextBoxB01 -> texte modifié");
        }

        private void Tab02PasswordBoxB02_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Tab02LabelC02.Content = "password : " + Tab02PasswordBoxB02.Password;
            Msg.Publication("Tab02PasswordBoxB02 -> texte modifié");
        }
        private void Tab02TextBoxB03_TextChanged(object sender, TextChangedEventArgs e)
        {
            string check = "";
            if (!Regex.IsMatch(Tab02TextBoxB03.Text, @"^\d*$"))
            {
                Tab02TextBoxB03.Text = Regex.Replace(Tab02TextBoxB03.Text, @"\D", string.Empty);
                check = "Correction appliquée.";
            }
            Tab02LabelC03.Content = "Texte: " + Tab02TextBoxB03.Text + ". " + check;
            Msg.Publication("Tab02TextBoxB03 -> texte modifié");
        }

        private void Tab02CheckBoxB04_Click(object sender, RoutedEventArgs e)
        {
            Tab02LabelC04.Content = "L'état de la case à cocher est : " + Tab02CheckBoxB04.IsChecked;
            Msg.Publication("Tab02CheckBoxB04 -> modifié");
        }

        private void Tab02CheckBoxB05_Click(object sender, RoutedEventArgs e)
        {
            string state = "";
            switch (Tab02CheckBoxB05.IsChecked)
            {
                case null: state = "Intermediaire"; break;
                case true: state = "Cochée"; break;
                default: state = "Vide"; break;
            }
            Tab02LabelC05.Content = "L'état de la case à cocher est : " + state;
            Msg.Publication("Tab02CheckBoxB05 -> modifié");
        }

        private void Tab02ComboBoxB06_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)Tab02ComboBoxB06.SelectedItem;
            Tab02LabelC06.Content = "Index : " + Tab02ComboBoxB06.SelectedIndex + " / Texte : " + cbi.Content.ToString();
            Msg.Publication("Tab02LabelC06 -> texte modifié");
        }

        private void Tab02ButtonB07_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab02DatePickerB08_CalendarClosed(object sender, RoutedEventArgs e)
        {
            double ts = DateToTimeStamp(Tab02DatePickerB08.Text);
            Tab02LabelC08.Content = "Date : " + Tab02DatePickerB08.Text + " / TimeStamp : " + ts;
            Msg.Publication("Tab02DatePickerB08 -> texte modifié");
        }

        private void Tab02ColorPickerB09_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Tab02LabelC09.Content = Tab02ColorPickerB09.SelectedColor;
            Msg.Publication("Tab02ColorPickerB09 -> modifié");
        }


        private void Tab02ButtonB10_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Tab02LabelC10.Content = "#" + cd.Color.ToString();
                Msg.Publication("Tab02LabelC10 -> modifié");
            }
        }

        private void Tab02TextBoxB11_TextChanged(object sender, TextChangedEventArgs e)
        {
            Tab02TextBlockC11.Text = Tab02TextBoxB11.Text;
            Msg.Publication("Tab02TextBlockC11 -> texte modifié");
        }


        private double DateToTimeStamp(string dateStr)
        {
            DateTime date = DateTime.ParseExact(dateStr, "dd/MM/yyyy", null);
            Double timestamp = Math.Truncate((date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            return timestamp;
        }


        // https://stackoverflow.com/questions/28305153/how-convert-unix-timestamp-to-datetime
        //private string TimeStampToDateString (string dateStr)
        //{
        //    DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Unspecified);
        //    dtDateTime = dtDateTime.AddSeconds(Double.Parse(arrayFinalResponse[i, 5])).ToLocalTime();
        //    string date = dtDateTime.ToString("dd/MM/yyyy H:mm:ss", CultureInfo.GetCultureInfo("en-US"));
        //    return date;
        //}

    }
}
