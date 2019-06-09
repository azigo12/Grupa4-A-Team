using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class Stranka
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        private List<Osoba> clanovi;

        //veze
        public virtual ICollection<Osoba> UpisiUStranku { get; set; }


        public void DodajClana(Osoba o)
        {
            if (!clanovi.Contains(o))
            {
                clanovi.Add(o);
            }
        }

        public void IzbaciClana(int id)
        {
            foreach (Osoba o in clanovi)
            {
                if (o.ID == id) clanovi.Remove(o);
            }
        }
    }
}
