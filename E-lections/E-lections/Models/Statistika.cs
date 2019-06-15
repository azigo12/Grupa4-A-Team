using System;
using System.Collections.Generic;
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

        public int GlasoviMusko { get; set; }
        public int GlasoviZensko { get; set; }
        public int GlasoviValidni { get; set; }
        public int GlasoviNevalidni { get; set; }
        public string GlasoviZaKanton { get; set; }

        [NotMapped]
        public IDictionary<string, int> Mapa { get; set; }

        public static string RemoveLast(string text, string character)
        {
            if (text.Length < 1) return text;
            return text.Remove(text.ToString().LastIndexOf(character), character.Length);
        }

        public string DajGlasove()
        {
            string rezultat = "";
            foreach (KeyValuePair<string, int> entry in Mapa)
            {
                rezultat += entry.Key + "," + entry.Value + "/";
            }

            RemoveLast(rezultat, "/");
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
