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
    class Izbor : IObservable, IIzborPrototip
    {
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        private List<GlasackiListic> opcije;
        public string Opis { get; set; }
        public string KantonOgranicenje { get; set; }
        public StatusIzbora Status { get; set; }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void Clone()
        {
            throw new NotImplementedException();
        }
    }
}
