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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hogwarts_login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	this.DragMove();
        }

        private void esc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();
		}
        private void button_gry_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	hogwarts_login_2 login2=new hogwarts_login_2("Gryffindor");
            login2.Show();
            this.Close();
        }
		private void button_rav_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	hogwarts_login_2 login2=new hogwarts_login_2("Ravenclaw");
            login2.Show();
            this.Close();
        }
		private void button_huff_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	hogwarts_login_2 login2=new hogwarts_login_2("Hufflepuff");
            login2.Show();
            this.Close();
        }
		private void button_sly_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	hogwarts_login_2 login2=new hogwarts_login_2("Slytherin");
            login2.Show();
            this.Close();
        }
    }
}
