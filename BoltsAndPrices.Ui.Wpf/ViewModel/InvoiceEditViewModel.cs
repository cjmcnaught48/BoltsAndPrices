using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Models;
using BoltsAndPrices.Infrastructure.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Linq;
using BoltsAndPrices.Ui.Wpf.Messages;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InvoiceEditViewModel : ViewModelBase, IInvoiceModel
    {
        public InvoiceEditViewModel(IUnitOfWorkFactory unitOfWorkFactory)
        {
            InvoiceInventoryModels = new ObservableCollection<InvoiceInventoryEditViewModel>();
        }

        public int? InvoiceId { get; set; }

        private string _invoiceCode;
        public string InvoiceCode
        {
            get
            {
                return _invoiceCode;
            }
            set
            {
                _invoiceCode = value;
                this.RaisePropertyChanged(() => this.InvoiceCode);
            }
        }

        private string _accountName;
        public string AccountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                _accountName = value;
                this.RaisePropertyChanged(() => this.AccountName);
            }
        }

        public IEnumerable<IInvoiceInventoryModel> InvoiceInventories => InvoiceInventoryModels;

        private ObservableCollection<InvoiceInventoryEditViewModel> _invoiceInventoryModels;
        public ObservableCollection<InvoiceInventoryEditViewModel> InvoiceInventoryModels
        {
            get
            {
                return _invoiceInventoryModels;
            }
            set
            {
                _invoiceInventoryModels = value;
                this.RaisePropertyChanged(() => this.InvoiceInventoryModels);
            }
        }

    }
}
