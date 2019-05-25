using System;

namespace Model
{
    public enum Spol
    {
        Muski,
        Zenski
    }

    public abstract class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojLicneKarte { get; set; }
        public string JMBG { get; set; }
        public Spol Spol { get; set; }
        public string Lozinka { get; set; }
        public int Id { get; set; }
        public string Ulica { get; set; }
        public string Kanton { get; set; }
    
    }
}
