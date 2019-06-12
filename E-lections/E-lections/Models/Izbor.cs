using System;
using System.Collections.Generic;
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
        public DateTime Pocetak { get; set; }
        private List<GlasackiListic> opcije;
        public string Opis { get; set; }
        public string KantonOgranicenje { get; set; }
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
