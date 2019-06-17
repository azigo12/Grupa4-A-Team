using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class Profil
    {

        public int ID { get; set; }
        [Display(Name = "Opis profila")]
        public string Opis { get; set; }
        public string PutanjaSlike { get; set; }

        public virtual Kandidat Kandidat { get; set; }

    }
}
