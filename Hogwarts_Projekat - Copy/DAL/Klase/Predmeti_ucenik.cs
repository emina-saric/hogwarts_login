using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Predmeti_ucenik
    {
        public Predmeti_ucenik(string ime_predmeta, int bodovi, int minusi, bool polozio, bool polagao, int ocjena)
        {
            Ime_predemta = ime_predmeta;
            Bodovi = bodovi;
            Minusi = minusi;
            Polozio = polozio;
            Polagao = polagao;
            _Ocjena = ocjena;
        }

        public string Ime_predemta { get; set; }

        public int Bodovi { get; set; }

        public int Minusi { get; set; }

        public bool Polozio { get; set; }

        public bool Polagao { get; set; }

        public int _Ocjena { get; set; }
    }
}
