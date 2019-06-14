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
        [Required(ErrorMessage = "Unesite ime"), Display(Name = "Ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite prezime"), Display(Name = "Prezime")]
        public string Prezime { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage = "Unesit datum rođenja"), Display(Name = "Datum rođenja")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Unesite broj lične karte"),StringLength(9), Display(Name = "Broj lične karte")]
        public string BrojLicneKarte { get; set; }
        [Required(ErrorMessage = "Unesite svoj JMBG"), StringLength(13), Display(Name = "JMBG")]
        public string JMBG { get; set; }
        [Display(Name = "Spol")]
        public Spol Spol { get; set; }
        [Display(Name = "Lozinka")]
        public string Lozinka { get; set; }
        [Display(Name = "Ulica")]
        public string Ulica { get; set; }
        [Display(Name = "Kanton")]
        public string Kanton { get; set; }

        //veze sa drugim tabelama
        public int? StrankaId { get; set; }
        public virtual Stranka Stranka { get; set; }

        public int? BirackoMjestoID { get; set; }
        public virtual BirackoMjesto BirackoMjesto { get; set; }


    }
}
