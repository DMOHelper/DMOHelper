using DMOManager.Helper;
using DMOManager.Models;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Data;

namespace DMOManager.Dialogs
{
    /// <summary>
    /// Interaktionslogik für PresetDialog.xaml
    /// </summary>
    public partial class PresetDialog : ChromelessWindow
    {
        public PresetDialog(AbstractPropertyChanged viewModel, string groupDescription = "")
        {
            this.DataContext = viewModel;
            InitializeComponent();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(presetsBox.ItemsSource);
            view.GroupDescriptions.Clear();
            if (!string.IsNullOrWhiteSpace(groupDescription))
            {
                PropertyGroupDescription group = new PropertyGroupDescription(groupDescription);
                view.GroupDescriptions.Add(group);
            }
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public object GetSelected
        {
            get
            {
                return presetsBox.SelectedItem;
            }
        }
    }
}