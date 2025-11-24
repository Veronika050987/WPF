using Grid_properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Grid_properties
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			// Создаем экземпляр нашего программного окна
			MyMainWindow mainWindow = new MyMainWindow();

			// Устанавливаем его как главное окно приложения
			this.MainWindow = mainWindow;

			// Показываем окно
			mainWindow.Show();
		}
	}
}
