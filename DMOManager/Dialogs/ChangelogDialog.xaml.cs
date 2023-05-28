using Syncfusion.Windows.Shared;
using System.Windows;
using System;

namespace DMOHelper.Dialogs
{
    /// <summary>
    /// Interaktionslogik für ChangelogDialog.xaml
    /// </summary>
    public partial class ChangelogDialog : ChromelessWindow
    {
        public ChangelogDialog(string markdown)
        {
            InitializeComponent();
            Markdownview.Markdown = markdown;
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
