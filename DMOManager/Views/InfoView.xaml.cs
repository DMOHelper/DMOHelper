using System.Windows;
using System.Windows.Controls;

namespace DMOHelper.Views
{
    public partial class InfoView : UserControl
    {
        public InfoView()
        {
            this.DataContext = MainWindow.viewModel;
            InitializeComponent();
        }
        private void Fry_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.viewModel.beer)
            {
                MainWindow.viewModel.Source = "/Images/Money.png";
                MainWindow.viewModel.beer = false;
            }
            else
            {
                MainWindow.viewModel.Source = "/Images/Beer.png";
                MainWindow.viewModel.beer = true;
            }
        }
    }
}
