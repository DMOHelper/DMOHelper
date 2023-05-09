using DMOManager.Models;
using System.Windows;
using System.Windows.Data;

namespace DMOManager.Dialogs
{
    /// <summary>
    /// Interaktionslogik für PresetDialog.xaml
    /// </summary>
    public partial class PresetDialog : Window
    {
        public PresetDialog()
        {
            InitializeComponent();
            presetsBox.ItemsSource = AccessoryPresets.Presets;
            PropertyGroupDescription group = new PropertyGroupDescription("AccessoryType");
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(presetsBox.ItemsSource);
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(group);
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public Accessory? GetSelected
        {
            get
            {
                return presetsBox.SelectedItem as Accessory;
            }
        }
    }
}