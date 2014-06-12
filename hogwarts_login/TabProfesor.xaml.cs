using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAL;

namespace hogwarts_login
{
	/// <summary>
	/// Interaction logic for TabProfesor.xaml
	/// </summary>
	public partial class TabProfesor : Window
	{
        public Profesor p;
        public Predmet predmet;
        public List<Ocjena> _ocjene = new List<Ocjena>();
		public TabProfesor(Profesor p)
		{
			this.InitializeComponent();
            this.p = p;
            PostaviPodatke();

		}
        public void PostaviPodatke()
        {
            
            DAL.DAL.PredmetDAO pdao = new DAL.DAL.PredmetDAO();
            predmet = pdao.getByIdProfesor(p.Id_profesor);
            lb_id_predmet.Content = Convert.ToString(predmet.Id_predmet);
            lb_broj_casova.Content = Convert.ToString(predmet.Broj_casova);
            //broj ucenika izracunati
            lb_naziv_predmeta.Content = predmet.Naziv;
            lb_prof.Content = p.Ime + " " + p.Prezime; 
        }
        public void NapuniGrid()
        {
            DAL.DAL.OcjenaDAO odao = new DAL.DAL.OcjenaDAO();
            _ocjene = odao.PretraziPoPredmetu(predmet.Id_predmet);
            foreach (Ocjena o in _ocjene)
            {
                gd_ocjene.Items.Add(o);
                
            }
        }
	}
}