﻿using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Gamma.Views;
using Gamma.ViewModels;

namespace Gamma
{
    /// <summary>
    /// Description for MainView.
    /// </summary>
    public partial class MainView : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainView class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenProductionTaskMessage>(this, OpenProductionTask);
            Messenger.Default.Register<OpenReportListMessage>(this, OpenReportList);
            Messenger.Default.Register<FindProductMessage>(this, OpenFindProduct);
            this.Closed += MainView_Closed;
        }

        void MainView_Closed(object sender, System.EventArgs e)
        {
            Messenger.Default.Unregister(this);
        }

        private void OpenProductionTask(OpenProductionTaskMessage msg)
        {
            var View = new ProductionTaskView(msg);
            View.Show();
        }
        private void OpenReportList(OpenReportListMessage msg)
        {
            var View = new ReportListView();
            View.Show();
        }
        private void OpenFindProduct(FindProductMessage msg)
        {
            var View = new FindProductView(msg);
            View.Show();
        }
        
    }
}