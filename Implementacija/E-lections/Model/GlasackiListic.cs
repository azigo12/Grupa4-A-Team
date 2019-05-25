using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class GlasackiListic : IObserver
    {
        public int Id { get; set; }
        public int MaxOdabir { get; set; }
        public int BrojGlasova { get; set; }
        public string Opis { get; set; }
        private List<Kandidat> izbor;

        public virtual Izbor Izbor { get; set; }        public virtual ICollection<Kandidat> Kandidati { get; set; }

        public void RegistrujUcesnika(IUcesnik ucesnik)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
