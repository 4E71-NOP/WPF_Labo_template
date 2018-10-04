using Labo_template.agents;
using Labo_template.src.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Labo_template.ihm
{
    /// <summary>
    /// Logique d'interaction pour ongletTreeView.xaml
    /// </summary>
    public partial class ongletTreeView : System.Windows.Controls.UserControl
    {
        public ongletTreeView()
        {
            InitializeComponent();
        }
        

        private void Tab06ButtonA01_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog selecteurRepertoire = new FolderBrowserDialog();
            if (selecteurRepertoire.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Msg.Publication("Répertoire sélectionné: " + selecteurRepertoire.SelectedPath);

                Tab06TreeViewA02.Items.Clear();
                foreach (TreeViewItem nouvelItem in ScanRepertoire(selecteurRepertoire.SelectedPath))
                {
                    Tab06TreeViewA02.Items.Add(nouvelItem);
                }
            }
        }

        //-----------------------------------------------------------------------------
        //
        // TreeView en mode "lazy load"
        // Pour fonctionner le XAML doit avoir la mention dans le treeview : TreeViewItem.Expanded="methode_a_exec"
        //
        //

        private TreeViewItem CreateTreeItem(string type, string chemin, string nom, long taille, string extension)
        {
            TreeViewItem item = new TreeViewItem();
            Uri iconeImage = null;
            switch (type)
            {
                case "D":
                    item.Items.Add("Loading...");
                    iconeImage = new Uri("pack://application:,,/src/ressources/media/img/animale-staroffice-summerbird-icone-6155-128.png");
                    break;
                case "F":
                    iconeImage = new Uri("pack://application:,,/src/ressources/media/img/shutdown-icone-6319-128.png");
                    break;
            }
            string[] strTag = { chemin, nom, taille.ToString(), extension, type };

            TviInfoElement infos = new TviInfoElement(type, chemin, nom, taille, extension);
            item.Tag = infos;
            Msg.Publication(infos.ToString());

            StackPanel stack = new StackPanel();
            stack.Orientation = System.Windows.Controls.Orientation.Horizontal;

            Image image = new Image();
            image.Source = new BitmapImage(iconeImage);
            image.Width = 16;
            image.Height = 16;

            System.Windows.Controls.Label lbl = new System.Windows.Controls.Label();
            lbl.Content = nom;

            stack.Children.Add(image);
            stack.Children.Add(lbl);
            item.Header = stack;
            return item;
        }


        private List<TreeViewItem> ScanRepertoire(string path)
        {
            Msg.Publication("Evennement TreeViewItem_Expanded : " + path);
            List<TreeViewItem> listItems = new List<TreeViewItem>();
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (DirectoryInfo d in di.GetDirectories()) { listItems.Add(CreateTreeItem("D", d.FullName, d.Name, 0, "")); }
            foreach (FileInfo f in di.GetFiles())
            {
                if (Regex.IsMatch(f.Extension, @"^\.(jpg|jpeg|gif|png|bmp|tif|tiff)"))
                {
                    listItems.Add(CreateTreeItem("F", f.FullName, f.Name, f.Length, f.Extension));
                }
            }
            return listItems;
        }

        public void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            Msg.Publication("Evennement TreeViewItem_Expanded");
            TreeViewItem item = e.Source as TreeViewItem;
            TviInfoElement infos = (TviInfoElement)item.Tag;

            switch (infos.Type)
            {
                case "D":
                    item.Items.Clear();
                    foreach (TreeViewItem nouvelItem in ScanRepertoire(infos.Chemin))
                    {
                        item.Items.Add(nouvelItem);
                    }
                    break;
                case "F":
                    ongletImage oImg = ongletImage.Instance;
                    oImg.Tab07ImageB01.Source = new BitmapImage(new Uri(infos.Chemin));
                    Msg.Publication("Ouverture fichier : " + infos.Chemin);
                    break;
            }
        }

    }
}
