using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public enum StatusIzbora
    {
        Aktivan,
        Neaktivan
    }

    public class Izbor : IObservable, IIzborPrototip 
    {
        public int ID { get; set; }
        [Required, Display(Name = "Početak izbora")]
        public DateTime Pocetak { get; set; }
        [Required, Display(Name = "Opis"), MaxLength(200)]
        public string Opis { get; set; }
        [Required, Display(Name = "Kanton")]
        public string KantonOgranicenje { get; set; }
        [Display(Name = "Status"), Required]
        public StatusIzbora Status { get; set; }

        //veze sa drugim tabelama
        public virtual ICollection<GlasackiListic> GlasackiListici { get; set; }

        public void Notify()
        {
            //throw new NotImplementedException();
            foreach (GlasackiListic gl in opcije)
            {
                gl.Update();
            }
        }

        public void Clone()
        {
            throw new NotImplementedException();
        }
    }
}
