using Labo_template.agents;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletVideoVLC.xaml
    /// </summary>
    // https://github.com/ZeBobo5/Vlc.DotNet/wiki/Getting-started#getting-libvlc
    // https://www.telerik.com/support/kb/winforms/details/how-to-play-video-files

    public partial class ongletVideoVLC : UserControl
    {
        private float indexVideoBrute = 0;
        private double indexVideoEntier = 0;
        private float volumeSonBrute = 100;
        private double volumeSonEntier = 100;
        private String actionVLC = "";

        private long vlcMediaLength = 0;
        private float vlcMediaPositionMilliseconde = 0;
        private String calculEffectue = "";

        public ongletVideoVLC()
        {
            InitializeComponent();

            vlcPlayer.MediaPlayer.BeginInit();
            Msg.Publication("Initialisation de l'onglet 'Vidéo'...");
            vlcPlayer.MediaPlayer.VlcLibDirectoryNeeded += OnVlcControlNeedsLibDirectory;
            vlcPlayer.MediaPlayer.Log += (sender, args) => { System.Diagnostics.Debug.WriteLine(string.Format("libVlc : {0} {1} @ {2}", args.Level, args.Message, args.Module)); };
            vlcPlayer.MediaPlayer.EndInit();
        }

        private void OnVlcControlNeedsLibDirectory(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var assemblyCourant = Assembly.GetEntryAssembly();
            var repertoireCourantSolution = new FileInfo(assemblyCourant.Location).DirectoryName;
            if (repertoireCourantSolution == null) { return; }
            var version = "3.0.4";
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(repertoireCourantSolution, "lib", "vlc", version, IntPtr.Size == 4 ? "x86" : "x64"));
            Msg.Publication("Lib choisie: " + e.VlcLibDirectory);
        }

        // ---------------------------------------------------------------------------------------------------
        //
        // Section B
        //
        //
        private void Tab13SliderB01_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            indexVideoBrute = (float)Tab13SliderB01.Value;
            indexVideoEntier = Convert.ToInt16(indexVideoBrute);

            vlcMediaLength = vlcPlayer.MediaPlayer.Length;
            //long tsFloat = (long)new TimeSpan(0, 0, 0, 0, (int)indexVideoEntier).TotalMilliseconds;

            vlcMediaPositionMilliseconde = (float)vlcMediaLength * (float)indexVideoBrute;
            calculEffectue = vlcMediaLength + " * " + indexVideoBrute + " = " + vlcMediaPositionMilliseconde;
            vlcPlayer.MediaPlayer.Position = (float)indexVideoBrute;
            this.rafraichirTab13LabelC01();
        }

        private void Tab13SliderB02_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            volumeSonBrute = (float)Tab13SliderB02.Value;
            volumeSonEntier = Convert.ToInt16(volumeSonBrute);

            if (vlcPlayer.MediaPlayer.IsPlaying)
            {
                vlcPlayer.MediaPlayer.Audio.Volume = (int)volumeSonEntier;
            }
            this.rafraichirTab13LabelC01();
        }


        // ---------------------------------------------------------------------------------------------------
        //
        // Section C
        //
        //
        private void Tab13ButtonC01_Click(object sender, RoutedEventArgs e)
        {
            var interfaceSelecteurFichier = new Microsoft.Win32.OpenFileDialog();
            var newDestination = Environment.CurrentDirectory;

            if (interfaceSelecteurFichier.ShowDialog() == true)
            {
                try
                {
                    var fichierNomComplet = interfaceSelecteurFichier.FileName;
                    var fichierNom = Path.GetFileName(fichierNomComplet);
                    Msg.Publication("Sélection fichier : " + fichierNom + " (" + fichierNomComplet + ")");

                    var options = new string[] { "-vvv" };
                    Uri fUri = new Uri("file://" + fichierNomComplet);
                    vlcPlayer.MediaPlayer.Play(fUri, options);
                }
                catch (Exception ex)
                {
                    //Msg.Publication("Exception levée : " + ex.Message);
                    Msg.Publication("Exception levée : " + ex);
                }
            }
        }

        private void Tab13ButtonC02_Click(object sender, RoutedEventArgs e)
        {
            vlcPlayer.MediaPlayer.Play();
            Msg.Publication("VLC play");
            actionVLC = "Jouer";
            this.rafraichirTab13LabelC01();
        }

        private void Tab13ButtonC03_Click(object sender, RoutedEventArgs e)
        {
            vlcPlayer.MediaPlayer.Pause();
            Msg.Publication("VLC Pause");
            actionVLC = "Pause";
            this.rafraichirTab13LabelC01();
        }

        private void Tab13ButtonC04_Click(object sender, RoutedEventArgs e)
        {
            vlcPlayer.MediaPlayer.Stop();
            Msg.Publication("VLC Stop");
            actionVLC = "Stop";
            Tab13SliderB01.Value = 0;
            this.rafraichirTab13LabelC01();
        }

        private void rafraichirTab13LabelC01()
        {
            Tab13LabelC01.Content = "Curseur Video: " + indexVideoEntier + "\t\tPosition Video: " + vlcMediaPositionMilliseconde + "\t\tVolume: " + volumeSonEntier + "\t\tTaille:" + vlcMediaLength + "\nAction: " + actionVLC + "\t\tCalcul: " + calculEffectue;
        }


    }
}
