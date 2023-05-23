using DMOHelper.Dialogs.DialogViewModels;
using DMOHelper.Models;
using Newtonsoft.Json.Linq;
using Syncfusion.Windows.Shared;
using System.Windows;
using System;
using DMOHelper.Enums;

namespace DMOHelper.Dialogs
{
    /// <summary>
    /// Interaktionslogik für DigiviceSCDialog.xaml
    /// </summary>
    public partial class DigiviceSCDialog : ChromelessWindow
    {
        private DigiviceSCVM viewModel;

        public DigiviceSCDialog(DigiviceSCVM _viewModel)
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
            StartBox.SelectAll();
            StartBox.Focus();
        }

        public DigiviceSC Digivice
        {
            get
            {
                return new DigiviceSC()
                {
                    Attribute = viewModel.Attribute,
                    Elemental = viewModel.Elemental,
                    AttributeValue = viewModel.AttributeValue,
                    ElementalValue = viewModel.ElementalValue,
                    ChipsetOption1 = viewModel.ChipsetOption1,
                    ChipsetOption2 = viewModel.ChipsetOption2,
                    ChipsetOption3 = viewModel.ChipsetOption3,
                    ChipsetOption4 = viewModel.ChipsetOption4,
                    ChipsetOptionValue1 = viewModel.ChipsetOptionValue1,
                    ChipsetOptionValue2 = viewModel.ChipsetOptionValue2,
                    ChipsetOptionValue3 = viewModel.ChipsetOptionValue3,
                    ChipsetOptionValue4 = viewModel.ChipsetOptionValue4
                };
            }
        }
    }
}
