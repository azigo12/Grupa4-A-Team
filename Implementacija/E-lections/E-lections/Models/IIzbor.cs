using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    interface IIzbor
    {
        IIzbor KreirajIzbor();
        void ObrisiIzbor(int id);
    }
}
