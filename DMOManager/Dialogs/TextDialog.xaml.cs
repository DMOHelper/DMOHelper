using System;
using System.Windows;

namespace DMOManager.Dialogs
{
    /// <summary>
    /// Interaktionslogik für TextDialog.xaml
    /// </summary>
    public partial class TextDialog : Window
    {
		public TextDialog(string question, string defaultAnswer = "")
		{
			InitializeComponent();
			lblQuestion.Content = question;
			txtAnswer.Text = defaultAnswer;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtAnswer.SelectAll();
			txtAnswer.Focus();
		}

		public string Answer
		{
			get { return txtAnswer.Text; }
		}
	}
}
