using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Stranka
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        private List<Osoba> Clanovi;

        public virtual ICollection<Osoba> UpisiUStranku { get; set; }

        public void DodajClana(Osoba o)
        {
            if(!Clanovi.Contains(o))
            {
                Clanovi.Add(o);
            }
        }

        public void IzbaciClana(int id)
        {
            foreach(Osoba o in Clanovi)
            {
                if (o.Id == id) Clanovi.Remove(o);
            }
        }




    }
}
