using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Drawing;

namespace Model
{
    class Profil
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string PutanjaSlike { get; set; }

        public virtual Kandidat Kandidat { get; set; }


    }
}
