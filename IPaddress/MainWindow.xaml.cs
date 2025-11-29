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

namespace IPaddress
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//public string MyIpAddress { get; set; } = "192.168.1.1"; // Example initial value
		public string MyIpAddress { get; set; } // Example initial value
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this; // Or your ViewModel instance
		}
		private void Button_Click(object sender, RoutedEventArgs e) 
		{ 
			MessageBox.Show($"Current IP: {MyIpAddress}"); 
		}
	}
}
