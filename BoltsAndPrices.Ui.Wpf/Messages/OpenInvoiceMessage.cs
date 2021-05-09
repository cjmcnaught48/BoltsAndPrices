using BoltsAndPrices.Data.Domain;
using GalaSoft.MvvmLight.Messaging;

namespace BoltsAndPrices.Ui.Wpf.Messages
{
    public class OpenInvoiceMessage : MessageBase
    {
        private int _invoiceId;
        public int InvoiceId { get { return _invoiceId; } }

        public OpenInvoiceMessage(int invoiceId)
        {
            _invoiceId = invoiceId;
        }
    }
}
