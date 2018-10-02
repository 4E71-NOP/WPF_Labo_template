using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_template.Entity
{
    class User
    {

        public User(string n, string p, int a)
        {
            this.Nom = n;
            this.Prenom = p;
            this.Age = a;
            this.Mail = n + "." + p + "@faketelco.com";
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }

        public override string ToString()
        {
            return Nom + "," + Prenom + ", " + Age + " (" + Mail + ")";
        }

    }
}
