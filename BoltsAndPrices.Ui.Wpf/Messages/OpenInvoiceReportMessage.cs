using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoltsAndPrices.Data.Domain;

namespace BoltsAndPrices.Ui.Wpf.Messages
{
    public class OpenInvoiceReportMessage
    {
        private int _invoiceId;
        public int InvoiceId { get { return _invoiceId; } }

        public OpenInvoiceReportMessage(int invoiceId)
        {
            _invoiceId = invoiceId;
        }
    }
}
