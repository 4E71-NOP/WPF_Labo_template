using Labo_template.agents;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Vlc.DotNet.Wpf;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletVideoVLC.xaml
    /// </summary>
    public partial class ongletVideoVLC : UserControl
    {
        VlcControl vlcPlayer = new VlcControl();


        public ongletVideoVLC()
        {
            InitializeComponent();

            vlcPlayer.MediaPlayer.BeginInit();

            Msg.Publication("Initialisation de l'onglet 'Vidéo'...");
            vlcPlayer.MediaPlayer.VlcLibDirectoryNeeded += OnVlcControlNeedsLibDirectory;
            vlcPlayer.MediaPlayer.Log += (sender, args) => { System.Diagnostics.Debug.WriteLine(string.Format("libVlc : {0} {1} @ {2}", args.Level, args.Message, args.Module)); };

            vlcPlayer.MediaPlayer.EndInit();
            gridTab13.Children.Add(vlcPlayer);

        }

        private void OnVlcControlNeedsLibDirectory(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var assemblyCourant = Assembly.GetEntryAssembly();
            var repertoireCourantSolution = new FileInfo(assemblyCourant.Location).DirectoryName;
            if (repertoireCourantSolution == null) { return; }
            var version = "3.0.0";
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(repertoireCourantSolution, "lib", "vlc", version, IntPtr.Size == 4 ? "x86" : "x64"));
            Msg.Publication("Lib choisie: " + e.VlcLibDirectory);
        }

        private void Tab13ButtonA01_Click(object sender, RoutedEventArgs e)
        {
            var interfaceSelecteurFichier = new Microsoft.Win32.OpenFileDialog();
            var newDestination = Environment.CurrentDirectory;

            if (interfaceSelecteurFichier.ShowDialog() == true)
            {
                try
                {
                    // https://github.com/ZeBobo5/Vlc.DotNet/wiki/Getting-started#getting-libvlc
                    // https://www.telerik.com/support/kb/winforms/details/how-to-play-video-files

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

        private void Tab13ButtonB01_Click(object sender, RoutedEventArgs e)
        {
            vlcPlayer.MediaPlayer.Play();
            Msg.Publication("VLC play");
        }
        private void Tab13ButtonB02_Click(object sender, RoutedEventArgs e)
        {
            vlcPlayer.MediaPlayer.Stop();
            Msg.Publication("VLC Stop");

        }

    }
}
