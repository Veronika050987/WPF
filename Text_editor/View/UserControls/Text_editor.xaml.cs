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
using Microsoft.Win32;
using System.IO;

namespace Text_editor.View.UserControls
{
	/// <summary>
	/// Interaction logic for Text_editor.xaml
	/// </summary>
	public partial class Text_editor : UserControl
	{
		public bool IsDirty { get; set; } = false;
		public string CurrentFilePath { get; set; } = null;
		public Text_editor()
		{
			InitializeComponent();
			MainTextBox.TextChanged += MainTextBox_TextChanged;
		}

		private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			IsDirty = true;
		}

		//private void MenuItem_Click(object sender, RoutedEventArgs e)
		//{
		//	Window window = Window.GetWindow(this);
		//	window.Close();
  //      }

		public void NewButton_Click(object sender, RoutedEventArgs e)
		{
			if(PromptForSaveIfNeeded())
			{
				MainTextBox.Clear();
				IsDirty = false;
				CurrentFilePath = null;
			}
		}

		public void OpenButton_Click(object sender, RoutedEventArgs e)
		{
			if (PromptForSaveIfNeeded())
			{
				var openFileDialog = new OpenFileDialog()
				{
					Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*"
				};

				if(openFileDialog.ShowDialog()==true)
				{
					try
					{
						MainTextBox.Text = File.ReadAllText(openFileDialog.FileName);
						CurrentFilePath = openFileDialog.FileName;
						IsDirty = false;
					}
					catch (Exception ex)
					{
						MessageBox.Show($"File opening error:{ex.Message}");
					}
				}

			}
		}

		public void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			SaveFile();
		}

		public void SaveFile()
		{
			if(string.IsNullOrEmpty(CurrentFilePath))
			{
				SaveFileAs();
			}
			else
			{
				try
				{
					File.WriteAllText(CurrentFilePath, MainTextBox.Text);
					IsDirty = false;
				}
				catch(Exception ex)
				{
					MessageBox.Show($"Saving file error:{ex.Message}");
				}
			}
		}

		public void SaveFileAs()
		{
			var SaveFileDialog = new SaveFileDialog
			{
				Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*"
			};

			if(SaveFileDialog.ShowDialog()==true)
			{
				CurrentFilePath = SaveFileDialog.FileName;
				try
				{
					File.WriteAllText(CurrentFilePath, MainTextBox.Text);
					IsDirty = false;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Saving file error:{ex.Message}");
				}
			}
		}
		public void UndoButton_Click(object sender, RoutedEventArgs e)
		{
			MainTextBox.Undo();
		}

		public void RedoButton_Click(object sender, RoutedEventArgs e)
		{
			MainTextBox.Redo();
		}

		// --- Helper Method to prompt for save ---
		// This method will be called before actions that might overwrite current content (New, Open, Quit)
		public bool PromptForSaveIfNeeded()
		{
			if(IsDirty)
			{
				var result = MessageBox.Show("You have unsaved changes. Do you want to save them?",
											 "Unsaved Changes",
											 MessageBoxButton.YesNoCancel,
											 MessageBoxImage.Warning);
				if(result == MessageBoxResult.Yes)
				{
					SaveFile();
				}
				else if(result == MessageBoxResult.No)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return true;
		}

		public string GetText()
		{
			return MainTextBox.Text;
		}

		public void SetText(string text)
		{
			MainTextBox.Text = text;
			IsDirty = false;
		}

		public event RoutedEventHandler NewFileRequested;
		public event RoutedEventHandler OpenFileRequested;
		public event RoutedEventHandler SaveFileRequested;
		public event RoutedEventHandler SaveFileAsRequested;

		private void RaiseNewFileRequested()
		{
			NewFileRequested?.Invoke(this, new RoutedEventArgs());
		}

		private void RaiseOpenFileRequested()
		{
			OpenFileRequested?.Invoke(this, new RoutedEventArgs());
		}

		private void RaiseSaveFileRequested()
		{
			SaveFileRequested?.Invoke(this, new RoutedEventArgs());
		}

		private void RaiseSaveFileAsRequested()
		{
			SaveFileAsRequested?.Invoke(this, new RoutedEventArgs());
		}
	}
}
