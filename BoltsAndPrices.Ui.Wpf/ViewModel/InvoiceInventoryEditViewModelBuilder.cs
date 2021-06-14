using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using System.Linq;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InvoiceInventoryEditViewModelBuilder
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        public InvoiceInventoryEditViewModelBuilder(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public InvoiceInventoryEditViewModel Build(InvoiceInventory invoiceInventory)
        {
            var model = new InvoiceInventoryEditViewModel(_unitOfWorkFactory);


            using(var unitOfWork = _unitOfWorkFactory.Create())
            {
                model.Inventories = new System.Collections.ObjectModel.ObservableCollection<InventorySelectModel>(unitOfWork.Inventory.GetAll()
                    .Select(i => new InventorySelectModel()
                    {
                        InventoryCode = i.InventoryCode,
                        InventoryId = i.InventoryId,
                        Price = i.Price
                    })

                    .OrderBy(i => i.InventoryCode));
            }

            model.Inventory = new InventorySelectModel( invoiceInventory.Inventory );
            model.InvoiceInventoryId = invoiceInventory.InvoiceInventoryId;
            model.LineTotal = invoiceInventory.LineTotal;
            model.Quantity = invoiceInventory.Quantity;
            model.UnitPrice = invoiceInventory.UnitPrice;

            return model;
        }
    }
}
