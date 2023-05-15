using DMOManager.Dialogs;
using DMOManager.Dialogs.DialogViewModels;
using DMOManager.Models;
using System.Windows;
using System.Windows.Controls;

namespace DMOManager.Views
{
    /// <summary>
    /// Interaktionslogik für StatCalculatorView.xaml
    /// </summary>
    public partial class StatCalculatorView : UserControl
    {
        VMMain viewModel;
        public StatCalculatorView()
        {
            this.DataContext = viewModel = VMMain.GetInstance();
            InitializeComponent();
        }

        private void Accessories_Click(object sender, RoutedEventArgs e)
        {
            AccessoryDialog accDialog = new AccessoryDialog(viewModel.StatInformation.Ring, viewModel.StatInformation.Necklace, viewModel.StatInformation.Earrings, viewModel.StatInformation.Bracelet, viewModel.StatEnabled);
            if (accDialog.ShowDialog() == true)
            {
                viewModel.StatInformation.Ring = accDialog.Ring;
                viewModel.StatInformation.Necklace = accDialog.Necklace;
                viewModel.StatInformation.Earrings = accDialog.Earrings;
                viewModel.StatInformation.Bracelet = accDialog.Bracelet;
            }
        }

        private void Seals_Click(object sender, RoutedEventArgs eventArgs)
        {
            SealsDialog sealDialog = new SealsDialog(viewModel.StatInformation.Seals);
            if (sealDialog.ShowDialog() == true)
            {
                viewModel.StatInformation.Seals = sealDialog.Seals;
            }
        }

        private void PresetsButton_Click(object sender, RoutedEventArgs e)
        {
            PresetDialog presetDialog = new PresetDialog(new DigimonVM(viewModel.StatInformation.Digimon), "Rank");
            if (presetDialog.ShowDialog() == true)
            {
                var digimon = presetDialog.GetSelected;
                switch (digimon)
                {
                    case Digimon _digimon:
                        viewModel.StatInformation.Digimon = new Digimon()
                        {
                            Name = _digimon.Name,
                            Rank = _digimon.Rank,
                            Evolution = _digimon.Evolution,
                            Type = _digimon.Type,
                            BaseHP = _digimon.BaseHP,
                            BaseDS = _digimon.BaseDS,
                            BaseAT = _digimon.BaseAT,
                            AS = _digimon.AS,
                            BaseCT = _digimon.BaseCT,
                            HT = _digimon.HT,
                            BaseDE = _digimon.BaseDE,
                            EV = _digimon.EV,
                            Attribute = _digimon.Attribute,
                            Elemental = _digimon.Elemental
                        };
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
