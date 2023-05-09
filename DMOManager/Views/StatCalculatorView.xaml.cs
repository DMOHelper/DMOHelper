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
        private static StatInformation StatInformation { get; set; }

        public StatCalculatorView()
        {
            InitializeComponent();
            StatInformation = StatInformation.LoadFromDatabase();
        }

        private void Accessories_Click(object sender, RoutedEventArgs e)
        {
            AccessoryDialog accDialog = new AccessoryDialog(StatInformation.Ring, StatInformation.Necklace, StatInformation.Earrings, StatInformation.Bracelet);
            if (accDialog.ShowDialog() == true)
            {
                StatInformation.Ring = accDialog.Ring;
                StatInformation.Necklace = accDialog.Necklace;
                StatInformation.Earrings = accDialog.Earrings;
                StatInformation.Bracelet = accDialog.Bracelet;
                StatInformation.SaveToDatabase();
            }
        }
    }
}
