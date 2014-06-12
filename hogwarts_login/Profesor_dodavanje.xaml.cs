using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Profesor_dodavanje.xaml
    /// </summary>
    public partial class Profesor_dodavanje : Window
    {
        public Profesor_dodavanje()
        {
            InitializeComponent();
        }

        private void b_spasi_ucenika_Click(object sender, RoutedEventArgs e)
        {
            bool x;
            if(rb_DA.IsChecked == true) x=true;
            else x = false;
            DAL.DAL.ProfesorDAO pdao = new DAL.DAL.ProfesorDAO();
            Profesor p = new Profesor(0, tb_ime.Text, tb_prezime.Text, dat_rodj.SelectedDate.Value, tb_username.Text, tb_pass.Text, x);
            pdao.create(p);
        }
    }
}
