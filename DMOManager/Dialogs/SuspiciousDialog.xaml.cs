using Syncfusion.Windows.Shared;
using System;
using System.Windows;

namespace DMOHelper.Dialogs
{
    /// <summary>
    /// Interaktionslogik für SuspiciousDialog.xaml
    /// </summary>
    public partial class SuspiciousDialog : ChromelessWindow
    {
        public SuspiciousDialog()
        {
            InitializeComponent();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            btnDialogOk.Focus();
        }
    }
}
