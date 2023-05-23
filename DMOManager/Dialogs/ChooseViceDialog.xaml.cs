using DMOHelper.Helper;
using Syncfusion.Windows.Shared;
using System;
using System.Windows;

namespace DMOHelper.Dialogs
{
    public partial class ChooseViceDialog : ChromelessWindow
    {
        private VMMain viewModel;
        public ChooseViceDialog()
        {
            this.DataContext = viewModel = VMMain.GetInstance();
            InitializeComponent();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.Focus();
        }

        public int Answer
        {
            get
            {
                EnumDropdownHelper? item = txtAnswer.SelectedItem as EnumDropdownHelper;
                if (item != null)
                {
                    return item.Index;
                }
                else return -1;
            }
        }
    }
}
