using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media; // Для Thickness, Brushes и т.д.
using System.Windows.Media.Imaging; // Для BitmapImage

namespace Grid_properties
{
	public class MyMainWindow : Window
	{
		static MyMainWindow()
		{
		}

		public MyMainWindow()
		{
			// --- Определение свойств окна ---

			// Заголовок окна
			this.Title = "Мое Программное Окно";

			// Размер окна
			this.Width = 800;
			this.Height = 450;
			this.MinHeight = 200; // Минимальная высота
			this.MinWidth = 300;  // Минимальная ширина

			// Позиция окна (опционально)
			//this.WindowStartupLocation = WindowStartupLocation.CenterScreen; // Разместить по центру экрана

			// Поведение окна
			this.ResizeMode = ResizeMode.CanResizeWithGrip; // Позволяет изменять размер
															//this.ResizeMode = ResizeMode.NoResize; // Запретить изменение размера
															//this.ResizeMode = ResizeMode.CanMinimize; // Разрешить только минимизацию

			// --- Установка значка окна ---
			//try
			//{
			//	this.Icon = new BitmapImage(new Uri("pack://application:,,,/Grid_properties;component/cutest.ico"));
			//}
			//catch (Exception ex)
			//{
			//	System.Diagnostics.Debug.WriteLine($"Ошибка загрузки значка: {ex.Message}");
			//}

			// --- Определение содержимого окна ---

			// Создаем элемент Grid как основной контейнер
			Grid mainGrid = new Grid();
			this.Content = mainGrid; // Устанавливаем Grid как содержимое окна

			// Добавляем элементы в Grid
			TextBlock welcomeText = new TextBlock();
			welcomeText.Text = "Good day!";
			welcomeText.HorizontalAlignment = HorizontalAlignment.Center;
			welcomeText.VerticalAlignment = VerticalAlignment.Center;
			welcomeText.FontSize = 24;

			Button closeButton = new Button();
			closeButton.Content = "Close";
			closeButton.Width = 100;
			closeButton.Height = 30;
			closeButton.HorizontalAlignment = HorizontalAlignment.Center;
			closeButton.VerticalAlignment = VerticalAlignment.Bottom;
			closeButton.Margin = new Thickness(0, 0, 0, 50); // Отступ снизу
			closeButton.Click += CloseButton_Click; // Привязываем обработчик события

			mainGrid.Children.Add(welcomeText);
			mainGrid.Children.Add(closeButton);
		}

		// Обработчик события нажатия кнопки
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close(); // Закрывает текущее окно
		}
	}
}
