﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class Stranka
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        //veze
        public virtual ICollection<Osoba> UpisiUStranku { get; set; } 


        public void DodajClana(Osoba o)
        {
            //TODO
        }

        public void IzbaciClana(int id)
        {
            //TODO
        }
    }
}
