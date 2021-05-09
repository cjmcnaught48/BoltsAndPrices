using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Services;
using System.Linq;
using BoltsAndPrices.Ui.Wpf.Messages;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainWindowViewModel()
        { 
        }

        public RelayCommand OpenInventoryCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new OpenInventoryIndexMessage());
        });

        public RelayCommand OpenInvoiceIndexCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new OpenInvoiceIndexMessage());
        });
    }
}