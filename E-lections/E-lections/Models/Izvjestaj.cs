using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public enum TipIzvjestaja
    {
        IzvjestajSpol,
        IzvjestajKanton,
        IzvjestajKandidat
    }

    public abstract class Izvjestaj
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public TipIzvjestaja Tip { get; set; }
    }
}
