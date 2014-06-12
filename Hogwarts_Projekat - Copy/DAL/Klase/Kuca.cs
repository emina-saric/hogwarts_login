using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Kuca
    {
        public Kuca(int id_kuca,string ime, int bodovi, int id_prof, int broj_ucenika)
        {
            Ime_kuce = ime;
            Bodovi = bodovi;
            Id_profesor = id_prof;
            Broj_ucenika = broj_ucenika;
            Id_kuca = id_kuca;
        }
        public string Ime_kuce { get; set; }
        public int Bodovi { get; set; }
        public int Id_profesor { get; set; }
        public int Broj_ucenika { get; set; }
        public int Id_kuca { get; set; }
        List<Ucenik> _ucenici_kuce = new List<Ucenik>();
        List<Ucenik> _prefekti = new List<Ucenik>();
        
        public int kuca_id { get; set; }

        public void DodajUcenika(Ucenik ucenik) {
            if (!_ucenici_kuce.Contains(ucenik)) _ucenici_kuce.Add(ucenik);
        }
        public void DodajPrefekta(Ucenik ucenik)
        {
                if (!_prefekti.Contains(ucenik)) _prefekti.Add(ucenik);
        }
   
        public void OduzmiBodove(int i) 
        {
            if (i > 0)
            {
                if (Bodovi < i) Bodovi = 0;
                else Bodovi -= i;
            }
        }
        public void DodajBodove(int i)
        {
            if (i > 0) Bodovi += i;

        }
    }

}
