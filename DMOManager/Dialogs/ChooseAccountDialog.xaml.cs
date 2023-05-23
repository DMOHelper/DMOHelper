using DMOHelper.Models;
using Syncfusion.Windows.Shared;
using System;
using System.Linq;
using System.Windows;

namespace DMOHelper.Dialogs
{

    public partial class ChooseAccountDialog : ChromelessWindow
    {
        private VMMain viewModel;
        public ChooseAccountDialog()
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

        public string Answer
        {
            get
            {
                Account? account = txtAnswer.SelectedItem as Account;
                if (account != null)
                {
                    return account.Name;
                }
                else return null;
            }
        }

        private async void NewAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            TextDialog nameDialog = new TextDialog("Please enter account name:", "");
            if (nameDialog.ShowDialog() == true)
            {
                if (!viewModel.Accounts.Any(x => x.Name == nameDialog.Answer))
                {
                    Account account = new Account(nameDialog.Answer);

                    await SQLiteDatabaseManager.Database.InsertAsync(account);
                    viewModel.Accounts.Add(account);
                }
                else
                {
                    MessageBox.Show("Account already existent!", "Collision Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
