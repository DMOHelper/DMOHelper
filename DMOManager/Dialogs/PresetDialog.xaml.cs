using DMOHelper.Helper;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace DMOHelper.Dialogs
{
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
                view.SortDescriptions.Add(new SortDescription(groupDescription, ListSortDirection.Descending));
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
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