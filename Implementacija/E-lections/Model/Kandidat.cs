using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Kandidat : KandidatDecorator, IUcesnik
    {
        private int brojGlasova;

        public void DodajGlas()
        {
            throw new NotImplementedException();
        }

        public void PrijaviIzbore(int idIzbora, int idListica)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
