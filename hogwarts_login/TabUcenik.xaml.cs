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
	/// Interaction logic for TabUcenik.xaml
	/// </summary>
	public partial class TabUcenik : Window
	{
        private DAL.Ucenik u;

        public TabUcenik(DAL.Ucenik u)
        {
            this.InitializeComponent();
            this.u = u;
            PopuniPodatke(u);
            List<Predmeti_ucenik> _predmeti = new List<Predmeti_ucenik>();
            _predmeti = PokupiOcjene(u);
            gr_predmeti.ItemsSource = _predmeti;
        }
        public void PopuniPodatke(Ucenik u)
        {
            lb_ime.Content = u.Ime;
            lb_prezime.Content = u.Prezime;
            lb_godina_studija.Content = u.Godina_studija;
            lb_datum_rodjenja.Content = Convert.ToString(u.Datum_rodjenja);
            ___No_Name_lb_username.Content = u.Username;
            DAL.DAL.KucaDAO kdao = new DAL.DAL.KucaDAO();
            Kuca k = kdao.getById(u.Id_kuca);
            lb_kuca.Content = k.Ime_kuce;
        }
        public List<Predmeti_ucenik> PokupiOcjene(Ucenik u)
        {
            DAL.DAL.OcjenaDAO odao = new DAL.DAL.OcjenaDAO();
            List<Ocjena> _ocjene = new List<Ocjena>();
            _ocjene = odao.PretraziPoUceniku(u.Id_ucenik);
            DAL.DAL.PredmetDAO pdao = new DAL.DAL.PredmetDAO();
            List<Predmeti_ucenik> _predmeti = new List<Predmeti_ucenik>();
            foreach (Ocjena o in _ocjene)
            { 
                Predmet p =  pdao.getById(o.Id_predmet);
                string ime = p.Naziv;
                _predmeti.Add(new Predmeti_ucenik(ime, o.Bodovi, o.Minusi, o.Polozio, o.Polagao_ispit, o._Ocjena));
            }
            return _predmeti;
        }

	}
}