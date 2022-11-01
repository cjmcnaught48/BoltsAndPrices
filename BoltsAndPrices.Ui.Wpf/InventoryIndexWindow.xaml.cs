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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InventoryIndexWindow : Window
    {
        private static bool _isregistered = false;


        public InventoryIndexWindow()
        {
            InitializeComponent();

            if(!_isregistered)
            {
                Messenger.Default.Register<OpenInventoryMessage>(this, OpenBoltMessageReceived);
                Messenger.Default.Register<AddInventoryMessage>(this, AddInventoryMessageReceived);
                _isregistered = true;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        private void OpenBoltMessageReceived(OpenInventoryMessage msg)
        {
            var view2 = new InventoryEditWindow()
            {
                DataContext = new InventoryEditViewModelBuilder(new UnitOfWorkFactory()).Build(msg.Inventory)
            };

            view2.Show();
        }

        private void AddInventoryMessageReceived(AddInventoryMessage msg)
        {
            var view2 = new InventoryEditWindow()
            {
                DataContext = new InventoryEditViewModelBuilder(new UnitOfWorkFactory()).Build()
            };

            view2.Show();
        }

    }
}
