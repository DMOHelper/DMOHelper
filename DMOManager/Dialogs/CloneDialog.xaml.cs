using Syncfusion.Windows.Shared;
using System.Windows;
using System;
using DMOHelper.Dialogs.DialogViewModels;

namespace DMOHelper.Dialogs
{
    public partial class CloneDialog : ChromelessWindow
    {
        private CloneVM vm;
        public CloneDialog(CloneVM viewModel)
        {
            this.DataContext = vm = viewModel;
            InitializeComponent();
        }

        private void PerfectClone_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            vm.AttackClone = 144.0;
            vm.CriticalClone = 720;
            vm.EvadeClone = 576;
            vm.HPClone = 54;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            VMMain.GetInstance().StatInformation.AttackClone = vm.AttackClone;
            VMMain.GetInstance().StatInformation.CriticalClone = vm.CriticalClone;
            VMMain.GetInstance().StatInformation.EvadeClone = vm.EvadeClone;
            VMMain.GetInstance().StatInformation.HPClone = vm.HPClone;
            this.DialogResult = true;
            VMMain.GetInstance().StatInformation.Calculate();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            at.SelectAll();
            at.Focus();
        }
    }
}
