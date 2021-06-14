using BoltsAndPrices.Infrastructure.Models;
using GalaSoft.MvvmLight;
using BoltsAndPrices.Data.Repositories;
using System.Collections.ObjectModel;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InvoiceInventoryEditViewModel : ViewModelBase, IInvoiceInventoryModel
    {
        private ObservableCollection<InventorySelectModel> _inventories;
        public ObservableCollection<InventorySelectModel> Inventories
        {
            get
            {
                return _inventories;
            }
            set
            {
                _inventories = value;
                this.RaisePropertyChanged(() => this.Inventories);
            }
        }

        public InvoiceInventoryEditViewModel(IUnitOfWorkFactory unitOfWorkFactory)
        {
        }

        private int? _invoiceInventoryId;
        public int? InvoiceInventoryId
        {
            get
            {
                return _invoiceInventoryId;
            }
            set
            {
                _invoiceInventoryId = value;
                this.RaisePropertyChanged(() => this.InvoiceInventoryId);
            }
        }

        public int InventoryId
        {
            get
            {
                return Inventory.InventoryId;
            }
        }

        private InventorySelectModel _inventory;
        public InventorySelectModel Inventory
        {
            get
            {
                return _inventory;
            }
            set
            {
                _inventory = value;
                UnitPrice = _inventory.Price;
                this.RaisePropertyChanged(() => this.Inventory);
            }
        }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                this.RaisePropertyChanged(() => this.Quantity);

                LineTotal = Quantity * UnitPrice;
            }
        }

        private double _unitPrice;
        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                this.RaisePropertyChanged(() => this.UnitPrice);

                LineTotal = Quantity * UnitPrice;
            }
        }

        private double _lineTotal;
        public double LineTotal
        {
            get
            {
                return _lineTotal;
            }
            set
            {
                _lineTotal = value;
                this.RaisePropertyChanged(() => this.LineTotal);
            }
        }
    }
}
