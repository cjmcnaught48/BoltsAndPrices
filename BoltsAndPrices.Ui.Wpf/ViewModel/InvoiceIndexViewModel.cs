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
    public class InvoiceIndexViewModel : ViewModelBase
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public InvoiceIndexViewModel(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

            Invoices = new ObservableCollection<Invoice>(GetInvoices());
        }

        private ObservableCollection<Invoice> _invoices;
        public ObservableCollection<Invoice> Invoices
        {
            get
            {
                return _invoices;
            }
            set
            {
                _invoices = value;
                this.RaisePropertyChanged(() => this.Invoices);
            }
        }

        private IEnumerable<Invoice> GetInvoices(string searchTerm = null)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = new InvoiceService(unitOfWork);

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return service.GetInvoices().ToList();
                }

                return service.GetInvoices(searchTerm).ToList();
            }
        }

        public Invoice SelectedInvoice { get; set; }

        public RelayCommand AddInvoiceCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new AddInvoiceMessage());
        });

        //
        public RelayCommand ShowInvoiceCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new OpenInvoiceMessage(SelectedInvoice.InvoiceId));
        });

    }
}
