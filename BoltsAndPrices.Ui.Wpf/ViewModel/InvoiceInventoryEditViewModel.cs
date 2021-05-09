using BoltsAndPrices.Infrastructure.Models;
using GalaSoft.MvvmLight;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InvoiceInventoryEditViewModel : ViewModelBase, IInvoiceInventoryModel
    {
        public InvoiceInventoryEditViewModel()
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

        private int _inventoryId;
        public int InventoryId
        {
            get
            {
                return _inventoryId;
            }
            set
            {
                _inventoryId = value;
                this.RaisePropertyChanged(() => this.InventoryId);
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
