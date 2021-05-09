using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoltsAndPrices.Data;
using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Models;
using BoltsAndPrices.Infrastructure.Services;

namespace BoltsAndPrices.Console
{

    public class InvoiceModel : IInvoiceModel
    {
        public int? InvoiceId { get; set; }

        public string InvoiceCode { get; set; }

        public IEnumerable<IInvoiceInventoryModel> InvoiceInventories { get { return this.invoiceInventories; } }

        public List<InvoiceInventoryModel> invoiceInventories { get; set; }

    }

    public class InvoiceInventoryModel : IInvoiceInventoryModel
    {
        public int? InvoiceInventoryId { get; set; }

        public int InventoryId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double LineTotal { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            using (BoltsAndPricesContext boltsContext = new BoltsAndPricesContext())
            {
                using (var unitOfWork = new UnitOfWork(boltsContext))
                {
                    var invoice = unitOfWork.Invoice.Find(8);

                    var y = invoice.InvoiceInventories;


                }
            }
        }


        private static void DoAdd()
        {
            using (BoltsAndPricesContext boltsContext = new BoltsAndPricesContext())
            {
                using (var unitOfWork = new UnitOfWork(boltsContext))
                {
                    var service = new InvoiceService(unitOfWork);

                    var invoiceModel = new InvoiceModel();

                    invoiceModel.InvoiceId = 8;
                    invoiceModel.InvoiceCode = "xjy111";
                    invoiceModel.invoiceInventories = new List<InvoiceInventoryModel>();

                    var invoiceInventoryModel = new InvoiceInventoryModel();
                    invoiceInventoryModel.InvoiceInventoryId = 5;
                    invoiceInventoryModel.InventoryId = 1;
                    invoiceInventoryModel.LineTotal = 1;
                    invoiceInventoryModel.Quantity = 3;
                    invoiceInventoryModel.UnitPrice = 1;

                    invoiceModel.invoiceInventories.Add(invoiceInventoryModel);

                    service.AddOrUpdate(invoiceModel);

                    unitOfWork.Save();

                    //System.Console.ReadKey();
                }
            }
        }

    }
}