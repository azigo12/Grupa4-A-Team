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

        public ICollection<int> glasovi { get; set; }


        public void DodajGlas(int glasackiListicId)
        {
            glasovi.Add(glasackiListicId);
        }
    }
}
