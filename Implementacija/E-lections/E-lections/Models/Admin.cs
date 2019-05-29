using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Admin : IAdmin, IIzbor, IStranka
    {
        public int Id { get; set; }
        public string JMBG { get; set; }
        public string Lozinka { get; set; }
        public int Id { get; set; }
        public IzvjestajFactory IzvjestajFactory;

        public Izvjestaj GenerisiIzvjestaj(string tipIzvjestaja)
        {
            throw new NotImplementedException();
        }


        public Admin KreirajAdmina()
        {
            throw new NotImplementedException();
        }

        public void IzbrisiPrivilegije(int id)
        {
            throw new NotImplementedException();
        }

        public IIzbor KreirajIzbor()
        {
            throw new NotImplementedException();
        }

        public void ObrisiIzbor(int id)
        {
            throw new NotImplementedException();
        }

        public Stranka KreirajStranku()
        {
            throw new NotImplementedException();
        }

        public void IzbrisiStranku()
        {
            throw new NotImplementedException();
        }
    }
}
