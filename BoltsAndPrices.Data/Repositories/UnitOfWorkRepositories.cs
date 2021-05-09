using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoltsAndPrices.Data.Domain;

namespace BoltsAndPrices.Data.Repositories
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private Repository<Inventory> _inventoryRepository;
        public Repository<Inventory> Inventory
        {
            get
            {
                if (this._inventoryRepository == null)
                {
                    this._inventoryRepository = new Repository<Inventory>(_context);
                }
                return _inventoryRepository;
            }
        }

        private Repository<Invoice> _invoiceRepository;
        public Repository<Invoice> Invoice
        {
            get
            {
                if (this._invoiceRepository == null)
                {
                    this._invoiceRepository = new Repository<Invoice>(_context);
                }
                return _invoiceRepository;
            }
        }

        private Repository<InvoiceInventory> _invoiceInventoryRepository;
        public Repository<InvoiceInventory> InvoiceInventory
        {
            get
            {
                if (this._invoiceInventoryRepository == null)
                {
                    this._invoiceInventoryRepository = new Repository<InvoiceInventory>(_context);
                }
                return _invoiceInventoryRepository;
            }
        }
    }
}
