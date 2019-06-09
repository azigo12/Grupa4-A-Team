using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class BirackoMjestoKandidat
    {
        public int ID { get; set; }
        public int BrojGlasova { get; set; }


        //veze sa drugim tabelama (many to many veza izmedju klasa Kandidat i BirackoMjesto
        //public int? BirackoMjestoId { get; set; }
        //public virtual BirackoMjesto BirackoMjesto { get; set; }

        public int KandidatId { get; set; }
        public virtual Kandidat Kandidat { get; set; }
    }
}
