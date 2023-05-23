using Syncfusion.Windows.Shared;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace DMOHelper.Dialogs
{
    public partial class IntegerDialog : ChromelessWindow
    {
        private static Regex _intRegex = new Regex("^\\d+$"); //regex that matches integers
        private static bool IsTextAllowed(string text)
        {
            return !_intRegex.IsMatch(text);
        }

        public IntegerDialog(string question, int defaultAnswer = 0, short? maxDigits = null)
        {
            InitializeComponent();
            lblQuestion.Content = question;
            txtAnswer.Text = defaultAnswer.ToString();
            if(maxDigits != null)
            {
                string regex = "^[0-9]{0," + maxDigits + "}$";
                _intRegex = new Regex(regex);
            }
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

        private void txtAnswer_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? box = sender as TextBox;
            if (box != null)
            {
                e.Handled = IsTextAllowed(box.Text + e.Text);
            }
        }
    }
}
