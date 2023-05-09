using DMOManager.Dialogs;
using DMOManager.Helper;
using DMOManager.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DMOManager.Enums;

namespace DMOManager.Views
{
    /// <summary>
    /// Interaktionslogik für AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            this.DataContext = MainWindow.viewModel;
            InitializeComponent();
        }
        private void susButton_Click(object sender, RoutedEventArgs e)
        {
            new SuspiciousDialog().ShowDialog();
        }
        #region Money
        private async void MoneyEdit_Click(object sender, RoutedEventArgs e)
        {
            MoneyDialog moneyDialog = new MoneyDialog("Please enter your new money balance:", false);
            if (moneyDialog.ShowDialog() == true)
            {
                Account? account = AccountsList.SelectedItem as Account;
                if (account != null)
                {
                    account.Money = moneyDialog.Answer.GetLongFormat();
                    await SQLiteDatabaseManager.Database.UpdateAsync(account);
                    account.RefreshValue();
                    MainWindow.viewModel.Refresh();
                }
            }
        }
        #endregion
        #region MC
        private async void MC_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.viewModel.Accounts.Count != 0)
            {
                MainWindow.viewModel.Accounts.ForEach((account) => account.MaintenanceCoins++);
                await SQLiteDatabaseManager.Database.UpdateAllAsync(MainWindow.viewModel.Accounts);
            }
        }

        private async void MCedit_Click(object sender, RoutedEventArgs e)
        {
            IntegerDialog mcDialog = new IntegerDialog("Please enter the new amount of Maintenance Coins:", 0, 3);
            if (mcDialog.ShowDialog() == true)
            {
                if (int.TryParse(mcDialog.Answer, out int mc))
                {
                    Account? account = AccountsList.SelectedItem as Account;
                    if (account != null)
                    {
                        account.MaintenanceCoins = mc;
                        await SQLiteDatabaseManager.Database.UpdateAsync(account);
                    }
                }
            }
        }
        #endregion
        #region Account
        private async void NameEdit_Click(object sender, RoutedEventArgs e)
        {
            TextDialog nameDialog = new TextDialog("Please enter new account name:", "");
            if (nameDialog.ShowDialog() == true)
            {
                Account? account = AccountsList.SelectedItem as Account;
                if (account != null && !MainWindow.viewModel.Accounts.Any(x => x.Name == nameDialog.Answer))
                {
                    //Associated stacks
                    foreach (ItemStack stack in MainWindow.viewModel.ItemStacks)
                    {
                        if (stack.Account == account.Name)
                        {
                            stack.Account = nameDialog.Answer;
                            await SQLiteDatabaseManager.Database.UpdateAsync(stack);
                        }
                    }
                    //associated resources
                    ViceResources resources = MainWindow.viewModel.Resources.First(x => x.Account == account.Name);
                    resources.Account = nameDialog.Answer;
                    await SQLiteDatabaseManager.Database.UpdateAsync(resources);
                    //associated vices
                    foreach (Digivice vice in MainWindow.viewModel.Digivices)
                    {
                        if (vice.Account == account.Name)
                        {
                            vice.Account = nameDialog.Answer;
                            await SQLiteDatabaseManager.Database.UpdateAsync(vice);
                        }
                    }
                    //Account self
                    account.Name = nameDialog.Answer;
                    await SQLiteDatabaseManager.Database.UpdateAsync(account);
                }
                else
                {
                    MessageBox.Show("Account already existent!", "Collision Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Account? account = AccountsList.SelectedItem as Account;
            if (MessageBox.Show("When deleting an account, all associated data on this account will be deleted as well." + Environment.NewLine + "Proceed?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (account != null)
                {
                    //delete associated stacks
                    List<ItemStack> deleteStackList = new List<ItemStack>();
                    foreach (ItemStack stack in MainWindow.viewModel.ItemStacks.Where(x => x.Account == account.Name))
                    {
                        deleteStackList.Add(stack);
                        await SQLiteDatabaseManager.Database.DeleteAsync(stack);
                    }
                    foreach (ItemStack stack in deleteStackList)
                    {
                        MainWindow.viewModel.ItemStacks.Remove(stack);
                    }
                    //delete associated vices
                    List<Digivice> deleteViceList = new List<Digivice>();
                    foreach (Digivice vice in MainWindow.viewModel.Digivices.Where(x => x.Account == account.Name))
                    {
                        deleteViceList.Add(vice);
                        await SQLiteDatabaseManager.Database.DeleteAsync(vice);
                    }
                    foreach (Digivice vice in deleteViceList)
                    {
                        MainWindow.viewModel.Digivices.Remove(vice);
                    }
                    MainWindow.viewModel.SelectedAccountVices.Clear();
                    //delete associated resources
                    ViceResources resources = MainWindow.viewModel.Resources.First(x => x.Account == account.Name);
                    await SQLiteDatabaseManager.Database.DeleteAsync(resources);
                    MainWindow.viewModel.Resources.Remove(resources);
                    MainWindow.viewModel.SelectedResources = null;
                    //delete account
                    await SQLiteDatabaseManager.Database.DeleteAsync(account);
                    MainWindow.viewModel.Accounts.Remove(account);
                    //refresh ui
                    MainWindow.viewModel.SelectedAccountStacks.Clear();
                    MainWindow.viewModel.Refresh();
                }
            }
        }
        private async void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            TextDialog nameDialog = new TextDialog("Please enter account name:", "");
            if (nameDialog.ShowDialog() == true)
            {
                if (!MainWindow.viewModel.Accounts.Any(x => x.Name == nameDialog.Answer))
                {
                    Account account = new Account(nameDialog.Answer);
                    //auto-create resource data
                    ViceResources resources = new ViceResources(nameDialog.Answer);
                    MainWindow.viewModel.Resources.Add(resources);
                    await SQLiteDatabaseManager.Database.InsertAsync(resources);
                    //add account
                    await SQLiteDatabaseManager.Database.InsertAsync(account);
                    MainWindow.viewModel.Accounts.Add(account);
                }
                else
                {
                    MessageBox.Show("Account already existent!", "Collision Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void AccountsList_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            Account? account = AccountsList.SelectedItem as Account;
            if (account != null)
            {
                MainWindow.viewModel.AccountSelected(account.Name);
                if (MainWindow.viewModel.SelectedResources != null)
                {
                    MainWindow.viewModel.SelectedResources.SetCurrent(ViceType.None);
                }
                MainWindow.viewModel.Refresh();
            }
        }
        #endregion
        #region Item Stacks
        private async void AddStackButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseItemDialog typeDialog = new ChooseItemDialog();
            if (typeDialog.ShowDialog() == true)
            {
                string type = typeDialog.Answer;
                IntegerDialog amountDialog = new IntegerDialog("Please enter amount:", 0, 6);
                if (amountDialog.ShowDialog() == true)
                {
                    if (int.TryParse(amountDialog.Answer, out int amount))
                    {
                        MoneyDialog buyDialog = new MoneyDialog("Please enter price you paid per Item", true);
                        if (buyDialog.ShowDialog() == true)
                        {
                            Account? account = AccountsList.SelectedItem as Account;
                            if (account != null)
                            {
                                long buyPrice;
                                if (buyDialog.WasFarmed)
                                {
                                    buyPrice = -1;
                                }
                                else
                                {
                                    buyPrice = buyDialog.Answer.GetLongFormat();

                                }
                                //merge possible
                                if (MainWindow.viewModel.SelectedAccountStacks.Any(x => x.Type == type && x.BuyPrice == buyPrice))
                                {
                                    ItemStack stack = MainWindow.viewModel.SelectedAccountStacks.First(x => x.Type == type && x.BuyPrice == buyPrice);
                                    stack.Amount += amount;
                                    await SQLiteDatabaseManager.Database.UpdateAsync(stack);
                                }
                                else //new
                                {
                                    ItemStack stack = new ItemStack(amount, type, buyPrice, account.Name);
                                    await SQLiteDatabaseManager.Database.InsertAsync(stack);
                                    MainWindow.viewModel.ItemStacks.Add(stack);
                                    MainWindow.viewModel.SelectedAccountStacks.Add(stack);
                                }
                                //Refresh
                                foreach (Account acc in MainWindow.viewModel.Accounts)
                                {
                                    acc.RefreshValue();
                                }
                                MainWindow.viewModel.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private async void EditStackButton_Click(object sender, RoutedEventArgs e)
        {
            ItemStack? stack = StackList.SelectedItem as ItemStack;
            if (stack != null)
            {
                IntegerDialog amountDialog = new IntegerDialog("Please enter new amount." + Environment.NewLine + "To delete all, enter 0.", 0, 7);
                if (amountDialog.ShowDialog() == true)
                {
                    bool result = int.TryParse(amountDialog.Answer, out int amount);
                    if (result)
                    {
                        if (amount != 0)
                        {
                            stack.Amount = amount;
                            await SQLiteDatabaseManager.Database.UpdateAsync(stack);
                            //Refresh
                            foreach (Account acc in MainWindow.viewModel.Accounts)
                            {
                                acc.RefreshValue();
                            }
                            MainWindow.viewModel.Refresh();
                        }
                        else
                        {
                            await SQLiteDatabaseManager.Database.DeleteAsync(stack);
                            MainWindow.viewModel.ItemStacks.Remove(stack);
                            MainWindow.viewModel.SelectedAccountStacks.Remove(stack);
                            //Refresh
                            foreach (Account acc in MainWindow.viewModel.Accounts)
                            {
                                acc.RefreshValue();
                            }
                            MainWindow.viewModel.Refresh();
                        }
                    }
                }
            }
        }

        private async void MoveStackButton_Click(object sender, RoutedEventArgs e)
        {
            ItemStack? stack = StackList.SelectedItem as ItemStack;
            if (stack != null)
            {
                IntegerDialog amountDialog = new IntegerDialog("Please choose the amount you want to move." + Environment.NewLine + "Available amount: " + stack.Amount, 0, 7);
                if (amountDialog.ShowDialog() == true)
                {
                    bool result = int.TryParse(amountDialog.Answer, out int amount);
                    if (amount > stack.Amount)
                    {
                        amount = stack.Amount;
                    }
                    if (result)
                    {
                        ChooseAccountDialog accountDialog = new ChooseAccountDialog();
                        if (accountDialog.ShowDialog() == true)
                        {
                            if (stack.Account != accountDialog.Answer && accountDialog.Answer != null)
                            {
                                if (stack.Amount == amount) //all
                                {
                                    if (MainWindow.viewModel.ItemStacks.Any(x => x.Type == stack.Type && x.Account == accountDialog.Answer && x.BuyPrice == stack.BuyPrice)) // merge possible
                                    {
                                        ItemStack existing = MainWindow.viewModel.ItemStacks.First(x => x.Type == stack.Type && x.Account == accountDialog.Answer && x.BuyPrice == stack.BuyPrice);
                                        existing.Amount += amount;
                                        MainWindow.viewModel.ItemStacks.Remove(stack);
                                        await SQLiteDatabaseManager.Database.DeleteAsync(stack);
                                        await SQLiteDatabaseManager.Database.UpdateAsync(existing);
                                    }
                                    else
                                    {
                                        stack.Account = accountDialog.Answer;
                                        await SQLiteDatabaseManager.Database.UpdateAsync(stack);
                                    }
                                }
                                else //partial
                                {
                                    if (MainWindow.viewModel.ItemStacks.Any(x => x.Type == stack.Type && x.Account == accountDialog.Answer && x.BuyPrice == stack.BuyPrice)) // merge possible
                                    {
                                        ItemStack existing = MainWindow.viewModel.ItemStacks.First(x => x.Type == stack.Type && x.Account == accountDialog.Answer && x.BuyPrice == stack.BuyPrice);
                                        existing.Amount += amount;
                                        stack.Amount -= amount;
                                        await SQLiteDatabaseManager.Database.UpdateAsync(stack);
                                        await SQLiteDatabaseManager.Database.UpdateAsync(existing);
                                    }
                                    else
                                    {
                                        stack.Amount -= amount;
                                        ItemStack newStack = new ItemStack(amount, stack.Type, stack.BuyPrice, accountDialog.Answer);
                                        await SQLiteDatabaseManager.Database.UpdateAsync(stack);
                                        await SQLiteDatabaseManager.Database.InsertAsync(newStack);
                                        MainWindow.viewModel.ItemStacks.Add(newStack);
                                        MainWindow.viewModel.SelectedAccountStacks.Add(newStack);
                                    }
                                }
                                //Refresh
                                foreach (ItemStack sta in MainWindow.viewModel.ItemStacks)
                                {
                                    sta.RefreshValue();
                                }
                                foreach (Account acc in MainWindow.viewModel.Accounts)
                                {
                                    acc.RefreshValue();
                                }
                                MainWindow.viewModel.Refresh();
                                Account? account = AccountsList.SelectedItem as Account;
                                if (account != null)
                                {
                                    MainWindow.viewModel.AccountSelected(account.Name);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
