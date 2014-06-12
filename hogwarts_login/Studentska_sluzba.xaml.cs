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

namespace hogwarts_login
{
	/// <summary>
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window
	{
		public Window2()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 dodavanje_ucenika = new Window1();
            dodavanje_ucenika.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GridWindow gw = new GridWindow();
            gw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Profesor_dodavanje pd = new Profesor_dodavanje();
            pd.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Grid_profesori gp = new Grid_profesori();
            gp.Show();
        }
	}
}