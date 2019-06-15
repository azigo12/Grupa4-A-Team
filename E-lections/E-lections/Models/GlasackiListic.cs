using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class GlasackiListic : IObserver
    {
        public int ID { get; set; }
        [Required]
        public int MaxOdabir { get; set; }
        public int BrojGlasova { get; set; }
        [Required, MaxLength(100)]
        public string Opis { get; set; }
        public int HistorijaId { get; set; }
        public virtual HistorijaGlasanja HistorijaGlasanja {get; set;}


        public virtual Izbor Izbor { get; set; }
        public int IzborId { get; set; }

        public virtual ICollection<Kandidat> Kandidati { get; set; }


        public void RegistrujUcesnika(IUcesnik ucesnik)
        {
            //throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
