using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    interface IAdmin
    {
        Admin KreirajAdmina();
        void IzbrisiPrivilegije(int id);
    }
}
