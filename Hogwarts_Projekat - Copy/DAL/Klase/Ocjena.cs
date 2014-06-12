using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Ocjena
    {
        public Ocjena(int id_ocjena, int _ocjena, bool polagao_ispit, bool polozio, int minusi, int bodovi, int id_ucenik, int id_predmet)
        {
            Id_ocjena = id_ocjena;
            _Ocjena = _ocjena;
            Polagao_ispit = polagao_ispit;
            Polozio = polozio;
            Minusi = minusi;
            Bodovi = bodovi;
            Id_ucenik = id_ucenik;
            Id_predmet = id_predmet;

        }
        public int Id_ocjena { get; set; }
        public int _Ocjena { get; set; }
        public bool Polagao_ispit { get; set; }
        public bool Polozio { get; set; }
        public int Minusi { get; set; }
        public int Bodovi { get; set; }
        public int Id_ucenik { get; set; }
        public int Id_predmet { get; set; }

    }
}
