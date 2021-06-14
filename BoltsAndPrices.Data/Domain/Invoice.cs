using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace BoltsAndPrices.Data.Domain
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceInventories = new List<InvoiceInventory>();
        }

        public int InvoiceId { get; set; }

        public string InvoiceCode { get; set; }

        public string AccountName { get; set; }

        public virtual ICollection<InvoiceInventory> InvoiceInventories { get; set; }

    }
}