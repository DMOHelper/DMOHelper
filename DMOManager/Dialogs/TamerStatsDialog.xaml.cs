using Syncfusion.Windows.Shared;
using System.Windows;
using System;
using DMOHelper.Dialogs.DialogViewModels;
using DMOHelper.Models;

namespace DMOHelper.Dialogs
{

    public partial class TamerStatsDialog : ChromelessWindow
    {
        private TamerStatsVM viewModel;
        public TamerStatsDialog(TamerStatsVM _viewModel)
        {
            this.DataContext = viewModel = _viewModel;
            InitializeComponent();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            hpValue.SelectAll();
            hpValue.Focus();
        }

        public TamerStats TamerStats
        {
            get
            {
                var output = new TamerStats()
                {
                    HP = viewModel.HP,
                    DS = viewModel.DS,
                    AT = viewModel.AT,
                    DE = viewModel.DE,
                    Intimacy = viewModel.Intimacy,
                };
                if (viewModel.MatureBlue)
                {
                    output.ASReduction = 7;
                    output.HT = 0;
                    output.CT = 0;
                }
                else if (viewModel.ProfessionalBlack)
                {
                    output.ASReduction = 0;
                    output.HT = 300;
                    output.CT = 7;
                }
                else
                {
                    output.ASReduction = 0;
                    output.HT = 0;
                    output.CT = 0;
                }
                return output;
            }
        }
    }
}
