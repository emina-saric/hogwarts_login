

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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DAL.DAL d = null;
        public Window1()
        {
            this.InitializeComponent();
            try
            {
                d = DAL.DAL.Instanca;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // Insert code required on object creation below this point.
        }


        string getHouseName()
        {
            if (cbox_Gryffindor.IsSelected == true)
                return "Gryffindor";
            if (cbox_Slytherin.IsSelected == true)
                return "Slytherin";
            if (cbox_Hufflepuff.IsSelected == true)
                return "Hufflepuff";
            if (cbox_Ravenclaw.IsSelected == true)
                return "Ravenclaw";
            else
                return "";

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DAL.DAL.KucaDAO kdao = new DAL.DAL.KucaDAO();
            Kuca k = kdao.getByName(getHouseName());
            DAL.DAL.UcenikDAO udao = new DAL.DAL.UcenikDAO();
            bool x ;
            if(rb_DA.IsChecked == true) x=true;
            else x = false;

            DAL.Ucenik u = new DAL.Ucenik(0, tb_ime.Text, tb_prezime.Text, dat_rodj.SelectedDate.Value, tb_username.Text, tb_pass.Text, Convert.ToInt32(cb_gd_studija.Text), k.Id_kuca, x);
            udao.create(u);

        }
    }
}

