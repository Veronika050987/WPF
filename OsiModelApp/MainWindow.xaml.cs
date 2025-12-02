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

namespace OsiModelApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

	public class OsiLayer
	{
		public int Layer { get; set; }
		public string Name { get; set; }
		public string ProtocolExample { get; set; }
		public string Explanation { get; set; }
	}

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			LoadOsiData();
		}

		private void LoadOsiData()
		{
			List<OsiLayer> layers = new List<OsiLayer>
			{
				new OsiLayer
				{
					Layer = 7, 
					Name = "Прикладной (Application)", 
					ProtocolExample = "HTTP, FTP, SMTP",
					Explanation = "Отвечает за взаимодействие приложений и " +
					"конечных пользователей. Предоставляет сервисы, такие как " +
					"электронная почта и передача файлов."
				},

				new OsiLayer
				{
					Layer = 6,
					Name = "Представления (Presentation)", 
					ProtocolExample = "JPEG, MPEG, SSL/TLS",
					Explanation = "Отвечает за представление данных, " +
					"шифрование и дешифрование, сжатие. Гарантирует, " +
					"что данные читабельны для получателя."
				},

				new OsiLayer
				{
					Layer = 5,
					Name = "Сеансовый (Session)", 
					ProtocolExample = "NetBIOS, RPC",
					Explanation = "Управляет сеансами связи: устанавливает, " +
					"поддерживает и завершает соединения между приложениями."
				},

				new OsiLayer
				{
					Layer = 4,
					Name = "Транспортный (Transport)", 
					ProtocolExample = "TCP, UDP",
					Explanation = "Обеспечивает надежную и упорядоченную " +
					"передачу данных между конечными точками. Отвечает за " +
					"сегментацию и контроль ошибок."
				},

				new OsiLayer
				{
					Layer = 3,
					Name = "Сетевой (Network)", 
					ProtocolExample = "IP, ICMP, OSPF",
					Explanation = "Отвечает за маршрутизацию и логическую адресацию " +
					"(IP-адреса). Определяет лучший путь для доставки данных."
				},

				new OsiLayer
				{
					Layer = 2,
					Name = "Канальный (Data Link)", 
					ProtocolExample = "Ethernet, Wi-Fi, ARP",
					Explanation = "Обеспечивает передачу данных (фреймов) между " +
					"двумя соседними узлами в локальной сети. Отвечает за MAC-адресацию " +
					"и контроль доступа к среде."
				},

				new OsiLayer
				{
					Layer = 1,
					Name = "Физический (Physical)", 
					ProtocolExample = "Кабели, Hubs, DSL",
					Explanation = "Отвечает за физическую передачу битов данных " +
					"по физической среде (кабель, радиоволны). Определяет " +
					"электрические и механические характеристики."
				}
			};
			OsiDataGrid.ItemsSource = layers;
		}

		private void OsiDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(OsiDataGrid.SelectedItem is OsiLayer selectedLayer)
			{
				MessageBox.Show(selectedLayer.Explanation, 
					$"Подробности: Уровень {selectedLayer.Layer}");
				
				OsiDataGrid.SelectedItem = null;
			}
		}
	}
}
