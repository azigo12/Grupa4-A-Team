using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public enum StatusIzbora
    {
        [Display(Name = "AKTIVAN")]
        Aktivan,
        [Display(Name = "NEAKTIVAN")]
        Neaktivan
    }

    public class Izbor : IObservable, IIzborPrototip 
    {
        public int ID { get; set; }
        [Required, Display(Name = "Početak")]
        public DateTime Pocetak { get; set; }
        [Required, MaxLength(200), Display(Name = "Opis")]
        public string Opis { get; set; }
        [Required, Display(Name = "Kanton")]
        public string KantonOgranicenje { get; set; }
        [Required, Display(Name = "Status")]
        public StatusIzbora Status { get; set; }

        //veze sa drugim tabelama
        public virtual ICollection<GlasackiListic> GlasackiListici { get; set; }

        public void Notify()
        {
            //throw new NotImplementedException();
            foreach (GlasackiListic gl in GlasackiListici)
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
