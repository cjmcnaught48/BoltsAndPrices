using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Services;
using BoltsAndPrices.Ui.Wpf.Messages;
using BoltsAndPrices.Ui.Wpf.ViewModel;
using BoltsAndPrices.Ui.Wpf.Reports;

namespace BoltsAndPrices.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenInventoryIndexMessage>(this, OpenInventoryMessageReceived);
            Messenger.Default.Register<OpenInvoiceIndexMessage>(this, OpenInvoiceMessageReceived);


            Messenger.Default.Register<OpenInvoiceReportMessage>(this, OpenInvoiceReportMessageReceived);

        }

        private void OpenInventoryMessageReceived(OpenInventoryIndexMessage msg)
        {
            var view = new InventoryIndexWindow();
            view.Show();
        }

        private void OpenInvoiceReportMessageReceived(OpenInvoiceReportMessage msg)
        {
            var view = new ReportsWindow();

            view.PrepateReport += (sender, e) =>
            {
                ((ReportsWindow)sender).ReportPath = "";
                ((ReportsWindow)sender).DataSourceName = "InvoiceItems";
                ((ReportsWindow)sender).ReportPath = "/Reports/InvoiceReport.rdlc";
                ((ReportsWindow)sender).DataSourceValue = InvoiceReport.GetDataSet(msg.InvoiceId);
            };

            view.Show();
        }


        private void OpenInvoiceMessageReceived(OpenInvoiceIndexMessage msg)
        {
            var view = new InvoiceIndexWindow();
            view.Show();
        }

    }
}
