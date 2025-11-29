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
using System.Net;

namespace IPaddress.View.UserControls
{
	/// <summary>
	/// Interaction logic for IpAddressControl.xaml
	/// </summary>
	public partial class IpAddressControl : UserControl
	{
		public IpAddressControl()
		{
			InitializeComponent();

			Octet1TextBox.PreviewTextInput += OctetTextBox_PreviewTextInput;
			Octet2TextBox.PreviewTextInput += OctetTextBox_PreviewTextInput;
			Octet3TextBox.PreviewTextInput += OctetTextBox_PreviewTextInput;
			Octet4TextBox.PreviewTextInput += OctetTextBox_PreviewTextInput;
			Octet1TextBox.TextChanged += OctetTextBox_TextChanged;
			Octet2TextBox.TextChanged += OctetTextBox_TextChanged;
			Octet3TextBox.TextChanged += OctetTextBox_TextChanged;
			Octet4TextBox.TextChanged += OctetTextBox_TextChanged;
		}

		public static readonly DependencyProperty IpAddressProperty =
			DependencyProperty.Register
			(
			"IpAddress", typeof(string),
			typeof(IpAddressControl),
				new FrameworkPropertyMetadata
				(
				string.Empty,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
				OnIpAddressChanged
				)
			);
		public string IpAddress
		{
			get
			{
				return (string)GetValue(IpAddressProperty);
			}
			set
			{
				SetValue(IpAddressProperty, value);
			}
		}

		private static void OnIpAddressChanged
			(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			// Update internal text boxes if IpAddress is set externally
			if (d is IpAddressControl control && e.NewValue is string newIp)
			{
				string[] octets = newIp.Split('.');
				if (octets.Length == 4)
				{
					control.Octet1TextBox.Text = octets[0];
					control.Octet2TextBox.Text = octets[1];
					control.Octet3TextBox.Text = octets[2];
					control.Octet4TextBox.Text = octets[3];
				}
			}
		}

		private void OctetTextBox_PreviewTextInput
			(object sender, TextCompositionEventArgs e)
		{
			// Allow only digits
			if (!char.IsDigit(e.Text, e.Text.Length - 1))
			{ 
				e.Handled = true; 
			}
		}

		private void OctetTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			UpdateIpAddress();
			TextBox currentTextBox = (TextBox)sender;
			if (currentTextBox.Text.Length == 3)
			{
				// Move focus to the next octet if the current one is full
				if (currentTextBox == Octet1TextBox) Octet2TextBox.Focus();
				else if (currentTextBox == Octet2TextBox) Octet3TextBox.Focus();
				else if (currentTextBox == Octet3TextBox) Octet4TextBox.Focus();
			}
		}
		private void UpdateIpAddress()
		{         // Combine octet values into the IpAddress property
			IpAddress = $"{Octet1TextBox.Text}." +
				$"{Octet2TextBox.Text}." +
				$"{Octet3TextBox.Text}." +
				$"{Octet4TextBox.Text}";
		}
	}
}
