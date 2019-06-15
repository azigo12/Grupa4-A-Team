using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class Statistika
    {
        public int ID { get; set; }
        public int IzborId { get; set; }
        public virtual Izbor Izbor { get; set; }

        public int GlasoviMusko { get; set; }
        public int GlasoviZensko { get; set; }
        public int GlasoviValidni { get; set; }
        public int GlasoviNevalidni { get; set; }
        public IDictionary<string, int> GlasoviZaKanton { get; set; }
    }
}
