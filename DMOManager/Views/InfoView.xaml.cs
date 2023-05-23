using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DMOHelper.Views
{
    /// <summary>
    /// Interaktionslogik für InfoView.xaml
    /// </summary>
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
