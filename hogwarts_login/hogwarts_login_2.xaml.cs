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
	/// Interaction logic for hogwarts_login_2.xaml
	/// </summary>
	public partial class hogwarts_login_2 : Window
	{
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
	}
}