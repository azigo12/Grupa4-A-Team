using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class HistorijaGlasanja
    {
        public int ID { get; set; }

        public int OsobaId { get; set; }
        public virtual Osoba Osoba {get; set;}

        //public ICollection<int> glasovi { get; set; }
        public string glasovi { get; set; }

        public void DodajGlas(int glasackiListicId)
        {
            glasovi += glasackiListicId + ",";
        }

        public IList<int> DajGlasove()
        {
            glasovi = glasovi.Substring(0, glasovi.Length - 1);
            string[] niz = glasovi.Split(',');
            IList<int> lista = new List<int>();
            for(int i = 0; i < niz.Length; i++)
            {
                lista.Add(Int32.Parse(niz[i]));
            }

            return lista;
        }
    }
}
