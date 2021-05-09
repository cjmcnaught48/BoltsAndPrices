using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoltsAndPrices.Infrastructure.Models
{
    public interface IInvoiceModel
    {
        int? InvoiceId { get; }
        string InvoiceCode { get; }
        IEnumerable<IInvoiceInventoryModel> InvoiceInventories { get;  }
    }

    public static class IInvoiceModelExtensions
    {
        public static bool Exists(this IInvoiceModel invoiceModel)
        {
            return invoiceModel.InvoiceId != null;
        }
    }


    public interface IInvoiceInventoryModel
    {
        int? InvoiceInventoryId { get; }
        int InventoryId { get; }
        int Quantity { get; }
        double UnitPrice { get; }
        double LineTotal { get; }
    }
}
