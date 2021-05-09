using BoltsAndPrices.Data.Domain;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InvoiceInventoryEditViewModelBuilder
    {
        public InvoiceInventoryEditViewModelBuilder()
        {
        }

        public InvoiceInventoryEditViewModel Build(InvoiceInventory invoiceInventory)
        {
            var model = new InvoiceInventoryEditViewModel();

            model.InventoryId = invoiceInventory.InventoryId;
            model.InvoiceInventoryId = invoiceInventory.InvoiceInventoryId;
            model.LineTotal = invoiceInventory.LineTotal;
            model.Quantity = invoiceInventory.Quantity;
            model.UnitPrice = invoiceInventory.UnitPrice;

            return model;
        }
    }
}
