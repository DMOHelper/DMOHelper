using DMOManager.Dialogs;
using DMOManager.Enums;
using DMOManager.Helper;
using DMOManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;

namespace DMOManager
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
            SQLiteDatabaseManager.AppClosureHandling();
        }
    }
}