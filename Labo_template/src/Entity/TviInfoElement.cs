using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_template.src.Entity
{
    class TviInfoElement
    {
        public TviInfoElement (string type, string chemin, string nom, long taille, string extension)
        {
            this.Type = type;
            this.Chemin = chemin;
            this.Nom = nom;
            this.Taille = taille.ToString();
            this.Extension = extension;
        }

        public string Type { get; set; }
        public string Chemin { get; set; }
        public string Nom { get; set; }
        public string Taille { get; set; }
        public string Extension { get; set; }
    }
}
