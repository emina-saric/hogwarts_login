using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MetlobojskaEkipa
    {
        public MetlobojskaEkipa(int id_tim, int id_kuce, int id_kapiten, int boodovi) 
        {
            Id_tim = id_tim;
            Id_kuca = id_kuce;
            Id_kapiten = id_kapiten;
            Bodovi = boodovi;
            
        }
        public int Id_tim { get; set; }
        public int Id_kuca { get; set; }
        public int Id_kapiten { get; set; }
        public int Bodovi {get; set;}
        

        public void EvidentirajBodove(int i) 
        {
            Bodovi += i;

        }
    }
}
