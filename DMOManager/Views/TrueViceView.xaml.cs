using DMOHelper.Dialogs;
using DMOHelper.Enums;
using DMOHelper.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DMOHelper.Views
{
    public partial class TrueViceView : UserControl
    {
        public TrueViceView()
        {
            this.DataContext = MainWindow.viewModel;
            InitializeComponent();
        }
        #region Digivices
        private async void AddViceButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseViceDialog viceDialog = new ChooseViceDialog();
            if (viceDialog.ShowDialog() == true)
            {
                Account? account = TVAccountsList.SelectedItem as Account;
                if (account != null)
                {
                    Digivice vice = new Digivice(account.Name, (ViceType)viceDialog.Answer);
                    MainWindow.viewModel.Digivices.Add(vice);
                    MainWindow.viewModel.SelectedAccountVices.Add(vice);
                    await SQLiteDatabaseManager.Database.InsertAsync(vice);
                }
            }
        }

        private async void DeleteViceButton_Click(object sender, RoutedEventArgs e)
        {
            Digivice? vice = ViceList.SelectedValue as Digivice;
            if (vice != null)
            {
                await SQLiteDatabaseManager.Database.DeleteAsync(vice);
                MainWindow.viewModel.Digivices.Remove(vice);
                MainWindow.viewModel.SelectedAccountVices.Remove(vice);
                MainWindow.viewModel.SelectedResources.SetCurrent(ViceType.None);
            }
        }

        private void ViceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Digivice? vice = ViceList.SelectedValue as Digivice;
            if (vice != null)
            {
                try
                {
                   MainWindow.viewModel.SelectedResources.SetCurrent(vice.Type);
                }
                catch (NullReferenceException) { }
            }
        }
        private void TVAccountsList_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            Account? account = TVAccountsList.SelectedItem as Account;
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

        private async void UpgradeViceButton_Click(object sender, RoutedEventArgs e)
        {
            Digivice? vice = ViceList.SelectedValue as Digivice;
            ViceResources? resources = MainWindow.viewModel.SelectedResources;
            if (resources != null && vice != null && resources.IsUpgradeable)
            {
                switch (vice.Type)
                {
                    case ViceType.Beg0:
                        resources.EOE -= 149;
                        resources.FOE -= 8;
                        vice.Type = ViceType.Beg1;
                        resources.SetCurrent(ViceType.Beg1);
                        break;
                    case ViceType.Beg1:
                        resources.EOE -= 211;
                        resources.POE -= 11;
                        resources.MyoCore -= 6;
                        vice.Type = ViceType.Beg2;
                        resources.SetCurrent(ViceType.Beg2);
                        break;
                    case ViceType.Beg2:
                        resources.EOE -= 287;
                        resources.Virus -= 8;
                        resources.DEnergy -= 7;
                        resources.BEnergy -= 7;
                        vice.Type = ViceType.Adv0;
                        resources.SetCurrent(ViceType.Adv0);
                        break;
                    case ViceType.Adv0:
                        resources.EOE -= 301;
                        resources.Skull -= 7;
                        resources.AEOE -= 5;
                        vice.Type = ViceType.Adv1;
                        resources.SetCurrent(ViceType.Adv1);
                        break;
                    case ViceType.Adv1:
                        resources.EOE -= 307;
                        resources.Soul -= 6;
                        resources.Heinous -= 3;
                        vice.Type = ViceType.Adv2;
                        resources.SetCurrent(ViceType.Adv2);
                        break;
                    case ViceType.Adv2:
                        resources.EOE -= 318;
                        resources.Venom -= 7;
                        resources.Condensed -= 4;
                        vice.Type = ViceType.TrueVice;
                        resources.SetCurrent(ViceType.TrueVice);
                        break;
                    case ViceType.OT103:
                        resources.EOE -= 318;
                        resources.Venom -= 7;
                        resources.Condensed -= 4;
                        vice.Type = ViceType.TrueVice;
                        resources.SetCurrent(ViceType.TrueVice);
                        break;
                    case ViceType.TrueVice:
                        resources.EOE -= 710;
                        resources.Venom -= 1;
                        resources.Soul -= 2;
                        resources.Skull -= 4;
                        break;
                }
                await SQLiteDatabaseManager.Database.UpdateAsync(resources);
                await SQLiteDatabaseManager.Database.UpdateAsync(vice);
                Account? acount = TVAccountsList.SelectedItem as Account;
                string name = string.Empty;
                if (acount != null)
                {
                    name = acount.Name;
                }
                resources.Refresh();
                MainWindow.viewModel.AccountSelected(name);//AccountsList.SelectedItem as Account).Name);
            }
        }

        private async void EditResourceBtn_Click(object sender, RoutedEventArgs e)
        {
            ViceResourcesListItem? item = ResourceList.SelectedItem as ViceResourcesListItem;
            ViceResources? resources = MainWindow.viewModel.SelectedResources;
            if (item != null && resources != null)
            {
                IntegerDialog amountDialog = new IntegerDialog("Please enter new amount of " + item.Resource + ":", 0, 4);
                if (amountDialog.ShowDialog() == true)
                {
                    bool parse = int.TryParse(amountDialog.Answer, out int amount);
                    if (parse)
                    {
                        switch (item.Resource)
                        {
                            case ViceMaterial.EOE:
                                resources.EOE = amount;
                                break;
                            case ViceMaterial.FOE:
                                resources.FOE = amount;
                                break;
                            case ViceMaterial.POE:
                                resources.POE = amount;
                                break;
                            case ViceMaterial.MyoCore:
                                resources.MyoCore = amount;
                                break;
                            case ViceMaterial.DEnergy:
                                resources.DEnergy = amount;
                                break;
                            case ViceMaterial.BEnergy:
                                resources.BEnergy = amount;
                                break;
                            case ViceMaterial.Virus:
                                resources.Virus = amount;
                                break;
                            case ViceMaterial.Skull:
                                resources.Skull = amount;
                                break;
                            case ViceMaterial.Soul:
                                resources.Soul = amount;
                                break;
                            case ViceMaterial.Venom:
                                resources.Venom = amount;
                                break;
                            case ViceMaterial.AEOE:
                                resources.AEOE = amount;
                                break;
                            case ViceMaterial.Heinous:
                                resources.Heinous = amount;
                                break;
                            case ViceMaterial.Condensed:
                                resources.Condensed = amount;
                                break;
                        }
                        await SQLiteDatabaseManager.Database.UpdateAsync(resources);
                        resources.Refresh();
                    }
                }
            }
        }

        private async void MakeAEOE_Click(object sender, RoutedEventArgs e)
        {
            ViceResources? resources = MainWindow.viewModel.SelectedResources;
            if (resources != null)
            {
                resources.FOE -= 3;
                resources.POE -= 3;
                resources.AEOE++;
                await SQLiteDatabaseManager.Database.UpdateAsync(resources);
                resources.Refresh();
            }
        }

        private async void MakeHeinous_Click(object sender, RoutedEventArgs e)
        {
            ViceResources? resources = MainWindow.viewModel.SelectedResources;
            if (resources != null)
            {
                resources.Skull -= 1;
                resources.MyoCore -= 3;
                resources.Virus -= 3;
                resources.Heinous++;
                await SQLiteDatabaseManager.Database.UpdateAsync(resources);
                resources.Refresh();
            }
        }

        private async void MakeCondensed_Click(object sender, RoutedEventArgs e)
        {
            ViceResources? resources = MainWindow.viewModel.SelectedResources;
            if (resources != null)
            {
                resources.MyoCore -= 1;
                resources.Skull -= 2;
                resources.Soul -= 1;
                resources.Condensed++;
                await SQLiteDatabaseManager.Database.UpdateAsync(resources);
                resources.Refresh();
            }
        }

        #endregion
    }
}
