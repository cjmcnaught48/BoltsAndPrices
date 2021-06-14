using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InvoiceEditViewModelBuilder
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private InvoiceInventoryEditViewModelBuilder _invoiceInventoryEditViewModelBuilder;
        public InvoiceEditViewModelBuilder(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _invoiceInventoryEditViewModelBuilder = new InvoiceInventoryEditViewModelBuilder();
        }

        public InvoiceEditViewModel Build()
        {
            var model = new InvoiceEditViewModel(_unitOfWorkFactory);
            return model;
        }

        public InvoiceEditViewModel Build(int invoiceId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var invoice = unitOfWork.Invoice.Find(invoiceId);

                var model = new InvoiceEditViewModel(_unitOfWorkFactory);

                model.InvoiceCode = invoice.InvoiceCode;
                model.AccountName = invoice.AccountName;
                model.InvoiceId = invoice.InvoiceId;

                foreach (var invoiceInventory in invoice.InvoiceInventories)
                {
                    model.InvoiceInventoryModels.Add(_invoiceInventoryEditViewModelBuilder.Build(invoiceInventory));
                }

                return model;
            }
        }
    }
}
