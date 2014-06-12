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
    /// Interaction logic for GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {
        List<Ucenik> _ucenici = new List<Ucenik>();
        public GridWindow()
        {
            InitializeComponent();
            
            DAL.DAL.UcenikDAO udao = new DAL.DAL.UcenikDAO();
            _ucenici = udao.getAll();
            grid_ucenici.ItemsSource = _ucenici;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //Spasi promjene button
            DAL.DAL.UcenikDAO udao = new DAL.DAL.UcenikDAO();
            udao.ObrisiSve();
            foreach (Ucenik u in _ucenici)
            {
                udao.create(u);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //ID radio_button
            tb_search.Visibility = Visibility.Visible;
            

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //ime radio_button
            tb_search.Visibility = Visibility.Visible;
  
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            grid_ucenici.ItemsSource = null;
            List<Ucenik> _ucenici_pomocna = new List<Ucenik>();
            grid_ucenici.ItemsSource = _ucenici_pomocna;
            
            if (tb_search.Text == null)
            {
                grid_ucenici.ItemsSource = null;
                grid_ucenici.ItemsSource = _ucenici;

            }
            
            if (rb_ime.IsChecked == true)
            {
                foreach (Ucenik u in _ucenici)
                {
                    if (u.Ime.Contains(tb_search.Text))
                        _ucenici_pomocna.Add(u);
                }
            }
            if (rb_ID.IsChecked == true)
            {
                foreach (Ucenik u in _ucenici)
                {
                    int n;
                    if (int.TryParse(tb_search.Text, out n))
                    {
                        if (u.Id_ucenik == n)
                            _ucenici_pomocna.Add(u);
                    }
                    else 
                    {
                        grid_ucenici.ItemsSource = null;
                        grid_ucenici.ItemsSource = _ucenici;

                    }
                }
            }

        }

    }
}
