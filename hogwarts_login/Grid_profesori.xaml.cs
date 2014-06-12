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
    /// Interaction logic for Grid_profesori.xaml
    /// </summary>
    public partial class Grid_profesori : Window
    {
        List<Profesor> _profesori = new List<Profesor>();
        public Grid_profesori()
        {
            InitializeComponent();
            DAL.DAL.ProfesorDAO pdao = new DAL.DAL.ProfesorDAO();
            _profesori = pdao.getAll();
            grid_profesori.ItemsSource = null;
            grid_profesori.ItemsSource = _profesori;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            tb_search.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            tb_search.Visibility = Visibility.Visible;
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            grid_profesori.ItemsSource = null;
            List<Profesor> _profesori_pomocna = new List<Profesor>();
            grid_profesori.ItemsSource = _profesori_pomocna;

            if (tb_search.Text == null)
            {
                grid_profesori.ItemsSource = null;
                grid_profesori.ItemsSource = _profesori;

            }

            if (rb_ime.IsChecked == true)
            {
                foreach (Profesor u in _profesori)
                {
                    if (u.Ime.Contains(tb_search.Text))
                        _profesori_pomocna.Add(u);
                }
            }
            if (rb_ID.IsChecked == true)
            {
                foreach (Profesor u in _profesori)
                {
                    int n;
                    if (int.TryParse(tb_search.Text, out n))
                    {
                        if (u.Id_profesor == n)
                            _profesori_pomocna.Add(u);
                    }
                    else
                    {
                        grid_profesori.ItemsSource = null;
                        grid_profesori.ItemsSource = _profesori;

                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Spasi promjene button
            DAL.DAL.ProfesorDAO pdao = new DAL.DAL.ProfesorDAO();
            pdao.ObrisiSve();
            foreach (Profesor p in _profesori)
            {
                pdao.create(p);
            }
        }



    }
}
