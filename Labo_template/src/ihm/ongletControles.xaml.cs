using Labo_template.src.agents;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletControles.xaml
    /// </summary>
    public partial class ongletControles : UserControl
    {
        public ongletControles()
        {
            InitializeComponent();

            // --------------------------------------------------------------------------------------------------------------------------
            // Initialisation d'un couplage de données en version programmatique.
            // 'Path' ne doit pas être Element.value mais seulement 'Value'
            // Source doit pointer sur l'objet un rang avant la valeur demandée: Classe.Element. Ici this.Tab03SliderA05.
            Binding Tab03SliderA05_Tab03LabelB06_Binding = new Binding()
            {
                Source = this.Tab03SliderA05,
                Path = new PropertyPath("Value"),
                Delay = 300
            };
            Tab03LabelB06.SetBinding(Label.ContentProperty, Tab03SliderA05_Tab03LabelB06_Binding);
            // --------------------------------------------------------------------------------------------------------------------------
            // hmmmmmmm!!!
            //TimerAdd ta = new TimerAdd();
            //ta.AddTimerOnSliderInit(Tab03SliderA07);

        }


        // A REGARDER 
        //private System.Windows.Threading.DispatcherTimer timer;
        //private void TextBoxKeyDownEventHandler()
        //{
        //    if (timer != null)
        //        timer.Stop();

        //    timer = new System.Windows.Threading.DispatcherTimer();
        //    timer.Tick += (s, args) =>
        //    {
        //        //fetch data here...
        //        timer.Stop();
        //    };
        //    timer.Interval = TimeSpan.FromMilliseconds(500);
        //    timer.Start();
        //}

        private void Tab03SliderA01_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double valBrute = Tab03SliderA01.Value;
            double valEntier = Convert.ToInt16(Tab03SliderA01.Value);
            Tab03LabelB01.Content = "Géré via évennement\nValeur brute : " + valBrute;
            Tab03LabelB02.Content = "Valeur Entier : " + valEntier;
            Tab03ProgressBarA02.Value = Tab03SliderA01.Value;
        }

        private void Tab03SliderA07_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Crée un Processus.
            // Il faut utiliser Application.Current.Dispatcher.Invoke afin de créer un processus dans la liste des processus et non pas de l'exécuter immédiatement. 
            // ce qui peut provoquer des exception portant sur le verouillage des ressource (comme Tab03LabelB07) qui est déjà en cours d'usage. 
            Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Tab03LabelB07.Content = "Valeur = " + Tab03SliderA07.Value;
                    Tab03ProgressBarA08.Value = Convert.ToInt16(Tab03SliderA07.Value);
                });
            });
        }
    }
}
