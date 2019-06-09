using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public enum Spol
    {
        Muski,
        Zenski
    }

    public abstract class Osoba
    {

        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojLicneKarte { get; set; }
        public string JMBG { get; set; }
        public Spol Spol { get; set; }
        public string Lozinka { get; set; }
        public string Ulica { get; set; }
        public string Kanton { get; set; }

        //veze sa drugim tabelama
        public int StrankaId { get; set; }
        public virtual Stranka Stranka { get; set; }

        public int BirackoMjestoID { get; set; }
        public virtual BirackoMjesto BirackoMjesto { get; set; }


    }
}
