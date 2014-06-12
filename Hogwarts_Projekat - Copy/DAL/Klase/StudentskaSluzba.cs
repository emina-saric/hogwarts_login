using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class StudentskaSluzba
    {
        public StudentskaSluzba() { }
        
        List<Ucenik> _ucenici = new List<Ucenik>(); 
        
        List<Ucenik> _prefekti = new List<Ucenik>();
        List<Osoba> _clanovi_studentske = new List<Osoba>();
        List<Ucenik> _kapiteni = new List<Ucenik>();
     
        List<Predmet> _predmeti = new List<Predmet>();
        List<Kuca> _kuce = new List<Kuca>();


    }
}
