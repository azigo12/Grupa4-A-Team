using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class BirackoMjesto
    {
        public int ID { get; set; }
        public string Kanton { get; set; }
        public virtual ICollection<BirackoMjestoKandidat> BirackoMjestoKandidati { get; set; }
        //public virtual ICollection<Osoba> Osobe { get; set; }
    }
}
