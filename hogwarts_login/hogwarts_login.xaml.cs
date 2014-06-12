

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
    /// Interaction logic for hogwarts_login_2.xaml
    /// </summary>
    public partial class hogwarts_login_2 : Window
    {
        DAL.DAL d = DAL.DAL.Instanca;
        private string kuca;
        public hogwarts_login_2(string kuca)
        {
            this.InitializeComponent();
            this.kuca = kuca;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void esc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (kuca != "Profesor")
            {
                string username = tb_username.Text;
                string password = tb_password.Text;
                DAL.DAL.UcenikDAO udao = new DAL.DAL.UcenikDAO();
                Ucenik u = udao.Prijava(username, password);
                if (u == null)
                {
                    MessageBox.Show("Ne postoji ucenik!");
                }
                else if (u != null)
                {
                    MessageBox.Show(u.Ime + " " + u.Prezime);
                    TabUcenik tu = new TabUcenik(u);
                    tu.Show();
                }
            }
            else if (kuca == "Profesor")
            {
                string username = tb_username.Text;
                string password = tb_password.Text;
                DAL.DAL.ProfesorDAO pdao = new DAL.DAL.ProfesorDAO();
                Profesor p = pdao.Prijava(username, password);
                if (p == null)
                {
                    MessageBox.Show("Ne postoji profesor!");
                }
                else if (p != null)
                {
                    MessageBox.Show(p.Ime + " " + p.Prezime);
                
                }
            }

        }

    }
}

