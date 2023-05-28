using DMOHelper.Dialogs;
using DMOHelper.Dialogs.DialogViewModels;
using DMOHelper.Models;
using Syncfusion.Windows.Shared;
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
            VMMain.GetInstance().StatInformation.initialized = true;
            VMMain.GetInstance().StatInformation.Calculate();
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
            VMMain.Initialized = false;
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
                            Elemental = _digimon.Elemental,
                            Skill1Base = _digimon.Skill1Base,
                            Skill1Increase = _digimon.Skill1Increase,
                            Skill1Points = _digimon.Skill1Points,
                            Skill2Base = _digimon.Skill2Base,
                            Skill2Increase = _digimon.Skill2Increase,
                            Skill2Points = _digimon.Skill2Points,
                            Skill3Base = _digimon.Skill3Base,
                            Skill3Increase = _digimon.Skill3Increase,
                            Skill3Points = _digimon.Skill3Points,
                            Skill4Base = _digimon.Skill4Base,
                            Skill4Increase = _digimon.Skill4Increase,
                            Skill4Points = _digimon.Skill4Points,
                            SkillIncreaseBuff = _digimon.SkillIncreaseBuff,
                            Skill1Level = 1,
                            Skill2Level = 1,
                            Skill3Level = 1,
                            Skill4Level = 1
                        };
                        viewModel.StatInformation.Calculate();
                        break;
                    default:
                        break;
                }
                VMMain.Initialized = true;
            }
        }

        private void SkillLevel_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (sender != null && (double)e.OldValue < (double)e.NewValue)
            {
                int availablePoints = 76;
                availablePoints -= viewModel.StatInformation.Digimon.Skill1Points * (viewModel.StatInformation.Digimon.Skill1Level - 1);
                availablePoints -= viewModel.StatInformation.Digimon.Skill2Points * (viewModel.StatInformation.Digimon.Skill2Level - 1);
                availablePoints -= viewModel.StatInformation.Digimon.Skill3Points * (viewModel.StatInformation.Digimon.Skill3Level - 1);
                availablePoints -= viewModel.StatInformation.Digimon.Skill4Points * (viewModel.StatInformation.Digimon.Skill4Level - 1);
                if (((UpDown)sender).Name == "skillLevel1")
                {
                    if(availablePoints < viewModel.StatInformation.Digimon.Skill1Points)
                    {
                        e.Cancel = true;
                    }
                }
                if (((UpDown)sender).Name == "skillLevel2")
                {
                    if (availablePoints < viewModel.StatInformation.Digimon.Skill2Points)
                    {
                        e.Cancel = true;
                    }
                }
                if (((UpDown)sender).Name == "skillLevel3")
                {
                    if (availablePoints < viewModel.StatInformation.Digimon.Skill3Points)
                    {
                        e.Cancel = true;
                    }
                }
                if (((UpDown)sender).Name == "skillLevel4")
                {
                    if (availablePoints < viewModel.StatInformation.Digimon.Skill4Points)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
