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
using System.IO;
using Text_editor.View.UserControls;
using UserControlsAlias = Text_editor.View.UserControls;

namespace Text_editor
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

		private UserControlsAlias.Text_editor GetTextEditorControl()
		{
			// Start the search from the main Grid of the MainWindow
			return FindVisualChild<UserControlsAlias.Text_editor>(this.Content as DependencyObject);
		}
		private void QuitMenuItem_Click(object sender, RoutedEventArgs e)
		{
			var editorControl = GetTextEditorControl();
			if (editorControl != null)
			{
				if (editorControl.PromptForSaveIfNeeded()) // Let the UserControl handle its dirty state
				{
					this.Close();
				}
			}
			else
			{
				this.Close(); // If no editor control found, just close.
			}
		}

		// Example for File -> Open in MainWindow Menu
		private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
		{
			var editorControl = GetTextEditorControl();
			if (editorControl != null)
			{
				editorControl.OpenButton_Click(sender, e); // Delegate the action
														   // After opening, update the MainWindow title based on the UserControl's state
				UpdateWindowTitle(editorControl.CurrentFilePath);
			}
		}

		// Example for File -> Save in MainWindow Menu
		private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
		{
			var editorControl = GetTextEditorControl();
			if (editorControl != null)
			{
				editorControl.SaveButton_Click(sender, e); // Delegate the action
				UpdateWindowTitle(editorControl.CurrentFilePath); // Update title after save
			}
		}

		// Example for File -> Save As in MainWindow Menu
		private void SaveAsMenuItem_Click(object sender, RoutedEventArgs e)
		{
			var editorControl = GetTextEditorControl();
			if (editorControl != null)
			{
				editorControl.SaveFileAs(); // Call SaveFileAs directly
				UpdateWindowTitle(editorControl.CurrentFilePath); // Update title after save
			}
		}

		// Example for Edit -> Undo in MainWindow Menu
		private void UndoMenuItem_Click(object sender, RoutedEventArgs e)
		{
			var editorControl = GetTextEditorControl();
			if (editorControl != null)
			{
				editorControl.UndoButton_Click(sender, e); // Delegate the action
			}
		}
		// ... Implement similar handlers for Redo, Cut, Copy, Paste, Find, Replace ...


		// Helper to update the window title
		private void UpdateWindowTitle(string filePath)
		{
			if (!string.IsNullOrEmpty(filePath))
			{
				this.Title = $"Text Editor - {System.IO.Path.GetFileName(filePath)}";
			}
			else
			{
				this.Title = "Text Editor - Untitled";
			}
		}


		// --- Helper to find Visual Child (if not already in your project) ---
		public static T FindVisualChild<T>(DependencyObject parent) where T : Visual
		{
			if (parent == null) return null;
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
			{
				Visual child = (Visual)VisualTreeHelper.GetChild(parent, i);
				if (child is T)
				{
					return (T)child;
				}
				else
				{
					T result = FindVisualChild<T>(child);
					if (result != null) return result;
				}
			}
			return null;
		}
	}
}
