using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;

namespace BoltsAndPrices.Ui.Wpf.Reports
{
    public class InvoiceReportModel
    {
        public string InventoryCode { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal { get; set; }
    }


    public class InvoiceReport
    {
        public static IEnumerable<InvoiceReportModel> GetDataSet(int invoiceId)
        {
            IEnumerable<InvoiceReportModel> reportModels;

            using (var unitOfWork = new UnitOfWorkFactory().Create())
            {
                var invoice = unitOfWork.Invoice.Find(invoiceId);

                reportModels =  invoice.InvoiceInventories.Select(i => new InvoiceReportModel()
                {
                    InventoryCode = i.Inventory.InventoryCode,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    LineTotal = i.LineTotal
                }).ToArray();
            }

            return reportModels;
        }
    }
}