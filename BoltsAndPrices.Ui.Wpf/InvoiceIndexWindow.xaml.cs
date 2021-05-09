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

namespace BoltsAndPrices.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for InvoiceIndexWindow.xaml
    /// </summary>
    public partial class InvoiceIndexWindow : Window
    {
        public InvoiceIndexWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<OpenInvoiceMessage>(this, OpenInvoiceMessageReceived);
            Messenger.Default.Register<AddInvoiceMessage>(this, AddInvoiceMessageReceived);

        }

        private void OpenInvoiceMessageReceived(OpenInvoiceMessage msg)
        {
            var view2 = new InvoiceEditWindow()
            {
                DataContext = new InvoiceEditViewModelBuilder(new UnitOfWorkFactory()).Build(msg.InvoiceId)
            };

            view2.Show();
        }

        private void AddInvoiceMessageReceived(AddInvoiceMessage msg)
        {
            var view2 = new InvoiceEditWindow()
            {
                DataContext = new InvoiceEditViewModelBuilder(new UnitOfWorkFactory()).Build()
            };

            view2.Show();
        }


    }
}
