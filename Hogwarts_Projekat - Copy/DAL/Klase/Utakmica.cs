using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Utakmica
    {
       public  Utakmica(int id_utakmica, DateTime termin, int id_tim1, int id_tim2 , int bod1 = 0, int bod2 = 0, bool odigrana = false)
        {
            Id_utakmica = id_utakmica;
            Termin = termin;
            Id_tim1 = id_tim1;
            Id_tim2 = id_tim2;
            Bodovi1 = bod1;
            Bodovi2 = bod2;
            Odigrana = odigrana;
        }
        public DateTime Termin { get; set; }
        public int Id_tim1  { get; set; }
        public int Id_tim2 { get; set; }
        public int Bodovi1 { get; set; }
        public int Bodovi2 { get; set; }
        public bool Odigrana { get; set; }
        public int Id_utakmica { get; set; }


        public void OdigranaUtakmica(int bod1, int bod2)
        {
            if (bod1 > 0 && bod2 > 0 && Termin < DateTime.Now)
            {
                Bodovi1 = bod1;
                Bodovi2 = bod2;
                Odigrana = true;
              
            }
        }
        public void PromjeniTermin(DateTime novi_termin)
        {
            if (novi_termin > DateTime.Now)
            {
                Termin = novi_termin;
            }
        }
    }
}
