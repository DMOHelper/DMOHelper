using DMOManager.Dialogs.DialogViewModels;
using DMOManager.Models;
using Syncfusion.Windows.Shared;
using System;
using System.Windows;

namespace DMOManager.Dialogs
{
    /// <summary>
    /// Interaktionslogik für AccessoryDialog.xaml
    /// </summary>
    public partial class AccessoryDialog : ChromelessWindow
    {
        private AccessoryVM viewModel;

        public AccessoryDialog(Ring cRing, Necklace cNeck, Earrings cEars, Bracelet cBrace)
        {
            this.DataContext = viewModel = new AccessoryVM(cRing, cNeck, cEars, cBrace);
            InitializeComponent();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            ringOption1.Focus();
        }

        private void PresetsButton_Click(object sender, RoutedEventArgs e)
        {
            PresetDialog presetDialog = new PresetDialog(viewModel, "AccessoryType");
            if (presetDialog.ShowDialog() == true)
            {
                var accessory = presetDialog.GetSelected;
                if (accessory != null)
                {
                    switch (accessory)
                    {
                        case Ring ring:
                            viewModel.CurrentRing = ring;
                            break;
                        case Necklace necklace:
                            viewModel.CurrentNecklace = necklace;
                            break;
                        case Earrings earrings:
                            viewModel.CurrentEarrings = earrings;
                            break;
                        case Bracelet bracelet:
                            viewModel.CurrentBracelet = bracelet;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public Ring Ring { get { return viewModel.CurrentRing; } }
        public Necklace Necklace { get { return viewModel.CurrentNecklace; } }
        public Earrings Earrings { get {  return viewModel.CurrentEarrings; } }
        public Bracelet Bracelet { get {  return viewModel.CurrentBracelet; } }
    }
}
