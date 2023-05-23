using Syncfusion.Windows.Shared;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace DMOHelper.Dialogs
{
    /// <summary>
    /// Interaktionslogik für MoneyDialog.xaml
    /// </summary>
    public partial class MoneyDialog : ChromelessWindow
    {
        private bool wasFarmed = false;
        private static readonly Regex _teraRegex = new Regex("^[1-9][0-9]{0,4}$"); //regex that matches 0-99999 for tera
        private static readonly Regex _mbRegex = new Regex("^[1-9][0-9]{0,2}$"); //regex that matches 0-999 for mega and bit
        private static bool IsTeraTextAllowed(string text)
        {
            return !_teraRegex.IsMatch(text);
        }

        private static bool IsMBTextAllowed(string text)
        {
            return !_mbRegex.IsMatch(text);
        }

        public MoneyDialog(string question, bool farmedButtonVisible = false)
        {
            InitializeComponent();
            lblQuestion.Content = question;
            if (farmedButtonVisible)
            {
                FarmedPanel.Visibility = Visibility.Visible;
            }
        }

        private void teraAnswer_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? box = sender as TextBox;
            if (box != null)
            {
                e.Handled = IsTeraTextAllowed(box.Text + e.Text);
            }
        }
        private void answer_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? box = sender as TextBox;
            if (box != null)
            {
                e.Handled = IsMBTextAllowed(box.Text + e.Text);
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            teraAnswer.SelectAll();
            teraAnswer.Focus();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private long tera
        {
            get
            {
                bool result = long.TryParse(teraAnswer.Text, out long tera);
                if (result)
                {
                    return tera;
                }
                else return 0;
            }
        }

        private short mega
        {
            get
            {
                bool result = short.TryParse(megaAnswer.Text, out short mega);
                if (result)
                {
                    return mega;
                }
                else return 0;
            }
        }

        private short bit
        {
            get
            {
                bool result = short.TryParse(bitAnswer.Text, out short bit);
                if (result)
                {
                    return bit;
                }
                else return 0;
            }
        }

        public Tuple<long, short, short> Answer
        {
            get
            {
                return new Tuple<long, short, short>(tera, mega, bit);
            }
        }

        private void FarmedBtn_Click(object sender, RoutedEventArgs e)
        {
            wasFarmed = true;
            this.DialogResult = true;
        }

        public bool WasFarmed
        {
            get
            {
                return wasFarmed;
            }
        }
    }
}
