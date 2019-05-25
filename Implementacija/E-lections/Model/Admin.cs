using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Admin
    {
        public string JMBG { get; set; }
        public string Lozinka { get; set; }
        public int Id { get; set; }
        public IzvjestajFactory IzvjestajFactory;

        public Izvjestaj GenerisiIzvjestaj(string tipIzvjestaja)
        {
            throw new NotImplementedException();
        }

        public Izvjestaj GenerisiIzvjestaj22(string tipIzvjestaja)
        {
            throw new NotImplementedException();
        }
    }
}
