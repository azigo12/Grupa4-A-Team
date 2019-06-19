using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_lections.Models
{
    public class Statistika
    {
        public int ID { get; set; }
        public int IzborId { get; set; }
        public virtual Izbor Izbor { get; set; }
        [Display(Name = "Glasovi M")]
        public int GlasoviMusko { get; set; }
        [Display(Name = "Glasovi Ž")]
        public int GlasoviZensko { get; set; }
        [Display(Name = "Validni glasovi")]
        public int GlasoviValidni { get; set; }
        [Display(Name = "Nevalidni glasovi")]
        public int GlasoviNevalidni { get; set; }
        public string GlasoviZaKanton { get; set; }

        public bool Visible { get; set; } = false;

        [NotMapped]
        public IDictionary<string, int> Mapa { get; set; } = new Dictionary<string, int>();

        /*public static string RemoveLast(string text, string character)
        {
            if (text.Length < 1) return text;
            return text.Remove(text.ToString().LastIndexOf(character), character.Length);
        }*/

        public string DajGlasove()
        {
            string rezultat = "";
            foreach (KeyValuePair<string, int> entry in Mapa)
            {
                rezultat += entry.Key + "," + entry.Value + "/";
            }
            rezultat = rezultat.Substring(0, rezultat.Length - 1);
           // RemoveLast(rezultat, "/");
            return rezultat;
        }

        public void ZabiljeziGlasove(string glasovi)
        {
            string[] kantonGlas = glasovi.Split('/');
            foreach(string s in kantonGlas)
            {
                string[] tmp = s.Split(',');
                Mapa.Add(tmp[0], Int32.Parse(tmp[1]));
            }
        }

    }
}
