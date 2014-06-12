using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Ucenik : Osoba
    {


       public  Ucenik(int id_ucenik, string ime, string prezime, DateTime datum_rodjenja, string username, string password, int godina_studija, int id_kuca,bool prefekt)
            : base(ime, prezime, datum_rodjenja, username, password)
        {
            Id_ucenik = id_ucenik;
            Godina_studija = godina_studija;
            Id_kuca = id_kuca;
            Prefekt = prefekt;
        }

        public int Godina_studija { get; set; }
        public bool Prefekt { get; set; }
        public int Id_ucenik { get; set; }
        public int Id_kuca { get; set; }
        
        public void PovecajGodinuStudija()
        {
            if (Godina_studija > 1 && Godina_studija < 7) Godina_studija++;
        }
        public void PostaviZaPrefekta()
        {
            if (Godina_studija > 4) Prefekt = true;
        }

    }
}
