using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public abstract class Izvjestaj
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public TipIzvjestaja Tip { get; set; }
    }
}
