using DMOHelper.Helper;
using DMOHelper.Models;
using Syncfusion.Windows.Shared;
using System;
using System.Linq;
using System.Windows;

namespace DMOHelper.Dialogs
{
    public partial class ChooseItemDialog : ChromelessWindow
    {
        private VMMain viewModel;
        public ChooseItemDialog()
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
                Item? item = txtAnswer.SelectedItem as Item;
                if (item != null)
                {
                    return item.Type;
                }
                else return null;
            }
        }

        private async void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            TextDialog typeDialog = new TextDialog("Please enter Item type:", "");
            if (typeDialog.ShowDialog() == true)
            {
                string type = typeDialog.Answer;
                if (!viewModel.Items.Any(x => x.Type == typeDialog.Answer))
                {
                    MoneyDialog priceDialog = new MoneyDialog("Please enter target price:");
                    if (priceDialog.ShowDialog() == true)
                    {
                        Item Item = new Item(type, priceDialog.Answer.GetLongFormat());
                        await SQLiteDatabaseManager.Database.InsertAsync(Item);
                        viewModel.Items.Add(Item);
                    }
                }
                else
                {
                    MessageBox.Show("Item already existent!", "Collision Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
