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
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public InvoiceEditViewModel(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
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

        private InvoiceInventoryEditViewModel _invoiceInventoryEditViewModel;
        public InvoiceInventoryEditViewModel SelectedInvoiceInventory
        {
            get
            {
                return _invoiceInventoryEditViewModel;
            }
            set
            {
                _invoiceInventoryEditViewModel = value;
                this.RaisePropertyChanged(() => this.SelectedInvoiceInventory);
            }
        }

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

        public RelayCommand SaveInvoiceCommand => new RelayCommand(() =>
        {
            SaveInvoice();
        });

        //
        public RelayCommand NewInvoiceInventoryCommand => new RelayCommand(() =>
        {
            InvoiceInventoryModels.Add(new InvoiceInventoryEditViewModelBuilder(_unitOfWorkFactory).Build( 
                new InvoiceInventory()
                {
                    Inventory = new Inventory()
                }
                ));
        });

        private string _statusDescription;
        public string StatusDescription
        {
            get
            {
                return _statusDescription;
            }
            set
            {
                _statusDescription = value;
                this.RaisePropertyChanged(() => this.StatusDescription);
            }
        }
        public bool Status { get; set; }

        public void SaveInvoice()
        {
            StatusDescription = string.Empty;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    new InvoiceService(unitOfWork).AddOrUpdate(this);

                    Status = true;
                    StatusDescription = "Saved.";

                }
                catch (Exception e)
                {
                    Status = false;
                    StatusDescription = "An Error Occurred trying to save changes.";
                }
            }
        }
    }
}
