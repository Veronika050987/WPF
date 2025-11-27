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

namespace CustomTextBoxControl.View.UserControls
{
	/// <summary>
	/// Interaction logic for ClearableTextBox.xaml
	/// </summary>
	public partial class ClearableTextBox : UserControl
	{
		public static readonly DependencyProperty PlaceholderProperty =
			DependencyProperty.Register("Placeholder", typeof(string), typeof(ClearableTextBox), 
				new PropertyMetadata(""));

		public string Placeholder
		{
			get { return (string)GetValue(PlaceholderProperty); }
			set { SetValue(PlaceholderProperty, value); }
		}

		public static readonly DependencyProperty ShowClearButtonProperty =
			DependencyProperty.Register("ShowClearButton", typeof(bool), typeof(ClearableTextBox), 
				new PropertyMetadata(true));

		public bool ShowClearButton
		{
			get { return (bool)GetValue(ShowClearButtonProperty); }
			set { SetValue(ShowClearButtonProperty, value); }
		}

		public ClearableTextBox()
		{
			InitializeComponent();

			this.DataContext = this;
		}

		private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			tbPlaceholder.Visibility = txtInput.Text == "" ? Visibility.Visible : Visibility.Hidden;
			btnClear.Visibility = (string.IsNullOrEmpty(txtInput.Text) || !ShowClearButton) ? 
				Visibility.Collapsed : Visibility.Visible;
		}

		private void txtInput_GotFocus(object sender, RoutedEventArgs e)
		{
			// При получении фокуса, Placeholder должен стать невидимым,
			// а кнопка очистки - видимой (если ShowClearButton = true)
			tbPlaceholder.Visibility = string.IsNullOrEmpty(txtInput.Text) ? Visibility.Visible : 
				Visibility.Hidden;
			btnClear.Visibility = (string.IsNullOrEmpty(txtInput.Text) || !ShowClearButton) ? 
				Visibility.Collapsed : Visibility.Visible;
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			txtInput.Text = "";
			
			txtInput.Focus();
		}

		private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				e.Handled = true;

				// Получаем UIElement, который сейчас сфокусирован
				UIElement currentFocusedElement = FocusManager.GetFocusedElement(this) as UIElement;

				if (currentFocusedElement != null)
				{
					DependencyObject nextElement = null;
					FocusNavigationDirection direction = FocusNavigationDirection.Next;
				}
			}
		}
		private void tbPlaceholder_MouseDown(object sender, MouseButtonEventArgs e)
		{
		     txtInput.Focus();
		}
	}
}
