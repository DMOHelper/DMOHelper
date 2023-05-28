using Syncfusion.Windows.Shared;
using System.Windows;
using System;
using MdXaml;
using System.Windows.Documents;

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
            Markdown engine = new Markdown();
            Markdownview.Document = engine.Transform(markdown);
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
