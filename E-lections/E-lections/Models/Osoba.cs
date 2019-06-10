using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Unesite ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite prezime")]
        public string Prezime { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage = "Unesit datum rođenja")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Unesite broj lične karte"),StringLength(9)]
        public string BrojLicneKarte { get; set; }
        [Required(ErrorMessage = "Unesite svoj JMBG"), StringLength(13)]
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
