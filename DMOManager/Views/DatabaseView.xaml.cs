using DMOHelper.Dialogs;
using DMOHelper.Helper;
using DMOHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DMOHelper.Views
{
    public partial class DatabaseView : UserControl
    {
        public DatabaseView()
        {
            this.DataContext = MainWindow.viewModel;
            InitializeComponent();
        }

        #region Items
        private async void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            TextDialog typeDialog = new TextDialog("Please enter Item type:", "");
            if (typeDialog.ShowDialog() == true)
            {
                string type = typeDialog.Answer;
                if (!MainWindow.viewModel.Items.Any(x => x.Type == typeDialog.Answer))
                {
                    MoneyDialog priceDialog = new MoneyDialog("Please enter target price:");
                    if (priceDialog.ShowDialog() == true)
                    {
                        Item Item = new Item(type, priceDialog.Answer.GetLongFormat());
                        await SQLiteDatabaseManager.Database.InsertAsync(Item);
                        MainWindow.viewModel.Items.Add(Item);
                    }
                }
                else
                {
                    MessageBox.Show("Item already existent!", "Collision Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("When deleting an item from database, all remaining stacks of this item on accounts will be deleted as well." + Environment.NewLine + "Proceed?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Item? item = ItemList.SelectedItem as Item;
                if (item != null)
                {
                    //Stacks
                    List<ItemStack> stackDeleteList = new List<ItemStack>();
                    foreach (ItemStack stack in MainWindow.viewModel.ItemStacks.Where(x => x.Type == item.Type))
                    {
                        stackDeleteList.Add(stack);
                    }
                    foreach (ItemStack stack in stackDeleteList)
                    {
                        await SQLiteDatabaseManager.Database.DeleteAsync(stack);
                        MainWindow.viewModel.ItemStacks.Remove(stack);
                        MainWindow.viewModel.SelectedAccountStacks.Remove(stack);
                    }
                    //Item
                    await SQLiteDatabaseManager.Database.DeleteAsync(item);
                    MainWindow.viewModel.Items.Remove(item);
                    //Refresh
                    foreach (Account acc in MainWindow.viewModel.Accounts)
                    {
                        acc.RefreshValue();
                    }
                    MainWindow.viewModel.Refresh();

                }
            }
        }
        private async void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            MoneyDialog priceDialog = new MoneyDialog("Please enter target price:");
            if (priceDialog.ShowDialog() == true)
            {
                Item? Item = ItemList.SelectedItem as Item;
                if (Item != null)
                {
                    Item.TargetPrice = priceDialog.Answer.GetLongFormat();
                    await SQLiteDatabaseManager.Database.UpdateAsync(Item);
                    //Refresh
                    foreach (ItemStack stack in MainWindow.viewModel.ItemStacks)
                    {
                        stack.RefreshValue();
                    }
                    foreach (Account acc in MainWindow.viewModel.Accounts)
                    {
                        acc.RefreshValue();
                    }
                    MainWindow.viewModel.Refresh();
                    Account? account = MainWindow.viewModel.SelectedAccount;//AccountsList.SelectedItem as Account;
                    if (account != null)
                    {
                        MainWindow.viewModel.AccountSelected(account.Name);
                    }
                }
            }
        }
        #endregion
    }
}
