using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class GlasackiListic : IObserver
    {
        public int ID { get; set; }
        public int MaxOdabir { get; set; }
        public int BrojGlasova { get; set; }
        public string Opis { get; set; }
        private List<IUcesnik> prijavljeni;


        public virtual Izbor Izbor { get; set; }
        public int IzborId { get; set; }

        public virtual ICollection<Kandidat> Kandidati { get; set; }


        public void RegistrujUcesnika(IUcesnik ucesnik)
        {
            //throw new NotImplementedException();
            prijavljeni.Add(ucesnik);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
