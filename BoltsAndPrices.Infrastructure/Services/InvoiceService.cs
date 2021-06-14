using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Models;

namespace BoltsAndPrices.Infrastructure.Services
{
    public class InvoiceService
    {
        private IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(IInvoiceModel invoiceModel)
        {
            if (invoiceModel.Exists())
            {
                Update(invoiceModel);
            }
            else
            {
                Add(invoiceModel);
            }
        }

        private void Add(IInvoiceModel invoiceModel)
        {
            var invoice = new Invoice();

            invoice.InvoiceCode = invoiceModel.InvoiceCode;
            invoice.AccountName = invoiceModel.AccountName;

            foreach(var invoiceInventoryModel in invoiceModel.InvoiceInventories)
            {
                var invoiceInventory = new InvoiceInventory();
                invoiceInventory.InventoryId = invoiceInventoryModel.InventoryId;
                invoiceInventory.Quantity = invoiceInventoryModel.Quantity;
                invoiceInventory.UnitPrice = invoiceInventoryModel.UnitPrice;
                invoiceInventory.LineTotal = invoiceInventoryModel.LineTotal;
                invoiceInventory.Invoice = invoice;

                invoice.InvoiceInventories.Add(invoiceInventory);
            }

            _unitOfWork.Invoice.Add(invoice);
        }

        private void Update(IInvoiceModel invoiceModel)
        {
            if (invoiceModel.InvoiceId == null)
            {
                throw new ModelInvalidException();
            }

            var invoice = _unitOfWork.Invoice.Find(invoiceModel.InvoiceId.Value);

            if (invoice == null)
            {
                throw new ModelInvalidException();
            }

            invoice.InvoiceCode = invoiceModel.InvoiceCode;
            invoice.AccountName = invoiceModel.AccountName;

            var added = invoiceModel.InvoiceInventories
                .Where(i => i.InvoiceInventoryId == null).ToList();

            var deleted = invoice.InvoiceInventories
                .Where(i => !invoiceModel.InvoiceInventories.Any(j => j.InvoiceInventoryId == i.InvoiceInventoryId)).ToList();

            var modified = invoiceModel.InvoiceInventories
                .Where(i => invoice.InvoiceInventories.Any(j => j.InvoiceInventoryId == i.InvoiceInventoryId)).ToList();

            foreach (var invoiceInventoryModel in added)
            {
                var invoiceInventory = new InvoiceInventory();
                invoiceInventory.InventoryId = invoiceInventoryModel.InventoryId;
                invoiceInventory.Quantity = invoiceInventoryModel.Quantity;
                invoiceInventory.UnitPrice = invoiceInventoryModel.UnitPrice;
                invoiceInventory.LineTotal = invoiceInventoryModel.LineTotal;
                invoiceInventory.Invoice = invoice;

                invoice.InvoiceInventories.Add(invoiceInventory);
            }

            for(int i = 0; i<deleted.Count(); i++)
            {
                _unitOfWork.InvoiceInventory.Remove(deleted.ElementAt(i));
            }

            foreach(var invoiceInventoryModel in modified)
            {
                var invoiceInventory = invoice.InvoiceInventories.First(i => i.InvoiceInventoryId == invoiceInventoryModel.InvoiceInventoryId);

                invoiceInventory.InventoryId = invoiceInventoryModel.InventoryId;
                invoiceInventory.Quantity = invoiceInventoryModel.Quantity;
                invoiceInventory.UnitPrice = invoiceInventoryModel.UnitPrice;
                invoiceInventory.LineTotal = invoiceInventoryModel.LineTotal;
            }
        }


        public IEnumerable<Invoice> GetInvoices(string term)
        {
            return _unitOfWork.Invoice.GetWhere(i => i.InvoiceCode.Contains(term));
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            try
            {
                var result = _unitOfWork.Invoice.GetAll().ToList();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}