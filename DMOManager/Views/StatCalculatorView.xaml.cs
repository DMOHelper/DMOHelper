using DMOHelper.Dialogs;
using DMOHelper.Dialogs.DialogViewModels;
using DMOHelper.Models;
using System.Windows;
using System.Windows.Controls;

namespace DMOHelper.Views
{
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
                viewModel.StatInformation.Calculate();
            }
        }

        private void Seals_Click(object sender, RoutedEventArgs eventArgs)
        {
            SealsDialog sealDialog = new SealsDialog(new SealsVM(viewModel.StatInformation.Seals));
            if (sealDialog.ShowDialog() == true)
            {
                viewModel.StatInformation.Seals = sealDialog.Seals;
                viewModel.StatInformation.Calculate();
            }
        }
        private void Clone_Click(object sender, RoutedEventArgs e)
        {
            CloneDialog cloneDialog = new CloneDialog(new CloneVM(viewModel.StatInformation.AttackClone, viewModel.StatInformation.CriticalClone, viewModel.StatInformation.HPClone, viewModel.StatInformation.EvadeClone));
            cloneDialog.ShowDialog();
        }
        private void Digivice_Click(object sender, RoutedEventArgs e)
        {
            DigiviceSCDialog digiviceDialog = new DigiviceSCDialog(new DigiviceSCVM(viewModel.StatInformation.Digivice));
            if (digiviceDialog.ShowDialog() == true)
            {
                viewModel.StatInformation.Digivice = digiviceDialog.Digivice;
                viewModel.StatInformation.Calculate();
            }
        }

        private void TStats_Click(object sender, RoutedEventArgs e)
        {
            TamerStatsDialog tamerDialog = new TamerStatsDialog(new TamerStatsVM(viewModel.StatInformation.TamerStats));
            if (tamerDialog.ShowDialog() == true)
            {
                viewModel.StatInformation.TamerStats = tamerDialog.TamerStats;
                viewModel.StatInformation.Calculate();
            }
        }

        private void Presets_Click(object sender, RoutedEventArgs e)
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
                        viewModel.StatInformation.Calculate();
                        break;
                    default:
                        break;
                }
            }
        }

        private void SkillLevel_ValueChanging(object sender, Syncfusion.Windows.Shared.ValueChangingEventArgs e)
        {
            int availablePoints = 76;
            availablePoints -= viewModel.StatInformation.Digimon.Skill1Points * (viewModel.StatInformation.Digimon.Skill1Level - 1);
            availablePoints -= viewModel.StatInformation.Digimon.Skill2Points * (viewModel.StatInformation.Digimon.Skill2Level - 1);
            availablePoints -= viewModel.StatInformation.Digimon.Skill3Points * (viewModel.StatInformation.Digimon.Skill3Level - 1);
            availablePoints -= viewModel.StatInformation.Digimon.Skill4Points * (viewModel.StatInformation.Digimon.Skill4Level - 1);
            
        }
    }
}
