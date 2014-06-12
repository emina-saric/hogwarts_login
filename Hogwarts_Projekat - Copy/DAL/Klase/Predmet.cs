using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class Predmet
    {
        public Predmet(int id_predmet,string naziv, int casovi, int id_profesor )
        {
            Naziv = naziv;
            Broj_casova = casovi;
            Id_profesor = id_profesor;
            Id_predmet = id_predmet;

        }
        public string Naziv { get; set; }
        public int Id_profesor { get; set; }
        public int Broj_casova { get; set; }
        public int Id_predmet { get; set; }
    
    }
}
