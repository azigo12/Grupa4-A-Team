using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    enum StatusIzbora
    {
        Aktivan,
        Neaktivan
    }
    public class Izbor : IObservable, IIzborPrototip
    {
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        private List<GlasackiListic> opcije;
        public string Opis { get; set; }
        public string KantonOgranicenje { get; set; }
        public StatusIzbora Status { get; set; }

        public virtual ICollection<GlasackiListic> GlasackiListici { get; set; }

        public void Notify()
        {
            //throw new NotImplementedException();
            foreach(GlasackiListic gl in opcije)
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
