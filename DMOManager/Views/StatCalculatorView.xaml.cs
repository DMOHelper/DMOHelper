using DMOManager.Dialogs;
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
            AccessoryDialog accDialog = new AccessoryDialog(viewModel.StatInformation.Ring, viewModel.StatInformation.Necklace, viewModel.StatInformation.Earrings, viewModel.StatInformation.Bracelet);
            if (accDialog.ShowDialog() == true)
            {
                viewModel.StatInformation.Ring = accDialog.Ring;
                viewModel.StatInformation.Necklace = accDialog.Necklace;
                viewModel.StatInformation.Earrings = accDialog.Earrings;
                viewModel.StatInformation.Bracelet = accDialog.Bracelet;
                viewModel.StatInformation.SaveToDatabase();
            }
        }

        private void Seals_Click(object sender, RoutedEventArgs eventArgs)
        {
            SealsDialog sealDialog = new SealsDialog(viewModel.StatInformation.Seals);
            if(sealDialog.ShowDialog() == true)
            {
                viewModel.StatInformation.Seals = sealDialog.Seals;
                viewModel.StatInformation.SaveToDatabase();
            }
        }
    }
}
