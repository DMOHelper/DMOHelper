using Syncfusion.Windows.Shared;

namespace DMOHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        internal static VMMain viewModel;

        public MainWindow()
        {
            this.DataContext = viewModel = VMMain.GetInstance();
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.StatInformation.SaveToDatabase();
            SQLiteDatabaseManager.AppClosureHandling();
        }
    }
}