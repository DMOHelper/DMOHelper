﻿using DMOHelper.Dialogs.DialogViewModels;
using DMOHelper.Models;
using Syncfusion.Windows.Shared;
using System;
using System.Windows;

namespace DMOHelper.Dialogs
{
    public partial class SealsDialog : ChromelessWindow
    {

        public SealsDialog(SealsVM _viewModel)
        {
            this.DataContext = _viewModel;
            InitializeComponent();
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            atValue.SelectAll();
            atValue.Focus();
        }

        public Seals Seals
        {
            get
            {
                return new Seals(atValue.Value ?? 0.0, ctValue.Value ?? 0.0, htValue.Value ?? 0.0, hpValue.Value ?? 0.0, dsValue.Value ?? 0.0, deValue.Value ?? 0.0, evValue.Value ?? 0.0);
            }
        }
    }
}
